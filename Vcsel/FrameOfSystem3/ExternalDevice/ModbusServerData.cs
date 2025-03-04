using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameOfSystem3.ExternalDevice.Modbus
{
    public class ModbusServerData
    {
        private bool[] arReadWriteCoil;    //0~9999 FunctionCode(1, 5, 15)에 대응
        private bool[] arReadOnlyCoil;     //10000~19999 FunctionCode(2)에 대응
        private short[] arReadOnlyRegister; //30000~39999  FunctionCode(4)에 대응
        private short[] arReadWriteRegister; //40000~49999  FunctionCode(3, 6, 16)에 대응

         #region 싱글톤
        private ModbusServerData() 
        {
            arReadWriteCoil = new bool[10000];
            arReadOnlyCoil = new bool[10000]; 
            arReadOnlyRegister = new short[10000];
            arReadWriteRegister = new short[10000]; 
        }

        private static readonly Lazy<ModbusServerData> lazyInstance = new Lazy<ModbusServerData>(() => new ModbusServerData());
        static public ModbusServerData GetInstance() 
        {
            return lazyInstance.Value; 
        }
        #endregion
    }
}
