using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TickCounter_;
using FrameOfSystem3.ExternalDevice.Heater;

namespace FrameOfSystem3.ExternalDevice.Serial
{
    public class Heater_RKC
    {
        private enum EN_HEATER_STATUS
        {
            SEND_COMMAND,

            WAITING_READ,
        }

        #region 변수
         private int m_nInstanceIndex = 0;
        private int m_nSerialIndex = 0;
        private Config.ConfigSerial m_Serial = Config.ConfigSerial.GetInstance();

        private int[] m_arChannel = new int[0];
        private EN_HEATER_STATUS m_enStatus = EN_HEATER_STATUS.SEND_COMMAND;

        private EN_HEATER_COMMAND m_enLastCommand;

        byte[] EOT = new byte[1];
        byte[] STX = new byte[1];
        byte[] ETX = new byte[1];
        byte[] ENQ = new byte[1];
        byte[] ACK = new byte[1];
        byte[] NAK = new byte[1];
        byte[] ETB = new byte[1];
        byte[] BCC = new byte[1];

        private TickCounter m_tRecieveTimeOut = new TickCounter();
        private TickCounter m_tRecycle = new TickCounter();
        private bool m_bRun_State = false;
        private string m_strDataParshing = "";

        private int m_nObjectCode;

        private Heater.Heater m_InstanceHeater = null;
        #endregion

        #region 싱글톤
        private Heater_RKC() { }
        private static Heater_RKC _Instance = null;
        public static Heater_RKC GetInstance() 
        {
            if (_Instance == null)
            {
                _Instance = new Heater_RKC();
            }
            return _Instance;
        }
        #endregion

        #region 외부 인터페이스
        #region 초기화 및 종료
        public bool Init(int nSerialIndex, int[] arChannel)
        {
            EOT[0] = 0x04;
            STX[0] = 0x02;
            ETX[0] = 0x03;
            ENQ[0] = 0x05;
            ACK[0] = 0x06;
            NAK[0] = 0x15;
            ETB[0] = 0x17;

            m_nSerialIndex = nSerialIndex;


            m_nObjectCode = m_nSerialIndex * 100;

            m_enStatus = EN_HEATER_STATUS.SEND_COMMAND;

            m_tRecycle.SetTickCount(1000);

            m_arChannel = arChannel;

            m_InstanceHeater = Heater.Heater.GetInstance();
            
            if (m_Serial.Open(m_nSerialIndex) == false)
                return false;


            return true;
        }
        public void Close()
        {
            m_Serial.Close(m_nSerialIndex);
        }
        public bool Connect()
        {
            if (m_Serial.Open(m_nSerialIndex) == false)
                return false;
            return true;
        }
        #endregion

        #region 주기 호출 함수
        public bool IsOpened()
        {
            return m_Serial.IsOpen(m_nSerialIndex);
        }
        public void Execute()
        {
            if (!m_tRecycle.IsTickOver(false))
                return;


            if (m_Serial.IsOpen(m_nSerialIndex) == false)
                return;

            switch (m_enStatus)
            {

                case EN_HEATER_STATUS.SEND_COMMAND:
                    EN_HEATER_COMMAND eCommand = m_InstanceHeater.GetSerialCommand(m_nSerialIndex);
                    m_enLastCommand = eCommand;
                    WriteCmd(eCommand);
                    break;

                case EN_HEATER_STATUS.WAITING_READ:
                    if (DataReceived())
                    {
                        //                            switch (m_enLastCommand)
                        //                            {
                        //                                 case EN_HEATER_COMMAND.GET_TEMP:
                        //                                     m_InstanceHeater.SetSerialCommand(m_nSerialIndex, EN_HEATER_COMMAND.GET_RUN_STATUS);
                        //                                     break;
                        //                            }

                        // 2019.06.11 by junho [MOD] Change Heater Time out 10000 -> 2000
                        m_tRecieveTimeOut.SetTickCount(2000);
                        m_tRecycle.SetTickCount(100);
                    }
                    else
                    {
                        if (m_tRecieveTimeOut.IsTickOver(false))
                        {
                            m_enStatus = EN_HEATER_STATUS.SEND_COMMAND;
                        }
                    }
                    break;
            }
        }
        #endregion

        #endregion

        #region 내부 인터페이스
        #region 통신 인터페이스
        private bool DataReceived()
        {
            bool bReturn = false;
            string strResult = "";
            if (m_Serial.Read(m_nSerialIndex, ref strResult))
            {
                byte[] arResult = Encoding.UTF8.GetBytes(strResult);
                for (int iTemp = 0; iTemp < arResult.Length; iTemp++)
                {
                    if (arResult[iTemp] == ETX[0])                  //ETX일때 EOT를 출력하자. 보통 값일을때 이것들 다음에 BCC가 있다
                    {
                        m_Serial.Write(m_nSerialIndex, System.Text.Encoding.Default.GetString(EOT));
                        bReturn = true;
                    }
                    else if (arResult[iTemp] == ETB[0])              // 8 Channel 데이터
                    {
                        m_Serial.Write(m_nSerialIndex, System.Text.Encoding.Default.GetString(ACK));
                        //bReturn = true;
                    }
                    else if (arResult[iTemp] == NAK[0])              // Error 메세지
                    {
                        m_Serial.Write(m_nSerialIndex, System.Text.Encoding.Default.GetString(EOT));
                    }
                }

                if (bReturn)
                {
                    m_strDataParshing += strResult;
                    Packet_Analysis(m_strDataParshing);
                    m_strDataParshing = "";
                }
                else
                {
                    //if (strResult.Equals("-") == false)
                        m_strDataParshing += strResult;
                }
            }

            return bReturn;
        }
        private bool WriteCmd(EN_HEATER_COMMAND cmd)
        {
            try
            {
                string strData = System.Text.Encoding.Default.GetString(EOT);
                strData += "00";

                // Command
                switch (cmd)
                {
                    case EN_HEATER_COMMAND.RUN:
                        strData += System.Text.Encoding.Default.GetString(STX);
                        strData += "SR";
                        strData += "1";
                        strData += System.Text.Encoding.Default.GetString(ETX);
                        break;
                    case EN_HEATER_COMMAND.STOP:
                       

                        strData += System.Text.Encoding.Default.GetString(STX);
                        strData += "SR";
                        strData += "0";
                        strData += System.Text.Encoding.Default.GetString(ETX);
                        break;
                    case EN_HEATER_COMMAND.SET_TEMP:
                        strData += System.Text.Encoding.Default.GetString(STX);
                        strData += "S1";

                        foreach (int nCh in m_arChannel)
                        {
                               double dTemp = m_InstanceHeater.GetSerialTargetTemp(m_nSerialIndex, nCh);

                                strData += nCh.ToString("000 ");
                                strData += dTemp.ToString("0000000");
                                strData += ",";
                            
                        }

                        strData = strData.Remove(strData.Length - 1, 1);
                        strData += System.Text.Encoding.Default.GetString(ETX);
                        break;
                    case EN_HEATER_COMMAND.GET_SETTING_TEMP:
                        strData += "S1";
                        strData += System.Text.Encoding.Default.GetString(ENQ);
                        break;
                    case EN_HEATER_COMMAND.SET_OFFSET:
                        strData += System.Text.Encoding.Default.GetString(STX);
                        strData += "PB"; //Cmd

                        foreach (int nCh in m_arChannel)
                        {
                               double dOffset = m_InstanceHeater.GetSerialOffsetTemp(m_nSerialIndex, nCh);

                                strData += nCh.ToString("000 ");
                                strData += dOffset >= 0 ? dOffset.ToString("0000000") : dOffset.ToString("000000");
                                strData += ",";
                            
                        }

                        strData = strData.Remove(strData.Length - 1, 1);
                        strData += System.Text.Encoding.Default.GetString(ETX);
                        break;
                    case EN_HEATER_COMMAND.GET_OFFSET:
                        strData += "PB";
                        strData += System.Text.Encoding.Default.GetString(ENQ);
                        break;
                    case EN_HEATER_COMMAND.GET_TEMP
:
                        strData += "M1";
                        strData += System.Text.Encoding.Default.GetString(ENQ);
                        break;
                    case EN_HEATER_COMMAND.GET_RUN_STATUS:
                        strData += "SR";
                        strData += System.Text.Encoding.Default.GetString(ENQ);
                        break;
                }

                if (cmd.ToString().Contains("SET") == true
                    || cmd == EN_HEATER_COMMAND.RUN
                    || cmd == EN_HEATER_COMMAND.STOP)
                {
                    BCC[0] = 0;
                    string sTemp = strData.Remove(0, 4);
                    for (int i = 0; i < sTemp.Length; i++)
                        BCC[0] ^= Convert.ToByte(sTemp[i]);
                    strData += System.Text.Encoding.Default.GetString(BCC);
                }
                m_Serial.Write(m_nSerialIndex, strData);

                m_enStatus = EN_HEATER_STATUS.WAITING_READ;

                // 2019.06.11 by junho [MOD] Change Heater Time out 10000 -> 2000
                m_tRecieveTimeOut.SetTickCount(2000);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 데이터 정리
        private bool Packet_Analysis(string rxPacket)
        {
            if (rxPacket == null)
                return false;

            string sID = null;
            string[] strPacketSplit;
            string value;

            try
            {
               
                  rxPacket = rxPacket.Remove(0, 2);                       // STX 제거
                  rxPacket = rxPacket.Remove(rxPacket.Length - 1, 1);     // ETX & BCC 제거
                  if (rxPacket.Length > 2)
                  {
                      sID = rxPacket.Remove(2);                               // ID
                      rxPacket = rxPacket.Remove(0, 2);                       // ID 제거
                  }
                
                switch (sID)
                {
                    case "10": // Measured value 
                    case "M1": // Measured value 
                        strPacketSplit = rxPacket.Split(',');

                        foreach (int nCh in m_arChannel)
                        {
                                value = strPacketSplit[nCh - 1];
                                value = value.Substring(value.Length - 7, 7);
                            double dTemp = 0;
                            double.TryParse(value, out dTemp);
                        
                                m_InstanceHeater.SetSerialTempMeasurdValue(m_nSerialIndex, nCh, dTemp);
                            
                        }
                        break;
                    case "MS": // Set_Value_Mon 티칭 값 모니터
                        strPacketSplit = rxPacket.Split(',');
                        break;
                    case "R0": // HTC On Off
                         //m_bRun_State = false;
                            foreach (int nCh in m_arChannel)
                        {
                        m_InstanceHeater.SetSerialRunStatus(m_nSerialIndex, nCh, false);
                            }
                        break;
                    case "R1": // HTC On Off
                        //m_bRun_State = true;
                             foreach (int nCh in m_arChannel)
                        {
                        m_InstanceHeater.SetSerialRunStatus(m_nSerialIndex, nCh, true);
                            }
                        break;
                    case "SR": // HTC On Off
                        if (rxPacket.Length > 1) rxPacket = rxPacket.Remove(1);
                        if (rxPacket == "1")
                        {
                            //m_bRun_State = true;
                                 foreach (int nCh in m_arChannel)
                        {
                        m_InstanceHeater.SetSerialRunStatus(m_nSerialIndex, nCh, true);
                            }
                        }
                        else
                        {
                            //m_bRun_State = false;
                              foreach (int nCh in m_arChannel)
                        {
                        m_InstanceHeater.SetSerialRunStatus(m_nSerialIndex, nCh, false);
                            }
                        }
                        break;
                    case "ER": // HTC Error
                        break;
                    case "G1": // Auto Tune on/off 값 읽을때 전달 확인
                        strPacketSplit = rxPacket.Split(',');
                        break;
                    case "S1": // Temp Teach 설정 온도값 읽을때 전달 확인
                        strPacketSplit = rxPacket.Split(',');

//                         foreach (KeyValuePair<EN_HEATER_ZONE, HeaterZone> tZone in m_dicofHeaterZone)
//                         {
//                             foreach (KeyValuePair<int, HeaterData> tData in tZone.Value.HeaterDatas)
//                             {
//                                 value = strPacketSplit[tData.Key];
//                                 value = value.Substring(value.Length - 7, 7);
// 
//                                 if (tZone.Value.SettingValue != Convert.ToSingle(value))
//                                 {
//                                     tZone.Value.SetErrorStatus(tData.Key, 1);
//                                 }
//                             }
//                         }
                        break;
                    case "PB": // offset temp값 읽을때 전달 확인
                        strPacketSplit = rxPacket.Split(',');

//                         foreach (KeyValuePair<EN_HEATER_ZONE, HeaterZone> tZone in m_dicofHeaterZone)
//                         {
//                             foreach (KeyValuePair<int, HeaterData> tData in tZone.Value.HeaterDatas)
//                             {
//                                 float fSumOffset = tZone.Value.OffsetValue + tData.Value.Offset;
// 
//                                 value = strPacketSplit[tData.Key];
//                                 value = value.Substring(value.Length - 7, 7);
// 
//                                 if (tZone.Value.SettingValue != Convert.ToSingle(value))
//                                 {
//                                     tZone.Value.SetErrorStatus(tData.Key, 1);
//                                 }
//                             }
//                         }
                        break;
                    case "M3": // CT 값 읽음
                        strPacketSplit = rxPacket.Split(',');
                        break;

                    case "B1": // Burnout Read .. 전체 이벤트로 읽음.
                        strPacketSplit = rxPacket.Split(',');
                        break;
                    case "AE": // Heater Breake Alram 전체 이벤트로 읽음.
                        strPacketSplit = rxPacket.Split(',');
                        break;

                    case "A7": // Heater Breake Alram 설정값 읽을때 전달 확인. CT 값 기준으로 설정.
                        strPacketSplit = rxPacket.Split(',');
                        break;
                    case "AJ":// 전체 채널 이벤트 읽음 .. 이진을 스트링으로 줌...앞에 영 날아감..이것만 스트링으로..
                        strPacketSplit = rxPacket.Split(',');
                        break;
                    case "A1": // 하한 온도 편차 범위 설정값 읽을때 전달 확인
                        strPacketSplit = rxPacket.Split(',');
                        break;
                    case "A2": // 상한 온도 범위 설정값 읽을때 전달 확인
                        strPacketSplit = rxPacket.Split(',');
                        break;
                    case "XA": // 이벤트 1을 하한 온도로 설정값 읽을때 전달 확인
                        strPacketSplit = rxPacket.Split(',');
                        break;
                    case "XB": // 이벤트 2을 상한 온도로 설정값 읽을때 전달 확인
                        strPacketSplit = rxPacket.Split(',');
                        break;
                    case "SW": // Get Run Status
                        // 임시 Packet 확인해서 처리 필요
                        strPacketSplit = rxPacket.Split(',');
                        value = strPacketSplit[0];
                        if (value.Substring(value.Length - 1, 1) == "1")
                        {
                            //m_bRun_State = true;
                            //SetRunStatus(true);
                              foreach (int nCh in m_arChannel)
                        {
                        m_InstanceHeater.SetSerialRunStatus(m_nSerialIndex, nCh, true);
                            }
                        }
                        else
                        {
                            //m_bRun_State = false;
                            //SetRunStatus(false);
                              foreach (int nCh in m_arChannel)
                        {
                        m_InstanceHeater.SetSerialRunStatus(m_nSerialIndex, nCh, false);
                            }
                        }
                        break;
                    default:
                        rxPacket = null;
                        break;
                }
            }
            catch
            {
                return false;
            }
            return true;

        }
        #endregion

        #endregion
        
    }

    
}
