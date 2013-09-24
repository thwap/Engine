using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// The Screen class holds information on the screen dimension
    /// The static members allow easy access.
    /// Values are read-only.
    /// </summary>
    /// 
    public class Screen
    {
        private static int _width;
        private static int _height;
        /// <summary>
        /// The width of the screen
        /// </summary>
        public static int Width
        {
            get
            {
                return _width;
            }
            internal set
            {
                _width = value;
            }
        }
        /// <summary>
        /// The height of the screen
        /// </summary>
        public static int Height
        {
            get
            {
                return _height;
            }
            internal set
            {
                _height = value;
            }
        }
    }

}
