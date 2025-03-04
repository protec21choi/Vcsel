using FrameOfSystem3.ExternalDevice.FFUOnly;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using RecipeManager_;
using Serial_;
using ThreadTimer_;
using TickCounter_;

namespace FrameOfSystem3.ExternalDevice
{
    /// <summary>
    /// FFU main manager class
    /// </summary>
    public class FFUManager
    {
        #region <ENUM>
        public enum EN_FFU_STATE
        {
            REMOTE_RUN = 0x80,
            LOCAL_RUN = 0x81,
            ALARM_MOTOR_ERROR = 0xA2,
            ALARM_ABNORMAL_STATE = 0xC0,
            ALARM_NO_CONNECTION = 0x00,
        }
        private enum EN_FFU_REQ_MODE
        {
            START = 0,

            CHECK_READY = 100,
            MONITORING = 200,
			SET_SPEED = 300,

            FINISH = 1000,
        }
		#endregion </ENUM>

		#region <CONSTANTS>
		private const int SPEED_NAN = -9999;
        private const int INTERVAL_UPDATE_STATE = 200;

		private const int STOP_SPEED = 0;
		private const int DEFAULT_SPEED = 200;
		#endregion </CONSTANTS>

		#region <CONTRUCTOR>
		private FFUManager()
		{
            _serial = Serial_.Serial.GetInstance();
		}
        private static FFUManager _Instance = null;
        public static FFUManager GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new FFUManager();
            }

            return _Instance;
        }
		#endregion </CONTRUCTOR>

		#region <FIELD>
		private Recipe.Recipe _recipe = null;
		private bool m_bSkipped = true; // 처음엔 true.(program 기동시 문제 생김) 이후 Activate에서 Recipe 값 가져오면 사용으로 바뀜.
		private int _countOfController = 1;
		private int _countOfLCU = 4;

        Serial_.Serial _serial;
		//int m_nIndexOfFFUSerial;

        // Thread to update state
        private Thread m_ThreadUpdateState = null;
        private TickCounter m_tickCount = new TickCounter();
        private int m_nSeqNumber = 0;
		private bool _isDeactivate = false;

        private string m_strErrorMessage = string.Empty;
		private Dictionary<int, MCUControl_MCUL32> m_dicOfDevice = new Dictionary<int, MCUControl_MCUL32>();

		// 2021.11.08 by junho [ADD] Error check
		private bool _isErrored = true;
		#endregion </FIELD>

		#region <PROPERTY>
		public bool IsSkipped
        {
            get { return m_bSkipped; }
            set { m_bSkipped = value; }
        }
		public bool IsErrored
		{
			get { return _isErrored; }
			set 
			{
				if (false == _isErrored.Equals(value))
					_isErrored = value;
			}
		}
		#endregion </PROPERTY>

		#region <INTERFACE>

		#region <Communication methods>
		public bool Activate()
        {
			_recipe = Recipe.Recipe.GetInstance();

			m_bSkipped = (false == _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_USE.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, true));

			_countOfController = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_CONTROLLER_COUNT.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, 1);
			_countOfLCU = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_UNIT_COUNT.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, 4);

            // Assign Registered Serial
            for (int i = 0; i < _countOfController; ++i)
            {
                if (false == m_dicOfDevice.ContainsKey(i))
                {
                    MCUControl_MCUL32 mcuControl = new MCUControl_MCUL32(_serial, (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.FFU, i + 1, _countOfLCU);
                    m_dicOfDevice.Add(i, mcuControl);
                }
            }

            // 스레드를 생성한다
            m_ThreadUpdateState = new Thread(new ThreadStart(Execute));
            m_ThreadUpdateState.Priority = ThreadPriority.Lowest;
            m_ThreadUpdateState.Name = "FFU Gathering Thread";
            m_nSeqNumber = 0;
			_isDeactivate = true;
            m_ThreadUpdateState.Start();

            return true;
        }

        public void Deactivate()
        {
			IsSkipped = true;
			_isDeactivate = false;

			for (int i = 0; i < _countOfController; ++i)
			{
				if (false == m_dicOfDevice.ContainsKey(i))
				{
					continue;
				}

				m_nSeqNumber = (int)EN_FFU_REQ_MODE.FINISH;

				m_dicOfDevice[i].DoClose();
			}
		}

		public void DoOpen()
		{
			if (m_bSkipped)
				return;

			for (int i = 0; i < _countOfController; ++i)
			{
				if (false == m_dicOfDevice.ContainsKey(i))
				{
					continue;
				}

				m_dicOfDevice[i].DoOpen();
			}
		}

        public bool IsOpened()
        {
            if (m_bSkipped) { return true; }

			bool result = true;
			for (int i = 0; i < _countOfController; ++i)
			{
				if (false == m_dicOfDevice.ContainsKey(i))
				{
					return false;
				}

				result &= m_dicOfDevice[i].IsOpened();
			}

			return result;
        }

		public bool IsReadError()
		{
			if (m_bSkipped) { return false; }

			bool result = true;
			for (int i = 0; i < _countOfController; ++i)
			{
				if (m_dicOfDevice.ContainsKey(i))
					continue;

				result &= m_dicOfDevice[i].IsReadError();
			}

			return result;
		}

		public void SetCheckError()
		{
			IsErrored = false;
		}
		#endregion </Communication methods>

		#region <FFU Commands>
		public bool RequestSetSpeedSingleLCU(int nMCUNo, int nLCUNo, int nSpeed)
        {
            if (true == m_bSkipped
				 || false == m_dicOfDevice.ContainsKey(nMCUNo))
                return false;

			if (nSpeed == GetCurrentSpeedSingleLCU(nMCUNo, (int)nLCUNo))
				return true;

			if (false == m_dicOfDevice[nMCUNo].RequestSetSpeed(nLCUNo, nSpeed))
                return false;

			return true;
        }
		public bool RequestSetSpeedAll(int speed)
		{
			bool result = true;

			for (int i = 0; i < _countOfController; ++i)
			{
				for (int j = 0; j < _countOfLCU; ++j)
				{
					result &= RequestSetSpeedSingleLCU(i, j, speed);
				}
			}

			return result;
		}
		public bool RequestSetSpeedArray(int nMCUNo, int[] speed)
		{
			bool result = true;

			for (int i = 0; i < _countOfLCU; ++i)
			{
				result &= RequestSetSpeedSingleLCU(
						nMCUNo
						, i
						, (speed.Length > i) ? speed[i] : DEFAULT_SPEED);
			}

			return result;
		}
		public bool RequestNormalSpeed(int nMCUNo, int ffu)
		{
            int speed = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_TARGET_SPEED_4.ToString(), ffu, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, DEFAULT_SPEED);
			return RequestSetSpeedSingleLCU(nMCUNo, ffu, speed);
		}
		public bool RequestNormalSpeedAll()
		{
            if (IsSkipped)
				return true;

			// 2022.01.04 by junho [MOD] FFU 별개로 컨트롤
			//int speed = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_TARGET_SPEED_1.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, DEFAULT_SPEED);
			//return RequestSetSpeedAll(mcuId, speed);
			int[] speedArray =
			{
				_recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_TARGET_SPEED_4.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, DEFAULT_SPEED)
				, _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_TARGET_SPEED_4.ToString(), 1, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, DEFAULT_SPEED)
				, _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_TARGET_SPEED_4.ToString(), 2, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, DEFAULT_SPEED)
				, _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_TARGET_SPEED_4.ToString(), 3, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, DEFAULT_SPEED)
			};

			bool result = true;
			for (int i = 0; i < _countOfController; ++i)
			{
				result &= RequestSetSpeedArray(i, speedArray);
			}
			return result;
		}
		public bool RequestStopAll(bool force = false)
		{
            if (IsSkipped)
                return true;

			return RequestSetSpeedAll(STOP_SPEED);
		}
		public bool RequestFullSpeedAll(bool force = false)
		{
			if (IsSkipped)
				return true;

			int speed = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_FULL_SPEED.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, 1300);
			return RequestSetSpeedAll(speed);
		}

		public bool RequestReadSpeedSingleLCU(int nMCUNo, int nLCUNo)
        {
            if (true == m_bSkipped
				|| false == m_dicOfDevice.ContainsKey(nMCUNo))
                return false;

			if (false == m_dicOfDevice[nMCUNo].RequestGetRunStates(nLCUNo))
                return false;

            return true;
        }
		public bool RequestSendSetSpeedMessage(int nMCUNo, int nLCUNo)
		{
			if (true == m_bSkipped
				|| false == m_dicOfDevice.ContainsKey(nMCUNo))
				return false;

			if (false == m_dicOfDevice[nMCUNo].SendSetSpeedMessage(nLCUNo))
				return false;

			return true;
		}

		public int GetCurrentSpeedSingleLCU(int nMCUNo, int nLCUNo)
        {
            if (true == m_bSkipped
				 || false == m_dicOfDevice.ContainsKey(nMCUNo))
                return SPEED_NAN;

			return m_dicOfDevice[nMCUNo].GetCurrentSpeed(nLCUNo);
        }

		public bool GetLCUUnitState(int nMCUNo, int nLCUNo, ref int nStateCode)
        {
            if (m_bSkipped)
            {
                nStateCode = (int)EN_FFU_STATE.ALARM_NO_CONNECTION;
                return true;
            }

			if (false == m_dicOfDevice.ContainsKey(nMCUNo))
                return false;

			nStateCode = m_dicOfDevice[nMCUNo].GetAlarmCode(nLCUNo);
            if (nStateCode != (int)EN_FFU_STATE.REMOTE_RUN)
            {
                return false;
            }

            return true;
        }

		public bool IsErrorState()
		{
			foreach (MCUControl_MCUL32 item in m_dicOfDevice.Values)
			{
				foreach (int stateCode in item.GetAlarmCode())
				{
					if (false == stateCode.Equals((int)EN_FFU_STATE.REMOTE_RUN)
						&& false == stateCode.Equals((int)EN_FFU_STATE.LOCAL_RUN))
						return true;
				}
			}

			return false;
		}

        #endregion </FFU Commands>

		#endregion </INTERFACE>

		/// <summary>
        /// Use Window Thread because can not create new TimerThread()
        /// </summary>
        private void Execute()
        {
            while (true)
            {
				if (false == _isDeactivate)
                    return;

                if (false == m_tickCount.IsTickOver(true))
                {
                    Thread.Sleep(10);
                    continue;
                }

				// default delay
				m_tickCount.SetTickCount(500);

				m_bSkipped = (false == _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_USE.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, true));
				if (m_bSkipped)
				{
					m_tickCount.SetTickCount(500);
					continue;
				}

                switch (m_nSeqNumber)
                {
                    case (int)EN_FFU_REQ_MODE.START:
                        m_nSeqNumber = (int)EN_FFU_REQ_MODE.CHECK_READY;
                        break;

					case (int)EN_FFU_REQ_MODE.CHECK_READY:
						#region 
						if(IsErrorState())
						{
							if (false == IsErrored)
							{
                                int nAlarmCode = _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.FFU_ALARM_CODE.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, 0);
								Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, nAlarmCode, false);
								IsErrored = true;
							}
						}
						else
						{
							IsErrored = false;
						}

						++m_nSeqNumber;
						break;
					case (int)EN_FFU_REQ_MODE.CHECK_READY + 1:
						//m_tickCount.SetTickCount(5000); // 5초 대기 필요?
                        if (false == IsOpened())
                        {
                            DoOpen();
                            m_tickCount.SetTickCount(500);
							m_nSeqNumber = (int)EN_FFU_REQ_MODE.CHECK_READY;
							break;
                        }

                        m_nSeqNumber = (int)EN_FFU_REQ_MODE.MONITORING;
                        break;
						#endregion

                    case (int)EN_FFU_REQ_MODE.MONITORING:
						#region 
						for (int i = 0; i < _countOfController; ++i)
						{
							for (int j = 0; j < _countOfLCU; ++j)
							{
								RequestReadSpeedSingleLCU(i, j);
								Thread.Sleep(500);
							}
						}
                        m_tickCount.SetTickCount(500);
						m_nSeqNumber = (int)EN_FFU_REQ_MODE.SET_SPEED;
                        break;
						#endregion

					case (int)EN_FFU_REQ_MODE.SET_SPEED:
						#region 
						for (int i = 0; i < _countOfController; ++i)
						{
							for (int j = 0; j < _countOfLCU; ++j)
							{
								RequestSendSetSpeedMessage(i, j);
								Thread.Sleep(1000);
							}
						}
						m_tickCount.SetTickCount(500);
						m_nSeqNumber = (int)EN_FFU_REQ_MODE.CHECK_READY;
                        break;
						#endregion

					case (int)EN_FFU_REQ_MODE.FINISH:
                        return;
                }
            }
		}
	}

    namespace FFUOnly
    {
        /// <summary>
        /// Maker: BlueCord / Shinsung
        /// Model: MCU: MCUL32 Series (P, BLDC, TOTAL); FFU: xxx
        /// Info: BlueCord MCUL32
        /// Communication Type: Serial
        /// Comport: COM1
        /// Baudrate: 9600 bps
        /// Parity: None
        /// Data Bit: 8
        /// StopBit: 1
        /// FlowControl: None
        /// Unit: rpm
        /// </summary>
        class MCUControl_MCUL32
        {
            #region <Enumeration>
            private enum EN_CMD
            {
                NONE,
                SET_CONTROL,
                GET_STATUS,
            }

            private enum EN_DATA_STRUCT
            {
                LCU_ID = 0,
                PV = 1, // Current velocity
                ALARM_STATE = 2,
                SV = 3, // Set Velocity
                DATA_mmAQ_LSV = 4, // Set Velocity
                DATA_mmAQ_HSV = 5, // Set Velocity
            }

			private enum EN_DATA_STRUCT_READ_SEND
			{
				STX			,
				MODE1		,	// Read, Write
				MODE2		,	// Default 0x9f
				MCUL_ID		,	// Controller ID
				DPU_ID		,	// Default 0x9f
				START_ID	,	// LCU start ID
				END_ID		,	// LCU end ID
				CHECK_SUM	,
				ETX			,
			}

			private enum EN_DATA_STRUCT_READ_RECEIVE
			{
				STX			,
				MODE1		,		// Read, Write
				MODE2		,		// Default 0x9f
				MCUL_ID		,		// Controller ID
				DPU_ID		,		// Default 0x9f
				LCU_ID		,		// LCU ID
				DATA_PV		,		// LCU Current speed
				AL_ST		,		// LCU Status and Alarm
				DATA_SV		,		// LCU Target speed (setting speed)
				mmAq_LSV	,		// pressure sensor value (low setting value)
				mmAq_HSV	,		// pressure sensor value (high setting value)
				CHECK_SUM	,
				ETX			,
			}
			private enum EN_DATA_STRUCT_WRITE_SEND
			{
				STX			,
				MODE1		,		// Read, Write
				MODE2		,		// Default 0x9f
				MCUL_ID		,		// Controller ID
				DPU_ID		,		// Default 0x9f
				START_ID	,		// LCU start ID
				END_ID		,		// LCU end ID
				DATA_SV		,		// LCU Target speed (setting speed)
				mmAq_LSV	,		// pressure sensor value (low setting value)
				mmAq_HSV	,		// pressure sensor value (high setting value)
				CHECK_SUM	,
				ETX			,
			}
			private enum EN_DATA_STRUCT_WRITE_RECEIVE
			{
				STX			,
				MODE1		,		// Read, Write
				MODE2		,		// Default 0x9f
				MCUL_ID		,		// Controller ID
				DPU_ID		,		// Default 0x9f
				START_ID	,		// LCU start ID
				END_ID		,		// LCU end ID
				FLAG_OK		,		// Result
				CHECK_SUM	,
				ETX			,
			}

            public enum EN_FFU_STATE
            {
                REMOTE_RUN = 0x80,
                LOCAL_RUN = 0x81,
                ALARM_MOTOR_ERROR = 0xA2,
                ALARM_ABNORMAL_STATE = 0xC0,
                ALARM_NO_CONNECTION = 0x00,
            }


            #endregion </Enumeration>

            #region <Constants>
			private const byte STX = 0x02;
			private const byte ETX = 0x03;

            private const byte MODE_1_READ = 0x8A;
            private const byte MODE_1_WRITE = 0x89;
            private const byte MODE_2 = 0x9f;

			private const byte MCU_START_ID = 0x81;

            private const byte FLAG_OK = 0xB9;

            private const byte DPU_ID = 0x9F;
            private const byte LCU_START_ID = 0x81;
			private const byte LCU_START_ID_2 = 0x3F;

            private const int ACK_START_DATA_BYTE = 5;			// LCU 개별 data가 시작되는 Index
            private const int ACK_NUMBER_OF_DATA_ONE_LCU = 6;	// LCU 1개당 넘어오는 Data 개수

			private const ushort MAX_NO_LCU = 32;
            #endregion </Constants>

            #region <Fields>
            private EN_CMD m_enCmdSent = EN_CMD.NONE;

            private Encoding m_encoding = Encoding.ASCII;

            private string m_strReceived = string.Empty;

            private Serial_.Serial _serial;

			private bool _isOpen = false;
			private static byte _LCU_END_ID;

			private static int _SERIAL_INDEX;
			private static int _LCU_COUNT;
			private static byte _MCU_ID;

			private Dictionary<int, LCU_Item> _listOfFFU = new Dictionary<int, LCU_Item>();
			#endregion </Fields>

            #region <Constructor>
            public MCUControl_MCUL32(Serial_.Serial instSerial, int nSerialIndex, int mcuNo, int countOfLCU)
            {
				_serial = instSerial;
				_SERIAL_INDEX = nSerialIndex;

				_MCU_ID = Convert.ToByte((int)0x80 + mcuNo);

				_LCU_COUNT = countOfLCU;
				_LCU_END_ID = Convert.ToByte((int)LCU_START_ID + _LCU_COUNT - 1);

                //// 2021.01.02 by Thienvv [ADD] FFU Using encoding ISO 8859-1 (code 28591)
                //mEncoding = System.Text.Encoding.GetEncoding(28591);

				_SERIAL_INDEX = nSerialIndex;
				_LCU_COUNT = countOfLCU;

				for (int i = 0; i < countOfLCU; i++)
				{
					_listOfFFU.Add(i, new LCU_Item(i));
				}
            }
            #endregion </Constructor>

            #region <Override methods>

            #region <Commnucation methods>
            public void DoInit()
            {
                Clear();
            }

            public void DoOpen()
            {
                DoInit();
				_serial.Open(_SERIAL_INDEX);
				_isOpen = true;
                Clear();

				return;
            }

            public void DoClose()
            {
                Clear();
				_serial.Close(_SERIAL_INDEX);
				_isOpen = false;
            }

            public bool IsOpened()
            {
                SERIAL_ITEM_STATE state = _serial.GetState(_SERIAL_INDEX);

                switch (state)
                {
                    case SERIAL_ITEM_STATE.OPENED:
                    case SERIAL_ITEM_STATE.TIMEOUT_RECEIVE:
                    case SERIAL_ITEM_STATE.WAITING_RECEIVE:
                        return true;
                }

                return false;
            }

            public bool IsReadError()
            {
                return false;
            }

            #endregion </Commnucation methods>

            #region <FFU Control methods>

            /// <summary>
            /// Set Speed to a LCU (Single)
            /// </summary>
            /// <param name="nLCUNo"></param>
            /// <param name="nValue"></param>
            /// <returns></returns>
            public bool RequestSetSpeed(int nLCUNo, int nValue)
            {
                if (false == IsOpened() || m_enCmdSent != EN_CMD.NONE)
                    return false;

                if (nLCUNo < 0 || nLCUNo > _LCU_COUNT)
                    return false;

                if (nValue < 0 || nValue > 1300)
					return false;

				if (nValue == _listOfFFU[nLCUNo].CurrentSpeed)
					return true;

				_listOfFFU[nLCUNo].TargetSpeed = nValue;
				return true;
			}

			public bool SendSetSpeedMessage(int nLCUNo)
			{
				if (_listOfFFU[nLCUNo].TargetSpeed == _listOfFFU[nLCUNo].CurrentSpeed)
					return true;

				int nSpeedSend = _listOfFFU[nLCUNo].TargetSpeed / 10;

				byte[] bytesToSend = MakePacketWriteSingle(nLCUNo, nSpeedSend);
				if (false == _serial.Write(_SERIAL_INDEX, bytesToSend))
                    return false;

                m_enCmdSent = EN_CMD.SET_CONTROL;

                // Check response
                if (false == ParsingAck(m_enCmdSent))
                {
                    m_enCmdSent = EN_CMD.NONE;
                    return false;
                }

                m_enCmdSent = EN_CMD.NONE;
                return true;
            }

            /// <summary>
            /// Get Run States
            /// nLCUNo == -1 ==> Read update all LCU
            /// nLCUNo > -1 ==> Read Single LCU
            /// </summary>
            /// <returns></returns>
            public bool RequestGetRunStates(int nLCUNo)
            {
                if (false == IsOpened() || m_enCmdSent != EN_CMD.NONE)
                    return false;

                if (nLCUNo < 0 || nLCUNo > _LCU_COUNT)
                    return false;

				byte[] bytesToSend = MakePacketReadSingle(nLCUNo);

                if (false == _serial.Write(_SERIAL_INDEX, bytesToSend))
                    return false;

                Thread.Sleep(500);

                m_enCmdSent = EN_CMD.GET_STATUS;

                // Check response
                if (false == ParsingAck(m_enCmdSent))
                {
                    m_enCmdSent = EN_CMD.NONE;
                    return false;
                }

                m_enCmdSent = EN_CMD.NONE;
                return true;
            }

            #endregion </FFU Control methods>

            #endregion </Override methods>

            #region <Private methods>
            private void Clear()
            {
                m_enCmdSent = EN_CMD.NONE;
            }
            private bool ParsingAck(EN_CMD enCmd)
            {
				byte[] readData = new byte[0];

				TickCounter tickCount = new TickCounter();
				// Wait for response
				tickCount.SetTickCount(2000);

				while (true)
				{
					if (tickCount.IsTickOver(false))
						return false;

                    byte[] readbuff = null;
                    if(_serial.Read(_SERIAL_INDEX, ref readbuff))
                    {
                        if(readbuff != null)
                        {
                             byte[] sumbuff = new byte[readData.Length];
                            Array.Copy(readData,sumbuff,readData.Length);
                            readData = new byte[readData.Length + readbuff.Length];
                            Array.Copy(sumbuff, readData, sumbuff.Length);
                            Array.Copy(readbuff, 0, readData, sumbuff.Length, readbuff.Length);
                        }
                    }
					if (readData.Length > 0 && readbuff == null)
						break;

					Thread.Sleep(10);
				}
				if (readData.Length == 0) return false;

                try
                {
                    switch (enCmd)
                    {
                        case EN_CMD.NONE:
                            return true;

                        case EN_CMD.SET_CONTROL:
							if (readData.Length != Enum.GetValues(typeof(EN_DATA_STRUCT_WRITE_RECEIVE)).Length)
                                return false;
							
                            if (readData[(int)EN_DATA_STRUCT_WRITE_RECEIVE.FLAG_OK] != FLAG_OK)
                                return true;

                            break;

                        case EN_CMD.GET_STATUS:
							if ((readData.Length - Enum.GetValues(typeof(EN_DATA_STRUCT_READ_RECEIVE)).Length) % ACK_NUMBER_OF_DATA_ONE_LCU != 0)
								return false;

							int readLCUCount = (readData.Length - (Enum.GetValues(typeof(EN_DATA_STRUCT_READ_RECEIVE)).Length - ACK_NUMBER_OF_DATA_ONE_LCU)) / ACK_NUMBER_OF_DATA_ONE_LCU;

							bool isAlarm = false;
							for (int i = 0; i < readLCUCount; ++i)
							{
								int indexOffset = i * ACK_NUMBER_OF_DATA_ONE_LCU;
                                byte byteLcuID = readData[(int)EN_DATA_STRUCT_READ_RECEIVE.LCU_ID + indexOffset];
								byte bytePV = readData[(int)EN_DATA_STRUCT_READ_RECEIVE.DATA_PV + indexOffset];
								byte byteAlarm = readData[(int)EN_DATA_STRUCT_READ_RECEIVE.AL_ST + indexOffset];
								byte byteSV = readData[(int)EN_DATA_STRUCT_READ_RECEIVE.DATA_SV + indexOffset];

                                int lcuNo = (int)byteLcuID - MCU_START_ID;
								if (byteAlarm == (byte)EN_FFU_STATE.REMOTE_RUN)
								{
									_listOfFFU[lcuNo].AlarmCode = (int)EN_FFU_STATE.REMOTE_RUN;
								}
								else if (byteAlarm == (byte)EN_FFU_STATE.LOCAL_RUN)
								{
									_listOfFFU[lcuNo].AlarmCode = (int)EN_FFU_STATE.LOCAL_RUN;
								}
								else if (byteAlarm == (byte)EN_FFU_STATE.ALARM_MOTOR_ERROR)
								{
									_listOfFFU[lcuNo].AlarmCode = (int)EN_FFU_STATE.ALARM_MOTOR_ERROR;
									isAlarm = true;
								}
								else if (byteAlarm == (byte)EN_FFU_STATE.ALARM_ABNORMAL_STATE)
								{
									_listOfFFU[lcuNo].AlarmCode = (int)EN_FFU_STATE.ALARM_ABNORMAL_STATE;
									isAlarm = true;
								}
								else if (byteAlarm == (byte)EN_FFU_STATE.ALARM_NO_CONNECTION)
								{
									_listOfFFU[lcuNo].AlarmCode = (int)EN_FFU_STATE.ALARM_NO_CONNECTION;
									isAlarm = true;
								}

                              //  _listOfFFU[lcuNo].TargetSpeed = (int)byteSV * 10;
                                _listOfFFU[lcuNo].CurrentSpeed = (int)bytePV * 10;

							}

							if (isAlarm == true)
								return false;

                            break;

                        default:
                            return false;
                    }
                    return true;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }

			#region <Make Packages>

			private byte[] MakePacketWriteAll(int nVelocity, int mmAq = 100)
			{
				byte[] bytesToSend = new byte[12];
				byte bUppermAP = (byte)(mmAq >> 8);
				byte bLowermAP = (byte)(mmAq & 0xff);

				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.STX] = STX;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.MODE1] = MODE_1_WRITE;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.MODE2] = MODE_2;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.MCUL_ID] = _MCU_ID;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.DPU_ID] = DPU_ID;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.START_ID] = LCU_START_ID;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.END_ID] = _LCU_END_ID;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.DATA_SV] = (byte)nVelocity;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.mmAq_LSV] = bUppermAP;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.mmAq_HSV] = bLowermAP;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.CHECK_SUM] = MakeChecksum(bytesToSend, (int)EN_DATA_STRUCT_WRITE_SEND.MODE1, (int)EN_DATA_STRUCT_WRITE_SEND.mmAq_HSV);
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.ETX] = ETX;

				return bytesToSend;
			}

			private byte[] MakePacketWriteSingle(int nLCUNo, int nVelocity, int mmAq = 100)
            {
                byte[] bytesToSend = new byte[12];
				byte bStartLCU = Convert.ToByte((int)LCU_START_ID + nLCUNo);
				byte bUppermAP = (byte)(mmAq >> 8);
				byte bLowermAP = (byte)(mmAq & 0xff);

				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.STX] = STX;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.MODE1] = MODE_1_WRITE;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.MODE2] = MODE_2;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.MCUL_ID] = _MCU_ID;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.DPU_ID] = DPU_ID;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.START_ID] = bStartLCU;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.END_ID] = bStartLCU;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.DATA_SV] = (byte)nVelocity;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.mmAq_LSV] = bUppermAP;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.mmAq_HSV] = bLowermAP;
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.CHECK_SUM] = MakeChecksum(bytesToSend, (int)EN_DATA_STRUCT_WRITE_SEND.MODE1, (int)EN_DATA_STRUCT_WRITE_SEND.mmAq_HSV);
				bytesToSend[(int)EN_DATA_STRUCT_WRITE_SEND.ETX] = ETX;

                return bytesToSend;
            }

			private byte[] MakePacketReadAll()
            {
                byte[] bytesToSend = new byte[9];

				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.STX] = STX;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.MODE1] = MODE_1_READ;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.MODE2] = MODE_2;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.MCUL_ID] = _MCU_ID;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.DPU_ID] = DPU_ID;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.START_ID] = LCU_START_ID;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.END_ID] = _LCU_END_ID;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.CHECK_SUM] = MakeChecksum(bytesToSend, (int)EN_DATA_STRUCT_READ_SEND.MODE1, (int)EN_DATA_STRUCT_READ_SEND.END_ID);
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.ETX] = ETX;

                return bytesToSend;
            }

			private byte[] MakePacketReadSingle(int nLCUNo)
            {
                byte[] bytesToSend = new byte[9];
				byte bStartLCU = Convert.ToByte((int)LCU_START_ID + nLCUNo);

				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.STX] = STX;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.MODE1] = MODE_1_READ;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.MODE2] = MODE_2;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.MCUL_ID] = _MCU_ID;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.DPU_ID] = DPU_ID;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.START_ID] = bStartLCU;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.END_ID] = bStartLCU;
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.CHECK_SUM] = MakeChecksum(bytesToSend, (int)EN_DATA_STRUCT_READ_SEND.MODE1, (int)EN_DATA_STRUCT_READ_SEND.END_ID);
				bytesToSend[(int)EN_DATA_STRUCT_READ_SEND.ETX] = ETX;

                return bytesToSend;
            }

            /// <summary>
            ///  Check sum 
            /// </summary>
            private byte MakeChecksum(byte[] bArrToCheck, int nStartIndex, int nEndIndex)
            {
                int nTemp = 0;
                byte byteChecksum = 0;

                if (bArrToCheck.Length == 0)
                    return 0;

                for (int i = nStartIndex; i <= nEndIndex; i++)
                {
                    nTemp += bArrToCheck[i];
                }

                byteChecksum = (byte)(255 & nTemp);
                return byteChecksum;
            }

            /// <summary>
            /// Convert From string Hex to array bytes of hex
            /// </summary>
            /// <param name="strHex"></param>
            /// <returns></returns>
            private byte[] FromHex(string strHex)
            {
                strHex = strHex.Replace("-", "");
                byte[] bytesRaw = new Byte[strHex.Length / 2];
                for (int i = 0; i < bytesRaw.Length; i++)
                {
                    bytesRaw[i] = Convert.ToByte(strHex.Substring(i * 2, 2), 16);
                }
                return bytesRaw;
            }
            #endregion </Make Packages>

            #endregion </Private methods>

			#region <INTERFACE>
			public int GetAlarmCode(int lcuNo)
			{
				if (false == _listOfFFU.ContainsKey(lcuNo))
					return -1;

				return _listOfFFU[lcuNo].AlarmCode;
			}
			public List<int> GetAlarmCode()
			{
				List<int> result = new List<int>();

				foreach(LCU_Item lcu in _listOfFFU.Values)
				{
					result.Add(lcu.AlarmCode);
				}

				return result;
			}
			public int GetCurrentSpeed(int lcuNo)
			{
				if (false == _listOfFFU.ContainsKey(lcuNo))
					return -1;

				return _listOfFFU[lcuNo].CurrentSpeed;
			}
			#endregion </INTERFACE>

			#region <INNER CLASS>
			private class LCU_Item
			{
				public LCU_Item(int lcuNo)
				{
					LCUNo = lcuNo;
					TargetSpeed = 0;
					CurrentSpeed = 0;
					AlarmCode = 0;
				}

				public int LCUNo { get; set; }
				public int TargetSpeed { get; set; }
				public int CurrentSpeed { get; set; }
				public int AlarmCode { get; set; }
			}
			#endregion </INNER CLASS>
		}
    }
}
