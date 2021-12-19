using System;
using System.Runtime.InteropServices;

namespace VideoWallpaper
{
    public class PowerStatusMonitor
    {
        private IntPtr registrationHandle;
        private DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS recipient;
        private IntPtr pRecipient;

        public DeviceNotifyCallbackRoutine callback;

        public PowerStatusMonitor(DeviceNotifyCallbackRoutine callback)
        {
            this.callback = callback;
        }

        public bool Register()
        {
            registrationHandle = new IntPtr();
            recipient = new DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS
            {
                Callback = callback,
                Context = IntPtr.Zero
            };

            pRecipient = Marshal.AllocHGlobal(Marshal.SizeOf(recipient));
            Marshal.StructureToPtr(recipient, pRecipient, false);

            uint result = PowerRegisterSuspendResumeNotification(DEVICE_NOTIFY_CALLBACK, ref recipient, ref registrationHandle);
            return result != 0;
        }

        public bool UnRegister()
        {
            uint result = PowerUnregisterSuspendResumeNotification(ref registrationHandle);
            Marshal.FreeHGlobal(pRecipient);
            return result != 0;
        }




        public const int WM_POWERBROADCAST = 536;           // (0x218)
        public const int PBT_APMPOWERSTATUSCHANGE = 10;     // (0xA) - Power status has changed.
        public const int PBT_APMRESUMEAUTOMATIC = 18;       // (0x12) - Operation is resuming automatically from a low-power state.This message is sent every time the system resumes.
        public const int PBT_APMRESUMESUSPEND = 7;          // (0x7) - Operation is resuming from a low-power state.This message is sent after PBT_APMRESUMEAUTOMATIC if the resume is triggered by user input, such as pressing a key.
        public const int PBT_APMSUSPEND = 4;                // (0x4) - System is suspending operation.
        public const int PBT_POWERSETTINGCHANGE = 32787;    // (0x8013) - A power setting change event has been received.
        public const int DEVICE_NOTIFY_CALLBACK = 2;

        /// <summary>
        /// OS callback delegate definition
        /// </summary>
        /// <param name="context">The context for the callback</param>
        /// <param name="type">The type of the callback...for power notifcation it's a PBT_ message</param>
        /// <param name="setting">A structure related to the notification, depends on type parameter</param>
        /// <returns></returns>
        public delegate int DeviceNotifyCallbackRoutine(IntPtr context, int type, IntPtr setting);

        /// <summary>
        /// A callback definition
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS
        {
            public DeviceNotifyCallbackRoutine Callback;
            public IntPtr Context;
        }

        [DllImport("Powrprof.dll", SetLastError = true)]
        public static extern uint PowerRegisterSuspendResumeNotification(uint flags, ref DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS receipient, ref IntPtr registrationHandle);

        [DllImport("Powrprof.dll", SetLastError = true)]
        public static extern uint PowerUnregisterSuspendResumeNotification(ref IntPtr registrationHandle);
    }
}
