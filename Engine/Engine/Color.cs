using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct Color
    {
        public float r, g, b, a;
        /// <summary>
        /// Set the color and alpha. 
        /// </summary>

        /// <param name="r">RED range 0.0-1.0f</param>
        /// <param name="g">GREEN range 0.0-1.0f</param>
        /// <param name="b">BLUE range 0.0-1.0f</param>
        /// <param name="a">alpha range 0.0 - 1.0f</param>
        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
        /// <summary>
        /// Set the color.
        /// </summary>
        /// <param name="r">RED range 0.0-1.0f</param>
        /// <param name="g">GREEN range 0.0-1.0f</param>
        /// <param name="b">BLUE range 0.0-1.0f</param>
        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 1;
        }
        // This should be as Black, White,...
        // and commented
        public static readonly Color BLACK = new Color(0,0,0);
        public static readonly Color WHITE = new Color(1,1,1);
        public static readonly Color RED = new Color(1,0,0);
        public static readonly Color BLUE = new Color(0,0,1);
        public static readonly Color GREEN = new Color(0,1,0);
        public static readonly Color YELLOW = new Color(1,1,0);
        public static readonly Color MAGENTA = new Color(1,0,1);
        public static readonly Color CYAN = new Color(0,1,1);
    }
}
