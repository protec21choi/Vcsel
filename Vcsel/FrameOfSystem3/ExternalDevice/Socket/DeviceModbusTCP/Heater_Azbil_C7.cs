using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.ExternalDevice.Heater;
using Define.DefineEnumProject.Modbus;
using Define.DefineEnumProject.Heater;


namespace FrameOfSystem3.ExternalDevice.Socket
{
    class Heater_Azbil_C7 : ModbusTCPDevice
    {
        #region Constutor
        public Heater_Azbil_C7(int SocketIndex, byte SlaveID, int[] arUsedChannel)
            : base(SocketIndex, SlaveID)
        {
            m_InstanceHeater = Heater.Heater.GetInstance();
            m_arUseChannel = arUsedChannel;
            SetNextChannel();
        }
        #endregion /Constructor

        #region Constant
        private const ushort Holding_Reg_CH1_PV = 100;
        private const ushort Holding_Reg_CH1_SV = 107;
        private const ushort Holding_Reg_CH1_Run = 103;
        private const ushort Holding_Reg_CH1_OFFSET = 110;//임시 주소

        private const ushort Holding_Reg_CH2_PV = 200;
        private const ushort Holding_Reg_CH2_SV = 207;
        private const ushort Holding_Reg_CH2_Run = 203;
        private const ushort Holding_Reg_CH2_OFFSET = 210;//임시 주소

        private const ushort Holding_Reg_CH3_PV = 300;
        private const ushort Holding_Reg_CH3_SV = 307;
        private const ushort Holding_Reg_CH3_Run = 303;
        private const ushort Holding_Reg_CH3_OFFSET = 310;//임시 주소

        private const ushort Holding_Reg_CH4_PV = 400;
        private const ushort Holding_Reg_CH4_SV = 407;
        private const ushort Holding_Reg_CH4_Run = 403;
        private const ushort Holding_Reg_CH4_OFFSET = 410;//임시 주소

        //PROFILE //임시 주소
        private const ushort Holding_Reg_CH1_RUN_PROFILE = 120; 

        private const ushort Holding_Reg_CH1_PROFILE = 1000; 
        private const ushort Holding_Reg_CH1_PROFILE_COUNT = Holding_Reg_CH1_PROFILE + 3;

        private const ushort Holding_Reg_CH1_PROFILE_SP_STEP_1 = Holding_Reg_CH1_PROFILE + 100;
        private const ushort Holding_Reg_CH1_PROFILE_TIME_STEP_1 = Holding_Reg_CH1_PROFILE + 101;

        private const ushort Holding_Reg_CH1_PROFILE_SP_STEP_2 = Holding_Reg_CH1_PROFILE + 110;
        private const ushort Holding_Reg_CH1_PROFILE_TIME_STEP_2 = Holding_Reg_CH1_PROFILE + 111;
        private const ushort Holding_Reg_CH1_PROFILE_SP_STEP_3 = Holding_Reg_CH1_PROFILE + 120;
        private const ushort Holding_Reg_CH1_PROFILE_TIME_STEP_3 = Holding_Reg_CH1_PROFILE + 121;
        private const ushort Holding_Reg_CH1_PROFILE_SP_STEP_4 = Holding_Reg_CH1_PROFILE + 130;
        private const ushort Holding_Reg_CH1_PROFILE_TIME_STEP_4 = Holding_Reg_CH1_PROFILE + 131;
        private const ushort Holding_Reg_CH1_PROFILE_SP_STEP_5 = Holding_Reg_CH1_PROFILE + 140;
        private const ushort Holding_Reg_CH1_PROFILE_TIME_STEP_5 = Holding_Reg_CH1_PROFILE + 141;

        
        private const ushort Holding_Reg_CH2_RUN_PROFILE = 220; //임시 주소

        private const ushort Holding_Reg_CH2_PROFILE = 2000;
        private const ushort Holding_Reg_CH2_PROFILE_COUNT = Holding_Reg_CH2_PROFILE + 3;

        private const ushort Holding_Reg_CH2_PROFILE_SP_STEP_1 = Holding_Reg_CH2_PROFILE + 100;
        private const ushort Holding_Reg_CH2_PROFILE_TIME_STEP_1 = Holding_Reg_CH2_PROFILE + 101;

        private const ushort Holding_Reg_CH2_PROFILE_SP_STEP_2 = Holding_Reg_CH2_PROFILE + 110;
        private const ushort Holding_Reg_CH2_PROFILE_TIME_STEP_2 = Holding_Reg_CH2_PROFILE + 111;
        private const ushort Holding_Reg_CH2_PROFILE_SP_STEP_3 = Holding_Reg_CH2_PROFILE + 120;
        private const ushort Holding_Reg_CH2_PROFILE_TIME_STEP_3 = Holding_Reg_CH2_PROFILE + 121;
        private const ushort Holding_Reg_CH2_PROFILE_SP_STEP_4 = Holding_Reg_CH2_PROFILE + 130;
        private const ushort Holding_Reg_CH2_PROFILE_TIME_STEP_4 = Holding_Reg_CH2_PROFILE + 131;
        private const ushort Holding_Reg_CH2_PROFILE_SP_STEP_5 = Holding_Reg_CH2_PROFILE + 140;
        private const ushort Holding_Reg_CH2_PROFILE_TIME_STEP_5 = Holding_Reg_CH2_PROFILE + 141;

        private const ushort Holding_Reg_CH3_RUN_PROFILE = 320; //임시 주소


        private const ushort Holding_Reg_CH3_PROFILE = 2000;
        private const ushort Holding_Reg_CH3_PROFILE_COUNT = Holding_Reg_CH3_PROFILE + 3;

        private const ushort Holding_Reg_CH3_PROFILE_SP_STEP_1 = Holding_Reg_CH3_PROFILE + 100;
        private const ushort Holding_Reg_CH3_PROFILE_TIME_STEP_1 = Holding_Reg_CH3_PROFILE + 101;

        private const ushort Holding_Reg_CH3_PROFILE_SP_STEP_2 = Holding_Reg_CH3_PROFILE + 110;
        private const ushort Holding_Reg_CH3_PROFILE_TIME_STEP_2 = Holding_Reg_CH3_PROFILE + 111;
        private const ushort Holding_Reg_CH3_PROFILE_SP_STEP_3 = Holding_Reg_CH3_PROFILE + 120;
        private const ushort Holding_Reg_CH3_PROFILE_TIME_STEP_3 = Holding_Reg_CH3_PROFILE + 121;
        private const ushort Holding_Reg_CH3_PROFILE_SP_STEP_4 = Holding_Reg_CH3_PROFILE + 130;
        private const ushort Holding_Reg_CH3_PROFILE_TIME_STEP_4 = Holding_Reg_CH3_PROFILE + 131;
        private const ushort Holding_Reg_CH3_PROFILE_SP_STEP_5 = Holding_Reg_CH3_PROFILE + 140;
        private const ushort Holding_Reg_CH3_PROFILE_TIME_STEP_5 = Holding_Reg_CH3_PROFILE + 141;

        private const ushort Holding_Reg_CH4_RUN_PROFILE = 420; //임시 주소

        private const ushort Holding_Reg_CH4_PROFILE = 2000;
        private const ushort Holding_Reg_CH4_PROFILE_COUNT = Holding_Reg_CH4_PROFILE + 3;

        private const ushort Holding_Reg_CH4_PROFILE_SP_STEP_1 = Holding_Reg_CH4_PROFILE + 100;
        private const ushort Holding_Reg_CH4_PROFILE_TIME_STEP_1 = Holding_Reg_CH4_PROFILE + 101;

        private const ushort Holding_Reg_CH4_PROFILE_SP_STEP_2 = Holding_Reg_CH4_PROFILE + 110;
        private const ushort Holding_Reg_CH4_PROFILE_TIME_STEP_2 = Holding_Reg_CH4_PROFILE + 111;
        private const ushort Holding_Reg_CH4_PROFILE_SP_STEP_3 = Holding_Reg_CH4_PROFILE + 120;
        private const ushort Holding_Reg_CH4_PROFILE_TIME_STEP_3 = Holding_Reg_CH4_PROFILE + 121;
        private const ushort Holding_Reg_CH4_PROFILE_SP_STEP_4 = Holding_Reg_CH4_PROFILE + 130;
        private const ushort Holding_Reg_CH4_PROFILE_TIME_STEP_4 = Holding_Reg_CH4_PROFILE + 131;
        private const ushort Holding_Reg_CH4_PROFILE_SP_STEP_5 = Holding_Reg_CH4_PROFILE + 140;
        private const ushort Holding_Reg_CH4_PROFILE_TIME_STEP_5 = Holding_Reg_CH4_PROFILE + 141;
        #endregion

        #region Internal Instance
        private Heater.Heater m_InstanceHeater = null;
        #endregion /Intetnal Instance

        #region Internal Variable
        private int[] m_arUseChannel = new int[0];
        private int m_nCurrentChannelIndex = 0;
        private int m_nCurrentChannel = 1;
        #endregion /Intetnal Variable

        #region External Instance

        #region Make Message Foramt
        public override void GetSendCommand(ref byte[] data)
        {
            try
            {
                byte[] byteCmd = new byte[8];
                ushort Address = 1;
                switch (m_InstanceHeater.GetSocketCommand(nSocketIndex, m_nCurrentChannel))
                {
                    case EN_HEATER_COMMAND.RUN:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_Run;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_Run;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_Run;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_Run;
                                break;
                        }
                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, 0);
                        break;
                    case EN_HEATER_COMMAND.STOP:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_Run;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_Run;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_Run;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_Run;
                                break;
                        }
                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, 1);
                        break;
                    case EN_HEATER_COMMAND.GET_TEMP:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PV;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PV;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PV;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PV;
                                break;
                        }
                        byteCmd = GetReadCommand(Read_Holding_Register, Address, 1);
                        break;
                    case EN_HEATER_COMMAND.SET_TEMP:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_SV;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_SV;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_SV;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_SV;
                                break;
                        }
                        double dTemp = m_InstanceHeater.GetSocketTargetTemp(nSocketIndex, m_nCurrentChannel);
                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, (ushort)(dTemp * 10));
                        break;

                    case EN_HEATER_COMMAND.GET_RUN_STATUS:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_Run;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_Run;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_Run;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_Run;
                                break;
                        }
                        byteCmd = GetReadCommand(Read_Holding_Register, Address, 1);
                        break;

                    #region Profile

                    case EN_HEATER_COMMAND.RUN_PROFILE:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_RUN_PROFILE;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_RUN_PROFILE;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_RUN_PROFILE;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_RUN_PROFILE;
                                break;
                        }
                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, 0);
                        break;

                    case EN_HEATER_COMMAND.SET_PROFILE_USE_COUNT:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_COUNT;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_COUNT;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_COUNT;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_COUNT;
                                break;
                        }
                        ushort nCount = (ushort)m_InstanceHeater.GetSocketProfileCount(nSocketIndex, m_nCurrentChannel);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nCount);
                        break;

                    case EN_HEATER_COMMAND.SET_PROFILE_TEMP_STEP_1:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_SP_STEP_1;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_SP_STEP_1;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_SP_STEP_1;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_SP_STEP_1;
                                break;
                        }
                        ushort nProfileSV1 = (ushort)m_InstanceHeater.GetSocketProfileTemp(nSocketIndex, m_nCurrentChannel, 0);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nProfileSV1);
                        break;


                    case EN_HEATER_COMMAND.SET_PROFILE_TIME_STEP_1:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_TIME_STEP_1;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_TIME_STEP_1;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_TIME_STEP_1;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_TIME_STEP_1;
                                break;
                        }
                        ushort nProfileTime1 = (ushort)m_InstanceHeater.GetSocketProfileTime(nSocketIndex, m_nCurrentChannel, 0);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nProfileTime1);
                        break;

                    case EN_HEATER_COMMAND.SET_PROFILE_TEMP_STEP_2:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_SP_STEP_2;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_SP_STEP_2;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_SP_STEP_2;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_SP_STEP_2;
                                break;
                        }
                        ushort nProfileSV2 = (ushort)m_InstanceHeater.GetSocketProfileTemp(nSocketIndex, m_nCurrentChannel, 1);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nProfileSV2);
                        break;


                    case EN_HEATER_COMMAND.SET_PROFILE_TIME_STEP_2:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_TIME_STEP_2;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_TIME_STEP_2;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_TIME_STEP_2;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_TIME_STEP_2;
                                break;
                        }
                        ushort nProfileTime2 = (ushort)m_InstanceHeater.GetSocketProfileTime(nSocketIndex, m_nCurrentChannel, 1);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nProfileTime2);
                        break;


                    case EN_HEATER_COMMAND.SET_PROFILE_TEMP_STEP_3:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_SP_STEP_3;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_SP_STEP_3;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_SP_STEP_3;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_SP_STEP_3;
                                break;
                        }
                        ushort nProfileSV3 = (ushort)m_InstanceHeater.GetSocketProfileTemp(nSocketIndex, m_nCurrentChannel, 2);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nProfileSV3);
                        break;


                    case EN_HEATER_COMMAND.SET_PROFILE_TIME_STEP_3:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_TIME_STEP_3;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_TIME_STEP_3;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_TIME_STEP_3;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_TIME_STEP_3;
                                break;
                        }
                        ushort nProfileTime3 = (ushort)m_InstanceHeater.GetSocketProfileTime(nSocketIndex, m_nCurrentChannel, 2);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nProfileTime3);
                        break;

                    case EN_HEATER_COMMAND.SET_PROFILE_TEMP_STEP_4:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_SP_STEP_4;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_SP_STEP_4;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_SP_STEP_4;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_SP_STEP_4;
                                break;
                        }
                        ushort nProfileSV4 = (ushort)m_InstanceHeater.GetSocketProfileTemp(nSocketIndex, m_nCurrentChannel, 3);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nProfileSV4);
                        break;


                    case EN_HEATER_COMMAND.SET_PROFILE_TIME_STEP_4:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_TIME_STEP_4;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_TIME_STEP_4;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_TIME_STEP_4;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_TIME_STEP_4;
                                break;
                        }
                        ushort nProfileTime4 = (ushort)m_InstanceHeater.GetSocketProfileTime(nSocketIndex, m_nCurrentChannel, 3);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nProfileTime4);
                        break;

                    case EN_HEATER_COMMAND.SET_PROFILE_TEMP_STEP_5:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_SP_STEP_5;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_SP_STEP_5;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_SP_STEP_5;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_SP_STEP_5;
                                break;
                        }
                        ushort nProfileSV5 = (ushort)m_InstanceHeater.GetSocketProfileTemp(nSocketIndex, m_nCurrentChannel, 4);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nProfileSV5);
                        break;


                    case EN_HEATER_COMMAND.SET_PROFILE_TIME_STEP_5:
                        switch (m_nCurrentChannel)
                        {
                            default:
                                Address = Holding_Reg_CH1_PROFILE_TIME_STEP_5;
                                break;
                            case 2:
                                Address = Holding_Reg_CH2_PROFILE_TIME_STEP_5;
                                break;
                            case 3:
                                Address = Holding_Reg_CH3_PROFILE_TIME_STEP_5;
                                break;
                            case 4:
                                Address = Holding_Reg_CH4_PROFILE_TIME_STEP_5;
                                break;
                        }
                        ushort nProfileTime5 = (ushort)m_InstanceHeater.GetSocketProfileTime(nSocketIndex, m_nCurrentChannel, 4);

                        byteCmd = GetWriteSingleCommand(Write_Single_Register, Address, nProfileTime5);
                        break;
                    #endregion /Profile

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
            byte[] ArrayLittleEndian;
            switch (m_nFunctionCode)
            {
                case Read_Holding_Register:         // Current temp
                    ArrayLittleEndian = data.Skip(9).Take(2).Reverse().ToArray();
                    double dtemperature;
                    switch (m_nRequestAddress)
                    {
                        case Holding_Reg_CH1_PV:
                            dtemperature = (double)BitConverter.ToUInt16(ArrayLittleEndian, 0) / 10;
                            m_InstanceHeater.SetSocketTempMeasurdValue(nSocketIndex, 1, dtemperature);
                            break;

                        case Holding_Reg_CH1_Run:
                            m_InstanceHeater.SetSocketRunStatus(nSocketIndex, 1, BitConverter.ToInt16(ArrayLittleEndian, 0) == 0);
                            break;

                        case Holding_Reg_CH2_PV:
                            dtemperature = (double)BitConverter.ToUInt16(ArrayLittleEndian, 0) / 10;
                            m_InstanceHeater.SetSocketTempMeasurdValue(nSocketIndex, 2, dtemperature);
                            break;

                        case Holding_Reg_CH2_Run:
                            m_InstanceHeater.SetSocketRunStatus(nSocketIndex, 2, BitConverter.ToInt16(ArrayLittleEndian, 0) == 0);
                            break;


                        case Holding_Reg_CH3_PV:
                            dtemperature = (double)BitConverter.ToUInt16(ArrayLittleEndian, 0) / 10;
                            m_InstanceHeater.SetSocketTempMeasurdValue(nSocketIndex, 3, dtemperature);
                            break;

                        case Holding_Reg_CH3_Run:
                            m_InstanceHeater.SetSocketRunStatus(nSocketIndex, 3, BitConverter.ToInt16(ArrayLittleEndian, 0) == 0);
                            break;


                        case Holding_Reg_CH4_PV:
                            dtemperature = (double)BitConverter.ToUInt16(ArrayLittleEndian, 0) / 10;
                            m_InstanceHeater.SetSocketTempMeasurdValue(nSocketIndex, 4, dtemperature);
                            break;

                        case Holding_Reg_CH4_Run:
                            m_InstanceHeater.SetSocketRunStatus(nSocketIndex, 4, BitConverter.ToInt16(ArrayLittleEndian, 0) == 0);
                            break;
                    }
                    break;
                case Write_Single_Register:         // Current temp

                    break;

                default:
                    break;
            }
            SetNextChannel();
            enStatus = EN_MODBUS_STATUS.SETTING_COMMAND;
            return true;
        }

        private void SetNextChannel()
        {
            m_nCurrentChannelIndex++;

            if (m_nCurrentChannelIndex >= m_arUseChannel.Length)
                m_nCurrentChannelIndex = 0;

            m_nCurrentChannel = m_arUseChannel[m_nCurrentChannelIndex];
        }
        #endregion

        #endregion /External Instance
    }
}
