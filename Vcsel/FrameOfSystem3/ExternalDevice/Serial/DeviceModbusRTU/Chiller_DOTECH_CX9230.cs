using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumProject.Modbus;

namespace FrameOfSystem3.ExternalDevice.Serial
{
    public enum EN_CHILLER_COMMAND
    {
        DEFAULT,
        RUN_STATUS,
        ALARM_CODE,
        GET_TEMP,
        SET_TEMP,
        RUN,
        STOP
    }

    public enum EN_CHILLER_ALARM
    {
        // 4
        System_Alarm,                               // 0
        Control_Temperature_Sensor_Alarm,           // 1
        Sub_Temperature_Sensor_Alarm,               // 2
        Discharge_Temperature_Sensor_Alarm,         // 3
        Low_Pressure_Sensor_Alarm,                  // 4
        High_Pressure_Sensor_Alarm,                 // 5
        Comp_Alarm,                                 // 6
        Capacitor_Alarm,                            // 7

        // 3
        Reverse_Phase_Detection_Alarm,              // 0
        Low_Water_Level_Alarm,                      // 1
        Flow_Detection_Alarm,                       // 2
        Pump_Alarm,                                 // 3
        Low_Pressure_State_Alarm,                   // 4
        High_Pressure_State_Alarm,                  // 5
        Freezing_Prevention_Alarm,                  // 6

        // 6                                     
        Exit_Low_Temperature_Alarm,                 // 0
        Exit_High_Temperature_Alarm,                // 1
        Discharge_Low_Temperature_Alarm,            // 2
        Discharge_High_Temperature_Alarm,           // 3

        // 8
        Sensor_Device_Check_Alarm,                  // 0
        Safety_Device_Check_Alarm,                  // 1
        Automatic_Control_Device_Check_Alarm,       // 2
        Compressor_Device_Check_Alarm,              // 3
        Freeze_Oil_Exchange_Alarm,                  // 4
        Overhaul_Alarm,                              // 5

        None
    }

    class ChillerCX9230Modbus : ModbusRTUDevice
    {
            #region Constutor
        public ChillerCX9230Modbus(int SerialIndex, byte SlaveID)
            : base(SerialIndex, SlaveID)
        {
            m_InstanceChiller = Chiller.GetInstance();
        }
        #endregion /Constructor

        #region Address
        #region Coil
        private const ushort Coil_RunStatus = 0;
        private const ushort Coil_RunStart = 6;
        private const ushort Coil_RunStop = 7;
        #endregion

        #region Input Register
        private const ushort Input_Reg_B2Temp = 16;
        private const ushort Input_Reg_AlarmCode = 2;
        #endregion
        #endregion

        #region Internal Instance
        private Chiller m_InstanceChiller = null;
        #endregion /Intetnal Instance

        public override bool ParshingData(byte[] data)
        {
            if (CheckRecieveData(data))
            {
                switch (m_nFunctionCode)
                {
                    case Read_Coil:         //FuntionCode = 1 (ReadCoil)
                        switch (m_nRequestAddress)
                        {
                            case Coil_RunStatus:
                                m_InstanceChiller.bRunStatus = Convert.ToBoolean(data[3] & 0x01);
                                break;
                        }
                        break;
                    case Read_Input_Register:         // Current temp
                        switch (m_nRequestAddress)
                        {
                            case Input_Reg_B2Temp: //B2 Temp
                                //m_InstanceChiller.dCurTmp = BitConverter.ToInt16(data, 3) / 10;
                                m_InstanceChiller.dCurTmp = (double)data[4] / 10;
                                break;

                            case Input_Reg_AlarmCode: //Alarm
                                m_InstanceChiller.enAlarm = Check_Alarm(data);
                                break;
                        }
                        break;

                    default:
                        break;
                }
                enStatus = EN_MODBUS_STATUS.SETTING_COMMAND;
                return true;
            }
            return false;
        }
        public override void GetSendCommand(ref byte[] data)
        {
            try
            {
                byte[] byteCmd = new byte[8];

                switch (m_InstanceChiller.enCommand)
                {
                    case EN_CHILLER_COMMAND.RUN_STATUS:
                        byteCmd = GetReadCommand(Read_Coil, 0, 1);
                        m_InstanceChiller.enCommand = EN_CHILLER_COMMAND.GET_TEMP;
                        break;
                    case EN_CHILLER_COMMAND.GET_TEMP:
                        byteCmd = GetReadCommand(Read_Input_Register, Input_Reg_B2Temp, 1);
                        m_InstanceChiller.enCommand = EN_CHILLER_COMMAND.ALARM_CODE;
                        break;
                    case EN_CHILLER_COMMAND.SET_TEMP:
                        break;
                    case EN_CHILLER_COMMAND.ALARM_CODE:
                        byteCmd = GetReadCommand(Read_Input_Register, Input_Reg_AlarmCode, 3);
                        m_InstanceChiller.enCommand = EN_CHILLER_COMMAND.RUN_STATUS;
                        break;
                    case EN_CHILLER_COMMAND.RUN:
                        byteCmd = GetWriteSingleCommand(Write_Single_Coil, Coil_RunStart, true);
                        m_InstanceChiller.enCommand = EN_CHILLER_COMMAND.RUN_STATUS;
                        break;
                    case EN_CHILLER_COMMAND.STOP:
                        byteCmd = GetWriteSingleCommand(Write_Single_Coil, Coil_RunStop, true);
                        m_InstanceChiller.enCommand = EN_CHILLER_COMMAND.RUN_STATUS;
                        break;
                    default:
                        break;
                }
                data = byteCmd;
               
            }
            catch
            {
            }

        }

        private EN_CHILLER_ALARM Check_Alarm(byte[] data)
        {
            for (int i = 3; i < 8; i++)
            {
                if (data[i] != 0)
                {
                    byte bCompare = 1;
                    switch (i)
                    {
                        case 3:
                            for (int j = 0; j < 7; j++)
                            {
                                if ((data[i] & bCompare) != 0)
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            return EN_CHILLER_ALARM.Reverse_Phase_Detection_Alarm;
                                        case 1:
                                            return EN_CHILLER_ALARM.Low_Water_Level_Alarm;
                                        case 2:
                                            return EN_CHILLER_ALARM.Flow_Detection_Alarm;
                                        case 3:
                                            return EN_CHILLER_ALARM.Pump_Alarm;
                                        case 4:
                                            return EN_CHILLER_ALARM.Low_Pressure_State_Alarm;
                                        case 5:
                                            return EN_CHILLER_ALARM.High_Pressure_State_Alarm;
                                        case 6:
                                            return EN_CHILLER_ALARM.Freezing_Prevention_Alarm;
                                    }
                                }
                                bCompare = (byte)(bCompare << 1);
                            }
                            break;
                        case 4:
                            for (int j = 0; j < 8; j++)
                            {
                                if ((data[i] & bCompare) != 0)
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            return EN_CHILLER_ALARM.System_Alarm;
                                        case 1:
                                            return EN_CHILLER_ALARM.Control_Temperature_Sensor_Alarm;
                                        case 2:
                                            return EN_CHILLER_ALARM.Sub_Temperature_Sensor_Alarm;
                                        case 3:
                                            return EN_CHILLER_ALARM.Discharge_Temperature_Sensor_Alarm;
                                        case 4:
                                            return EN_CHILLER_ALARM.Low_Pressure_Sensor_Alarm;
                                        case 5:
                                            return EN_CHILLER_ALARM.High_Pressure_Sensor_Alarm;
                                        case 6:
                                            return EN_CHILLER_ALARM.Comp_Alarm;
                                        case 7:
                                            return EN_CHILLER_ALARM.Capacitor_Alarm;
                                    }
                                }
                                bCompare = (byte)(bCompare << 1);
                            }

                            break;
                        case 6:
                            for (int j = 0; j < 4; j++)
                            {
                                if ((data[i] & bCompare) != 0)
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            return EN_CHILLER_ALARM.Exit_Low_Temperature_Alarm;
                                        case 1:
                                            return EN_CHILLER_ALARM.Exit_High_Temperature_Alarm;
                                        case 2:
                                            return EN_CHILLER_ALARM.Discharge_Low_Temperature_Alarm;
                                        case 3:
                                            return EN_CHILLER_ALARM.Discharge_High_Temperature_Alarm;
                                    }
                                }
                                bCompare = (byte)(bCompare << 1);
                            }
                            break;
                        case 8:
                            for (int j = 0; j < 6; j++)
                            {
                                if ((data[i] & bCompare) != 0)
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            return EN_CHILLER_ALARM.Sensor_Device_Check_Alarm;
                                        case 1:
                                            return EN_CHILLER_ALARM.Safety_Device_Check_Alarm;
                                        case 2:
                                            return EN_CHILLER_ALARM.Automatic_Control_Device_Check_Alarm;
                                        case 3:
                                            return EN_CHILLER_ALARM.Compressor_Device_Check_Alarm;
                                        case 4:
                                            return EN_CHILLER_ALARM.Freeze_Oil_Exchange_Alarm;
                                        case 5:
                                            return EN_CHILLER_ALARM.Overhaul_Alarm;
                                    }
                                }
                                bCompare = (byte)(bCompare << 1);
                            }
                            break;
                    }
                }
            }
            return EN_CHILLER_ALARM.None;
        }
    }

    public class Chiller
    {
        #region 변수
        private bool m_bRunStatus = false;
        private double m_dCurTmp = 0;
        private ConcurrentQueue<EN_CHILLER_COMMAND> m_QueueCommand;
        private EN_CHILLER_COMMAND m_enCommand = EN_CHILLER_COMMAND.RUN_STATUS;
        private EN_CHILLER_ALARM m_enAlarm = EN_CHILLER_ALARM.None;
        #endregion

        #region 속성
        public bool bRunStatus { set { m_bRunStatus = value; } get { return m_bRunStatus; } }
        public double dCurTmp { set { m_dCurTmp = value; } get { return m_dCurTmp; } }
        public EN_CHILLER_COMMAND enCommand
        {
            set
            {
                m_enCommand = value;
            } 
            get 
            {
                if (!m_QueueCommand.IsEmpty)
                {
                    m_QueueCommand.TryDequeue(out m_enCommand);
                }
                return m_enCommand; 
            } 
        }
        public EN_CHILLER_ALARM enAlarm { set { m_enAlarm = value; } get { return m_enAlarm; } }
        #endregion

        #region 싱글톤
        private Chiller()
        {
            m_QueueCommand = new ConcurrentQueue<EN_CHILLER_COMMAND>();
        }
        private static Chiller _Instance = null;
        public static Chiller GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Chiller();
            }
            return _Instance;
        }
        
        public void RunChiller()
        {
            m_QueueCommand.Enqueue(EN_CHILLER_COMMAND.RUN);
        }

        public void StopChiller()
        {
            m_QueueCommand.Enqueue(EN_CHILLER_COMMAND.STOP);
        }
        #endregion
    }
}
