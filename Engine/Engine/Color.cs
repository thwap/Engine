using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct Color
    {
        /// <summary>
        /// returns value of red
        /// </summary>
        public float r
        {
            get 
            {
                return _r;
            }
        }

        /// <summary>
        /// returns value of green
        /// </summary>
        public float g
        {
            get
            {
                return _g;
            }
        }


        /// <summary>
        /// returns value of blue
        /// </summary>
        public float b
        {
            get
            {
                return _b;
            }
        }


        /// <summary>
        /// returns value of alpha
        /// </summary>
        public float a
        {
            get
            {
                return _a;
            }
        }
        /// <summary>
        /// Colors red value
        /// </summary>
        float _r 
        { 
            get
            {
                return _r;
            }
            set
            {
                if (value > 1)
                {
                    value = 1;
                }
                else if (value < 0)
                {
                    value = 0;
                }
            }
        }

        /// <summary>
        /// Colors green value
        /// </summary>
        float _g
        {
            get
            {
                return _g;
            }
            set
            {
                if (value > 1)
                {
                    value = 1;
                }
                else if (value < 0)
                {
                    value = 0;
                }
            }
        }

        /// <summary>
        /// Colors blue value
        /// </summary>
        float _b
        {
            get
            {
                return _b;
            }
            set
            {
                if (value > 1)
                {
                    value = 1;
                }
                else if (value < 0)
                {
                    value = 0;
                }
            }
        }

        /// <summary>
        /// Colors alpha value
        /// </summary>
        float _a
        {
            get
            {
                return _a;
            }
            set
            {
                if (value > 1)
                {
                    value = 1;
                }
                else if (value < 0)
                {
                    value = 0;
                }
            }
        }


        /// <summary>
        /// Set the color and alpha. 
        /// </summary>

        /// <param name="r">Red range 0.0-1.0f</param>
        /// <param name="g">Green range 0.0-1.0f</param>
        /// <param name="b">Blue range 0.0-1.0f</param>
        /// <param name="a">alpha range 0.0 - 1.0f</param>
        public Color(float r, float g, float b, float a)
        {
            this._r = r;
            this._g = g;
            this._b = b;
            this._a = a;
        }
        /// <summary>
        /// Set the color.
        /// </summary>
        /// <param name="r">Red range 0.0-1.0f</param>
        /// <param name="g">Green range 0.0-1.0f</param>
        /// <param name="b">Blue range 0.0-1.0f</param>
        public Color(float r, float g, float b)
        {
            this._r = r;
            this._g = g;
            this._b = b;
            this._a = 1;
        }

        /// <summary>
        /// Ínterpolates between Colors from and target by time
        /// </summary>
        /// <param name="from"></param>
        /// <param name="target"></param>
        /// <param name="time"></param>
        /// <returns>color</returns>
        public static Color Lerp(Color from, Color target, float time)
        {
            return from + ( target - from) * time;
        }

        /// <summary>
        /// Converses Vector4 to Color
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>Color</returns>
        public static Color Vector4ToColor(Vector4 vector)
        {
            Color conversed;
            conversed._r = vector.x;
            conversed._g = vector.y;
            conversed._b = vector.z;
            conversed._a = vector.w;
            return conversed;
        }

        /// <summary>
        /// Converses a Color to Vector4
        /// </summary>
        /// <param name="color"></param>
        /// <returns>Vector4</returns>
        public static Vector4 ColorToVector4(Color color)
        {
            Vector4 conversed;
            conversed.x = color._r;
            conversed.y = color._g;
            conversed.z = color._b;
            conversed.w = color._a;
            return conversed;
        }

        #region operator

        /// <summary>
        /// Adds c2 to c1
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>c1+c2</returns>
        public static Color operator +(Color c1, Color c2)
        {
            c1._r += c2._r;
            c1._g += c2._g;
            c1._b += c2._b;
            c1._a += c2._a;
            return c1;
        }

        /// <summary>
        /// Substract c2 from c1
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>c1-c2</returns>
        public static Color operator -(Color c1, Color c2)
        {
            c1._r -= c2._r;
            c1._g -= c2._g;
            c1._b -= c2._b;
            c1._a -= c2._a;
            return c1;
        }

        /// <summary>
        /// multiplies c1 by c2
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>c1*c2</returns>        
        public static Color operator *(Color c1, Color c2)
        {
            c1._r *= c2._r;
            c1._g *= c2._g;
            c1._b *= c2._b;
            c1._a *= c2._a;
            return c1;
        }


        /// <summary>
        /// multiplies c1 by a float number
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="num"></param>
        /// <returns>c1*num</returns>
        public static Color operator *(Color c1, float num)
        {
            c1._r *= num;
            c1._g *= num;
            c1._b *= num;
            c1._a *= num;
            return c1;
        }


        /// <summary>
        /// divides c1 by c2
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>c1/c2</returns>
        public static Color operator /(Color c1, Color c2)
        {
            c1._r /= c2._r;
            c1._g /= c2._g;
            c1._b /= c2._b;
            c1._a /= c2._a;
            return c1;
        }

        #endregion

        /// <summary>
        /// shorthand for color black
        /// </summary>
        public static readonly Color Black = new Color(0,0,0);
        
        /// <summary>
        /// shorthand for color white
        /// </summary>
        public static readonly Color White = new Color(1,1,1);
        
        /// <summary>
        /// shorthand for color red
        /// </summary>
        public static readonly Color Red = new Color(1,0,0);
        
        /// <summary>
        /// shorthand for color blue
        /// </summary>
        public static readonly Color Blue = new Color(0,0,1);
        
        /// <summary>
        /// shorthand for color green
        /// </summary>
        public static readonly Color Green = new Color(0,1,0);
        
        /// <summary>
        /// shorthand for color yellow
        /// </summary>
        public static readonly Color Yellow = new Color(1,1,0);
        
        /// <summary>
        /// shorthand for color magenta
        /// </summary>
        public static readonly Color Magenta = new Color(1,0,1);

        /// <summary>
        /// shorthand for color cyan
        /// </summary>
        public static readonly Color Cyan = new Color(0,1,1);
    }
}
