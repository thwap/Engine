using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Engine
{
    public class Time
    {
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceFrequency(ref long PerformanceFrequency);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceCounter(ref long PerformanceCount);

        long _ticksPerSecond = 0;
        long _previousElapsedTime = 0;

        public static float deltaTime;
        public static float time;
        public static float timeScale;

        public Time()
        {
            QueryPerformanceFrequency(ref _ticksPerSecond);
            SetTime();
            time = 0;
            timeScale = 1f;
        }

        public void SetTime()
        {
            long _time = 0;
            QueryPerformanceCounter(ref _time);
            deltaTime = (float)((double)(_time - _previousElapsedTime) / (double)_ticksPerSecond);
            _previousElapsedTime = _time;
            time += deltaTime;
            deltaTime *= timeScale;
        }
    }
}
