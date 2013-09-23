using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLesson
{
    struct Colorf
    {
        public float r, g, b, a;
        /// <summary>
        /// Set the color and alpha. 
        /// </summary>

        /// <param name="r">RED range 0.0-1.0f</param>
        /// <param name="g">GREEN range 0.0-1.0f</param>
        /// <param name="b">BLUE range 0.0-1.0f</param>
        /// <param name="a">alpha range 0.0 - 1.0f</param>
        public Colorf(float r, float g, float b, float a)
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
        public Colorf(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 1;
        }

        public static readonly Colorf BLACK = new Colorf(0,0,0);
        public static readonly Colorf WHITE = new Colorf(1,1,1);
        public static readonly Colorf RED = new Colorf(1,0,0);
        public static readonly Colorf BLUE = new Colorf(0,0,1);
        public static readonly Colorf GREEN = new Colorf(0,1,0);
        public static readonly Colorf YELLOW = new Colorf(1,1,0);
        public static readonly Colorf MAGENTA = new Colorf(1,0,1);
        public static readonly Colorf CYAN = new Colorf(0,1,1);
    }
}
