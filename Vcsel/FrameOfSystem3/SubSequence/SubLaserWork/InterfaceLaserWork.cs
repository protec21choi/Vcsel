using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Motion_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{
    #region <INTERFACE CLASS>
    public interface IOutputProfile
    {
        bool CheckOutputCurrent(double dOutput);
        bool ReadyOutputProfile(double[] dOutput, int[] nTime, string[] sMode, bool bKeepLastValue);
        bool StartOutputProfile(bool bTimeSyncOutputs = false, int nTimeSyncCounts = 1);
        bool WorkingOutputProfile(ref int nElapsedTime);
        bool StopOutputProfile(bool bKeepLastValue, bool bTimeSyncOutputs = false, int nTimeSyncCounts = 1);
    }
    public interface IDeviceControl
    {
        void EntryDeviceControl();
        bool ReadyDeviceSetting();
        bool StartWorkToDevice();
        bool StopWorkToDevice();
        bool FinishDevice();
        bool InitializeDevice();
        bool StopEMO();
    }
    public interface IModulationControl
    {
        bool EntryModulationControl();
        bool ReadyMudulationSetting(int[] arTime, double[] arFrequency, int[] arDuty);
        bool StartModulation();
        bool WorkingModulation();
        bool StopModulation();
        bool FinishModulation();
    }
    public interface IMonitoringControl
    {
        bool StartMonitor(bool bUsed);
        bool CheckAbort(bool bUsed, double dAbortTemp);
        double GetTemp();
        bool CheckEMG(bool bUsed, double dEMGTemp);
        bool CheckPower(bool bUsed, double dTarget, double dTolerance);
        bool StopMonitor(bool bUsed);
    }

    public interface ILaserMotionControl
    {
        MOTION_RESULT MoveDuringLaser(bool bUsed, double[] arLevel, double[] arFinalVelocity, double[] arTime);

        bool CheckMotionDone();
    }

    public interface ILaserHeaterControl
    {
        bool ReadyHeater(int nHeaterIndex);
        bool StartTempProfile(int nHeaterIndex);
        bool StartCooling(int nHeaterIndex, bool bHeaterOff);
    }
    #endregion </INTERFACE CLASS>
}
