using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.ExternalDevice.Heater;
using Define.DefineEnumProject.Modbus;
using Define.DefineEnumProject.Heater;


namespace FrameOfSystem3.ExternalDevice.Serial
{
    class Heater_TX4S : ModbusRTUDevice
    {
        #region Constutor
        public Heater_TX4S(int SerialIndex ,byte SlaveID) : base(SerialIndex ,SlaveID)
        {
            m_InstanceHeater = Heater.Heater.GetInstance();
        }
        #endregion /Constructor

        #region Constant

        private const ushort Coil_Run = 0;

        private const ushort Input_Reg_PV = 1000;

        private const ushort Holding_Reg_SV = 0;

        private const ushort Holding_Reg_Offset = 102;
        #endregion

        #region Internal Instance
        private Heater.Heater m_InstanceHeater = null;
        #endregion /Intetnal Instance

        #region External Instance

        #region Make Message Foramt
        public override void GetSendCommand(ref byte[] data)
        {
            try
            {
                byte[] byteCmd = new byte[8];

                switch (m_InstanceHeater.GetSerialCommand(nSerialIndex, bSlaveID))
                {
                    case EN_HEATER_COMMAND.RUN: //0 : run 
                        byteCmd = GetWriteSingleCommand(Write_Single_Coil, Coil_Run, false);
                        break;
                    case EN_HEATER_COMMAND.STOP: //1 : stop
                        byteCmd = GetWriteSingleCommand(Write_Single_Coil, Coil_Run, true);
                        break;
                    case EN_HEATER_COMMAND.GET_TEMP:
                        byteCmd = GetReadCommand(Read_Input_Register, Input_Reg_PV, 1);
                        break;
                    case EN_HEATER_COMMAND.SET_TEMP:
                        double dTemp = m_InstanceHeater.GetSerialTargetTemp(nSerialIndex, bSlaveID);
                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Holding_Reg_SV, (ushort)dTemp);
                        break;
                    case EN_HEATER_COMMAND.SET_OFFSET:
                        double dOffset = m_InstanceHeater.GetSerialOffsetTemp(nSerialIndex, bSlaveID);
                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Holding_Reg_Offset, (ushort)dOffset);
                        break;

                    case EN_HEATER_COMMAND.GET_RUN_STATUS:
                        byteCmd = GetReadCommand(Read_Coil, Coil_Run, 1);
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
        public override bool ParshingData(byte[] data)
        {
            if (CheckRecieveData(data))
            {
                switch (m_nFunctionCode)
                {
                    case Read_Coil:         
                        switch (m_nRequestAddress)
                        {
                            case Coil_Run:
                                bool bRunStatus = !Convert.ToBoolean(data[3] & 0x01);
                                m_InstanceHeater.SetSerialRunStatus(nSerialIndex, bSlaveID, bRunStatus);
                                break;
                        }
                        break;

                    case Read_Input_Register:         // Current temp
                        switch (m_nRequestAddress)
                        {
                            case Input_Reg_PV:
                                int Temp = BitConverter.ToInt16(data.Skip(3).Take(2).Reverse().ToArray(), 0);
                                m_InstanceHeater.SetSerialTempMeasurdValue(nSerialIndex, bSlaveID, Temp);
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
        #endregion

        #endregion /External Instance
    }
}
