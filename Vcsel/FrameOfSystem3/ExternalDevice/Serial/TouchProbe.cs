using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Define.DefineEnumProject.Serial;

namespace FrameOfSystem3.ExternalDevice.Serial
{
	class TouchProbe
	{
		#region Enum List
		public enum EN_COMMAND_LIST
		{
			SET_ZERO,
			GET_DATA,
		}

        public enum EN_STATE
        {
            NONE,
            READY,

            WAITING_READ,
        }
		#endregion

		#region 싱글톤
		private static TouchProbe _Instance	= new TouchProbe();
		private TouchProbe() { }
		public static TouchProbe GetInstance() { return _Instance; }
		#endregion

		#region 상수
		private const double ZERO_VALUE						= 0.0;
		private const double FAIL_VALUE						= -9999;

		private const int TIMER_INTERVAL					= 100;

		private const int DATA_START_INDEX					= 6;
		private const int DATA_LENGTH						= 7;

		private readonly string SET_ZERO = "Z011" + Char.ConvertFromUtf32(13) + Char.ConvertFromUtf32(10);
		private readonly string GET_DATA = ">R01" + Char.ConvertFromUtf32(13) + Char.ConvertFromUtf32(10);
		#endregion

		#region 변수
        private bool m_bInit = false;
        private int m_nSerialIndex;
        private Config.ConfigSerial m_Serial = Config.ConfigSerial.GetInstance();

        private ConcurrentQueue<EN_COMMAND_LIST> m_queCommand = new ConcurrentQueue<EN_COMMAND_LIST>();

        private EN_COMMAND_LIST m_CurrentCommand = EN_COMMAND_LIST.GET_DATA;

		private byte[] m_arReceivedData						= null;

		private double _Value_m_dbl							= 0.0;

		private EN_STATE m_enState							= EN_STATE.NONE;
        private TickCounter_.TickCounter m_TickForTimeOut = new TickCounter_.TickCounter();
        #endregion

		#region 속성
		public double ReadValue 
        { 
            get 
            { 
                return _Value_m_dbl; 
            } 
        }
		#endregion

		#region 내부인터페이스
		/// <summary>
		/// 2021.12.31 by twkang [ADD] 주기함수 Command 요청이 들어오면 시작한다.
		/// </summary>
		public void Execute()
		{
            if (m_Serial.IsOpen(m_nSerialIndex) == false
                || m_bInit == false)
                return;


            switch (m_enState)
            {
                case EN_STATE.NONE:
                case EN_STATE.READY:
                    EN_COMMAND_LIST enCommand = EN_COMMAND_LIST.GET_DATA;
                    if(!m_queCommand.TryDequeue(out enCommand))
                    {
                        enCommand = EN_COMMAND_LIST.GET_DATA;
                    }

                    if (ActionCommand(enCommand))
                    {
                        m_CurrentCommand = enCommand;

                        m_enState = EN_STATE.WAITING_READ;
                        m_TickForTimeOut.SetTickCount(100);
                    }
                    break;

                case EN_STATE.WAITING_READ:
                    byte[] arReadData = null;

                    if (ReadMessage(ref arReadData))
                    {
                        DataParsing(m_CurrentCommand, ref arReadData);
                        m_arReceivedData = null;

                        m_enState = EN_STATE.READY;
                    }

                    if (m_TickForTimeOut.IsTickOver(false))
                    {
                        m_arReceivedData = null;

                        m_enState = EN_STATE.READY;
                    }
                    break;
            }
		}

		/// <summary>
		/// 2021.10.18 by twkang [ADD] String -> Byte
		/// </summary>
		private void ConvertStringToByte(string strData, ref byte[] arMessage)
		{
			char[] chMessage    = strData.ToCharArray();
			arMessage = System.Text.Encoding.ASCII.GetBytes(chMessage);
		}

		private bool ActionCommand(EN_COMMAND_LIST enCommand)
		{
			byte[] arSendData	= null;

			switch(enCommand)
			{
				case EN_COMMAND_LIST.GET_DATA:
					//_Value_m_dbl		= ZERO_VALUE;

					ConvertStringToByte(GET_DATA, ref arSendData);
					break;
				case EN_COMMAND_LIST.SET_ZERO:
					ConvertStringToByte(SET_ZERO, ref arSendData);
					break;

				default:
					return false;
			}

            return m_Serial.Write(m_nSerialIndex, arSendData);
		}

		/// <summary>
		/// 2021.12.31 by twkang [ADD] 받은 데이터 확인
		/// </summary>
		private bool ReadMessage(ref byte[] arReceiveData)
		{
			byte[] arTemp	= null;

            if (false == m_Serial.Read(m_nSerialIndex, ref arTemp))
				return false;

			if (m_arReceivedData == null)
                m_arReceivedData = arTemp;
			else
                m_arReceivedData = m_arReceivedData.Concat(arTemp).ToArray();

            arReceiveData = m_arReceivedData;

            string strMessage = System.Text.Encoding.ASCII.GetString(arReceiveData);
            if (strMessage.Length > 2
                && strMessage.Substring(strMessage.Length - 2, 2) == "\r\n"
                && strMessage.Length > 14)
			// 조건 필요
			return true;
            return false;
		}
		/// <summary>
		/// 2021.12.31 by twkang [ADD] 받은 데이터를 파싱하여 저장
		/// </summary>
		private void DataParsing(EN_COMMAND_LIST enCommand, ref byte[] arData)
		{
			if(arData == null || arData.Length == 0) return;

			string strMessage	= System.Text.Encoding.ASCII.GetString(arData);

			switch(enCommand)
			{
				case EN_COMMAND_LIST.GET_DATA:
                    // "<R01=+00.0000\r\n"
                    if (false == double.TryParse(strMessage.Substring(5, 8), out _Value_m_dbl))
                    {
                        _Value_m_dbl = FAIL_VALUE;
                    }
                
					break;
				case EN_COMMAND_LIST.SET_ZERO:
                    //"Z011,+003.1138\r\n"
					break;
			}
		}
		#endregion

		#region 외부인터페이스
		/// <summary>
		/// 2021.12.13 by twkang [ADD] 초기화
		/// </summary>
		public bool Init(int nSerialIndex)
		{
            m_nSerialIndex = nSerialIndex;

            m_bInit = true;
            return m_Serial.Open(nSerialIndex);
		}

		/// <summary>
		/// 2021.12.31 by twkang [ADD] Command 요청함수
		/// </summary>
		public bool RequestCommand(EN_COMMAND_LIST enCommand)
		{
         
			m_queCommand.Enqueue(enCommand);

			

            return true;
		}
	
		#endregion
	}
}
