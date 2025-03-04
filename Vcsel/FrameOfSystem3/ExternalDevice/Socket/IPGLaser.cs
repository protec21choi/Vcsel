using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameOfSystem3.ExternalDevice.Socket
{
	public class IPGLaser
	{
         #region 싱글톤
        private IPGLaser() { }

        private static readonly Lazy<IPGLaser> lazyInstance = new Lazy<IPGLaser>(() => new IPGLaser());
        static public IPGLaser GetInstance() 
        {
            return lazyInstance.Value; 
        }
        #endregion

		#region 열거형
        enum EN_EXCUTE_STATE
        {
            REQUEST_STA,
            REQUEST_RCS,
            WAIT_RECIEVE,
            PARSHING_DATA,
        }
		#endregion

		#region 상수
        private const int INTERVAL_TIMER = 200;

		private readonly string Status			                        = "STA";
		private readonly string Power			                    = "ROP";

        private readonly string CR = Encoding.ASCII.GetString(new byte[] { 0x0D });


         private const uint COMMAND_BUFFER_OVERLOAD = 1;
         private const uint OVERHEAT = 2;
         private const uint EMISSION_ON = 4;
         private const uint BACK_REFLECCION_LEVEL_HIGH = 8;
         private const uint ANALOG_POWER_CONTROL_ENABLE = 16;
         private const uint PULSE_TOO_LONG = 32;
         private const uint AIMING_BEAM_ON = 256;
         private const uint PULSE_TOO_SHORT = 512;
         private const uint PULSE_MODE = 1024;
         private const uint POWER_SUPPLY_OFF = 2048;
         private const uint MODULATION_ENABLE = 4096;
         private const uint GATE_MODE = 65536;
         private const uint HIGH_PULSE_ENERGY = 131072;
         private const uint HARDWARE_EMISSION_CONTROL_ENABLE = 262144;
         private const uint POWER_SUPPLY_FAIL = 524228;
         private const uint FRONT_DISPLAY_LOCK = 1048576;
         private const uint KEY_SWITCH_REMOTE = 2097152;
         private const uint WAVEFORM_MODE = 4194304;
         private const uint DUTYCYCLE_TOO_HIGH = 8388608;
         private const uint LOW_TEMPERATURE = 16777216;
         private const uint POWER_SUPPLY_ALARM = 33554432;
         private const uint HARDWARE_AIMING_CONTROL_ENABLE = 134217728;
         private const uint CRITICAL_ERROR = 536870912;
         private const uint FIBER_INTERLOCK = 1073741824;
         private const uint HIGH_AVERAGE_POWER = 2147483648;
		#endregion

		#region 변수
        private Config.ConfigSocket m_InstanceOfSocket = Config.ConfigSocket.GetInstance();

        private int m_nIndexOfSocket = -1;

        private EN_EXCUTE_STATE m_enState = EN_EXCUTE_STATE.REQUEST_STA;

        private string m_strReceiveDate = "";

        private bool m_bError_CommandBuffer_Overload = false;
        private bool m_bError_Overheat = false;
        private bool m_bError_BackReflection_HighLevel = false;
        private bool m_bError_Pulse_TooLong = false;
        private bool m_bError_Pulse_TooShort = false;
        private bool m_bError_PowerSupply_Fail = false;
        private bool m_bError_DutyCycle_TooHight = false;
        private bool m_bError_PowerSupply_Alarm = false;
        private bool m_bError_Critical_Error = false;
        private bool m_bError_Fiber_Interlock = false;
        private bool m_bError_Power_HighAverage = false;
        private bool m_bError_Temperature_Low = false;

        private bool m_bMode_Analog_Power_Control = false;
        private bool m_bMode_Pulse = false;
        private bool m_bMode_Modulation = false;
        private bool m_bMode_Gate = false;
        private bool m_bMode_HardWare_Emission_Control = false;
        private bool m_bMode_Panel_Lock = false;
        private bool m_bMode_KeySwitch_Remote = false;
        private bool m_bMode_Waveform = false;
        private bool m_bMode_HardWare_Aiming_Control = false;

        private double m_dPower = 0;
		#endregion

        #region 속성
        public bool bError_CommandBuffer_Overload { get { return m_bError_CommandBuffer_Overload; } }
        public bool bError_Overheat { get { return m_bError_Overheat; } }
        public bool bError_BackReflection_HighLevel { get { return m_bError_BackReflection_HighLevel; } }
        public bool bError_Pulse_TooLong { get { return m_bError_Pulse_TooLong; } }
        public bool bError_Pulse_TooShort { get { return m_bError_Pulse_TooShort; } }
        public bool bError_PowerSupply_Fail { get { return m_bError_PowerSupply_Fail; } }
        public bool bError_DutyCycle_TooHight { get { return m_bError_DutyCycle_TooHight; } }
        public bool bError_PowerSupply_Alarm { get { return m_bError_PowerSupply_Alarm; } }
        public bool bError_Critical_Error { get { return m_bError_Critical_Error; } }
        public bool bError_Fiber_Interlock { get { return m_bError_Fiber_Interlock; } }
        public bool bError_Power_HighAverage { get { return m_bError_Power_HighAverage; } }
        public bool bError_Temperature_Low { get { return m_bError_Temperature_Low; } }

        public bool bMode_Analog_Power_Control { get { return m_bMode_Analog_Power_Control; } }
        public bool bMode_Pulse { get { return m_bMode_Pulse; } }
        public bool bMode_Modulation { get { return m_bMode_Modulation; } }
        public bool bMode_Gate { get { return m_bMode_Gate; } }
        public bool bMode_HardWare_Emission_Control { get { return m_bMode_HardWare_Emission_Control; } }
        public bool bMode_Panel_Lock { get { return m_bMode_Panel_Lock; } }
        public bool bMode_KeySwitch_Remote { get { return m_bMode_KeySwitch_Remote; } }
        public bool bMode_Waveform { get { return m_bMode_Waveform; } }
        public bool bMode_HardWare_Aiming_Control { get { return m_bMode_HardWare_Aiming_Control; } }
        public double dPower { get { return m_dPower; } } 
        #endregion

        #region 내부인터페이스
        private void ParseStatusBit(uint nStatus)
        {
            m_bError_CommandBuffer_Overload = (nStatus & COMMAND_BUFFER_OVERLOAD) == COMMAND_BUFFER_OVERLOAD;
            m_bError_Overheat = (nStatus & OVERHEAT) == OVERHEAT;
            m_bError_BackReflection_HighLevel = (nStatus & BACK_REFLECCION_LEVEL_HIGH) == BACK_REFLECCION_LEVEL_HIGH;
            m_bError_Pulse_TooLong = (nStatus & PULSE_TOO_LONG) == PULSE_TOO_LONG;
            m_bError_Pulse_TooShort = (nStatus & PULSE_TOO_SHORT) == PULSE_TOO_SHORT;
            m_bError_PowerSupply_Fail = (nStatus & POWER_SUPPLY_FAIL) == POWER_SUPPLY_FAIL;
            m_bError_DutyCycle_TooHight = (nStatus & DUTYCYCLE_TOO_HIGH) == DUTYCYCLE_TOO_HIGH;
            m_bError_PowerSupply_Alarm = (nStatus & POWER_SUPPLY_ALARM) == POWER_SUPPLY_ALARM;
            m_bError_Critical_Error = (nStatus & CRITICAL_ERROR) == CRITICAL_ERROR;
            m_bError_Fiber_Interlock = (nStatus & FIBER_INTERLOCK) == FIBER_INTERLOCK;
            m_bError_Power_HighAverage = (nStatus & HIGH_AVERAGE_POWER) == HIGH_AVERAGE_POWER;
            m_bError_Temperature_Low = (nStatus & LOW_TEMPERATURE) == LOW_TEMPERATURE;

            m_bMode_Analog_Power_Control = (nStatus & ANALOG_POWER_CONTROL_ENABLE) == ANALOG_POWER_CONTROL_ENABLE;
            m_bMode_Pulse = (nStatus & PULSE_MODE) == PULSE_MODE;
            m_bMode_Modulation = (nStatus & MODULATION_ENABLE) == MODULATION_ENABLE;
            m_bMode_Gate = (nStatus & GATE_MODE) == GATE_MODE;
            m_bMode_HardWare_Emission_Control = (nStatus & HARDWARE_EMISSION_CONTROL_ENABLE) == HARDWARE_EMISSION_CONTROL_ENABLE;
            m_bMode_Panel_Lock = (nStatus & FRONT_DISPLAY_LOCK) == FRONT_DISPLAY_LOCK;
            m_bMode_KeySwitch_Remote = (nStatus & KEY_SWITCH_REMOTE) == KEY_SWITCH_REMOTE;
            m_bMode_Waveform = (nStatus & WAVEFORM_MODE) == WAVEFORM_MODE;
            m_bMode_HardWare_Aiming_Control = (nStatus & HARDWARE_AIMING_CONTROL_ENABLE) == HARDWARE_AIMING_CONTROL_ENABLE;
        }
		#endregion

		#region 외부인터페이스
		public bool Init(int nIndex)
		{
            m_nIndexOfSocket        = nIndex;

			if(false == m_InstanceOfSocket.Connect(ref m_nIndexOfSocket))
			{
				return false;
			}

			return true;
		}

        public void Execute()
        {
           // return;
            EquipmentState_.EQUIPMENT_STATE enEquipmentState = EquipmentState_.EquipmentState.GetInstance().GetState();
            if (enEquipmentState != EquipmentState_.EQUIPMENT_STATE.INITIALIZE)
            {
                switch (m_enState)
                {
                    case EN_EXCUTE_STATE.REQUEST_STA:
                        m_strReceiveDate = "";
                        m_InstanceOfSocket.send(m_nIndexOfSocket, Status + CR);
                        m_enState = EN_EXCUTE_STATE.WAIT_RECIEVE;
                        break;
                    case EN_EXCUTE_STATE.REQUEST_RCS:
                        m_strReceiveDate = "";
                        m_InstanceOfSocket.send(m_nIndexOfSocket, Power + CR);
                        m_enState = EN_EXCUTE_STATE.WAIT_RECIEVE;
                        break;
                    case EN_EXCUTE_STATE.WAIT_RECIEVE:
                        if (m_InstanceOfSocket.Receive(m_nIndexOfSocket, ref m_strReceiveDate))
                            m_enState = EN_EXCUTE_STATE.PARSHING_DATA;
                        if (m_InstanceOfSocket.GetState(m_nIndexOfSocket) != Config.ConfigSocket.EN_SOCKET_STATE.WAITING_RECEIVE)
                            m_enState = EN_EXCUTE_STATE.REQUEST_STA;
                        break;
                    case EN_EXCUTE_STATE.PARSHING_DATA:
                        string[] arData = m_strReceiveDate.Split(':');
                        if(arData[0] == Status)
                        {
                            uint nStatus;
                            if(uint.TryParse(arData[1], out nStatus))
                            {
                                ParseStatusBit(nStatus);
                                m_enState = EN_EXCUTE_STATE.REQUEST_RCS;
                            }
                        }
                        else if (arData[0] == Power)
                        {
                           // Console.WriteLine(m_strReceiveDate);
                            double.TryParse(arData[1], out m_dPower);
                            m_enState = EN_EXCUTE_STATE.REQUEST_STA;
                        }
                        
                        break;
                }
            }
        }

		#endregion

	

	}
}
