using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Engine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Message
    {
        public IntPtr hWnd;
        public Int32 msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public System.Drawing.Point p;
    }
    public class Loop
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(
            out Message msg,
            IntPtr hWnd,
            uint messageFilterMin,
            uint MessageFilterMax,
            uint flags);

        public delegate void CallbackLoop();
        CallbackLoop _callback;
        Time _timer;
        public Loop(CallbackLoop callback)
        {
            _callback = callback;
            _timer = new Time();
            Application.Idle += new EventHandler(OnApplicationEnterIdle);
        }

        private void OnApplicationEnterIdle(object sender, EventArgs e)
        {
            Message msg;
            while (!PeekMessage(out msg, IntPtr.Zero, 0, 0, 0))
            {
		
                _timer.SetTime();
                _callback();
            }
        }

    }
}