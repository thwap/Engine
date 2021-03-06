﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Engine
{
    /// <summary>
    /// The Time class
    /// Provides information on the Time
    /// </summary>
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

        /// <summary>
        /// Gives the time in seconds between this frame and the previous frame
        /// </summary>
        
        private static float _deltaTime;
        private static float _time;
        public static float timeScale;


        /// <summary>
        /// Time elapsed in seconds between two previous calls to SetTime()
        /// </summary>
        public static float deltaTime
        {
            get { return _deltaTime; }
        }

        /// <summary>
        /// Time elapsed in seconds after creation of current instance of Time
        /// </summary>
        public static float time
        {
            get { return _time; }
        }

        public Time()
        {
            QueryPerformanceFrequency(ref _ticksPerSecond);
            SetTime();
            _time = 0;
            timeScale = 1f;
        }

        public void SetTime()
        {
            long __time = 0;
            QueryPerformanceCounter(ref __time);
            _deltaTime = (float)((double)(__time - _previousElapsedTime) / (double)_ticksPerSecond);
            _previousElapsedTime = __time;
            _deltaTime *= timeScale;
			_time += _deltaTime;

			//Console.WriteLine("{0} / {1} / {2}", _time, _deltaTime, timeScale);
        }
    }
}
