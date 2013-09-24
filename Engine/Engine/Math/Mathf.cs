using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// The Mathf class contains variables and methods for mathematic and trigonometry.
    /// </summary>
    public class Mathf
    {
        #region CLASS_VARIABLE
        static Dictionary<float, float> sinList = new Dictionary<float, float>();
        static Dictionary<float, float> cosList = new Dictionary<float, float>();
        static Mathf()
        {
            // Adding to tables
        }
        //PI, PiOver2, PiOver4, Epsilon,Infinity, NegInfinity, Deg2Rad, Rad2Deg
        public const float PI = (float)Math.PI;
        public const float PiOver2 = PI / 2;
        public const float PiOver4 = PI / 4;
        public const float Epsilon = 0.00001f;
        public const float Infinity = float.PositiveInfinity;
        public const float NegInfinity = float.NegativeInfinity;
        /// <summary>
        /// How to use: Degvalue * Deg2Rad
        /// </summary>
        public const float Deg2Rad = PI / 180f;
        /// <summary>
        /// How to use: Radvalue * Rad2Deg
        /// </summary>
        public const float Rad2Deg = 180f / PI;
        #endregion

        #region CLASS_METHODS
        /// <summary>
        /// Calculates the absolute value of f
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Abs(float f)
            
        {
            if (f >= 0) return f;
            return -f;
        }

        // since taylor series work only near 0, angle needs to be between [-PI,PI]
        private static float parseAngle(float angle)
        {
            if (angle > PI || angle < -PI)
            {
                return angle - 2 * PI * ((int)(angle / (2 * PI)));
            }
            return angle;
        }

        /// <summary>
        /// Calculates sin(angle)
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns></returns>
        public static float Sin(float angle)
        {
            /*angle = parseAngle(angle);
            // Will likely never happen
            if (angle == 0 || angle == PI) return 0;
            if (angle == PiOver2) return 1;
            if (angle == 3 * PiOver4) return -1;*/
            
            angle = angle < Epsilon ? 0.0f : angle;
            if (angle == 0) return 0.0f;

            float _angle = 1 - angle;
            _angle = _angle < 0 ? -_angle : _angle; 
            angle = _angle < Epsilon ? 1.0f : angle;
            if (angle == 1) return 1.0f;
            
            if (sinList.ContainsKey(angle))
            {
                return sinList[angle];
            }

            float value = angle, divisor = 6, xpower = -angle * angle;
            float dividend = xpower * angle;

            value += dividend / 6.0f;
            for (int i = 4; i < 20; i += 2)
            {
                divisor *= i * (i + 1);
                dividend *= xpower;
                value += dividend / divisor;
            }
            return value;
        }

        /// <summary>
        /// Calculates cos(angle)
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns></returns>
        public static float Cos(float angle)
        {
            angle = parseAngle(angle);
            if (angle == 0) return 1;
            if (angle == PI) return -1;
            if (angle == PiOver2 || angle == PiOver4 * 3) return 0;
            

            float value = 1, divisor = 1, xpower = -angle * angle;
            float dividend = 1;
            for (int i = 1; i < 20; i += 2)
            {
                dividend *= i * (i + 1);
                divisor *= xpower;
                float _temp = divisor / dividend;
                
                if (Abs(_temp) > Epsilon)
                    value += divisor / dividend;
                else
                    return value;
            }
            return value;

        }

        /// <summary>
        /// Calculates tan(angle)
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns></returns>
        public static float Tan(float angle)
        {
            float cos = Cos(angle);
            float sin = Sin(angle);
            if (cos == 0)
            {
                if (sin > 0) return Infinity;
                if (sin < 0) return NegInfinity;
            }
            return sin / cos;
        }
        
        /// <summary>
        /// Calculates arcsin(angle)
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle in radians</returns>
        public static float Asin(float angle)
        {
            angle = parseAngle(angle);
            float result = angle;
            float prefix = 1;
            float multi = angle * angle;
            float x = angle;
            for (float i = 1; i < 50; i += 2)
            {
                x *= multi;
                prefix *= i / (i + 1);
                result += prefix * (x / (i + 2));

            }
            return result;
        }
        
        /// <summary>
        /// Calculates arccos(angle)
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle in radians</returns>
        public static float Acos(float angle)
        {
            return PiOver2 - Asin(angle);
        }

        /// <summary>
        /// Calculates arctan(angle)
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle in radians</returns>
        public static float Atan(float angle)
        {
            /*
            arctan(x) = y/x * (1 + (2/3)*y + ((2*4)/(3*5))*y^2 + ((2*4*6)/(3*5*7))*y^3 ...)
            where y = (x^2)/(1+x^2)
            */
            float iterationCount = 1000;
            float y = (angle * angle) / (1 + (angle * angle));

            float result = 1 + ((2.0f / 3.0f) * y);
            //the first two iterations but simpler to insert them here rather than the loop itself

            for (int i = 1; i < iterationCount; ++i)
            {
                float tempY = y;
                float tempVal = 2.0f / 3.0f;
                for (int i2 = 1; i2 <= i; ++i2)
                {
                    tempVal *= ((2.0f + (i2 * 2)) / (3.0f + (i2 * 2)));
                    tempY *= y;
                }
                tempVal *= tempY;
                result += tempVal;
            }
            result *= y / angle;
            return result;
        }

        public static float Atan2(float y, float x)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if two given floats have the same value or not.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True if the values are same, false if not.</returns>
        public static bool Approximate(float a, float b)
        {
            return a == b;
        }

        /// <summary>
        /// Checks if two given float values are in a given tolerance of each other.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="tolerance"></param>
        /// <returns>True if the values are in a given tolerance of each other, false if not.</returns>
        public static bool Approximate(float a, float b, float tolerance)
        {
            return (Abs(a - b) <= tolerance);
        }

        #region MIN_MAX
        /// <summary>
        /// Checks which parameter is greater
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Value of greater parameter</returns>
        public static float Max(float a, float b)
        {
            if (a > b) return a;
            return b;
        }

        /// <summary>
        /// Rounds a float into nearest integer
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Rounded integer value</returns>
        public static int Round(float value)
        {
            value += 0.5f;
            return (int)value;
        }

        /// <summary>
        /// Finds the greatest value in an array of values
        /// </summary>
        /// <param name="values"></param>
        /// <returns>Greatest value</returns>
        public static float Max(params float[] values)
        {
            float max = values[0];
            foreach (float v in values)
            {
                if (v > max) max = v;
            }
            return max;
        }

        /// <summary>
        /// Checks which parameter is smaller
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Smaller parameter</returns>
        public static float Min(float a, float b)
        {
            if (a < b) return a;
            return b;
        }

        /// <summary>
        /// Finds the smallest value in an array of values
        /// </summary>
        /// <param name="values"></param>
        /// <returns>Smallest value</returns>
        public static float Min(params float[] values)
        {
            float min = values[0];
            foreach (float v in values)
            {
                if (v < min) min = v;
            }
            return min;
        }
        #endregion

        
        /// <summary>
        /// E to the power of x
        /// </summary>
        /// <param name="x">Exponent</param>
        /// <returns>E to the power of x</returns>
        private static float Ex(float x) //e to the power of x. Created for the Pow function
        {
            float iterationCount = 10;
            //Cannot handle many iterations. Probably because of the factorial function.

            float result = 1.0f + x;
            //Simpler to input the first two iterations here.

            for(int i = 1; i <= iterationCount; ++i)
            {
                float tempVal = x;
                for(int y = 1; y <= i; ++y)
                {
                    tempVal *= x;
                }
                tempVal /= factorial(i+1);
                result += tempVal;
            }
            return result;
        }

        /// <summary>
        /// Power function
        /// </summary>
        /// <param name="value">Value to be raised</param>
        /// <param name="exp">Exponent</param>
        /// <returns></returns>
        public static float Pow(float value, float exp)
        {
            return Ex(exp * Ln(value));
        }

        /// <summary>
        /// Return the logarithm for the value with the given base value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="baseLog"></param>
        /// <returns></returns>
        public static float Log(float value, float baseLog)
        {

            if (baseLog == 10) return (float)(Ln(value) / 2.30258509299);
            if (baseLog == Math.E) return Ln(value);
            else return Ln(value) / Ln(baseLog);
        }

        /// <summary>
        /// Natural logarithm for the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static float Ln(float value)
        {
            int iterationCount = 1000;
            float result = 0;
            float multi;
            if (value <= 2 && value > 0) //0 < x <= 2. Supposedly more effective in this range but is certainly less accurate even with a thousand iterations.
            {
                int signSwitch = 0; 
                //signSwitch controls whether the value from each iteration is added or subtracted from the final result. Switches on every loop.

                for (int i = 1; i <= iterationCount; ++i)
                {
                    multi = value - 1; 

                    for (int y = 2; y <= i; ++y) //(x-1) to the power of i.
                    {
                        multi *= (value - 1);
                    }
                    if (signSwitch == 0)
                    {
                        result += multi / i; // The result from the loop is either added or subtracted from the final result.
                        signSwitch = 1; //Switching sign
                    }
                    else
                    {
                        result -= multi / i;
                        signSwitch = 0; //Switching sign
                    }
                }
            }
            else if (value > 0)
            {

                result = (value - 1) / (value + 1);
                multi = result;
                float coeff = result * result;
                for (int i = 3; i < iterationCount; i += 2)
                {
                    multi *= coeff;
                    result += multi / i;
                }
                result *= 2;
            }
            return result;
        }
        /// <summary>
        /// Calculates squareroot for the given value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Sqrt(float value)
        {
            float x = value / 2;
            for (int i = 0; i < 5; i++) x = (x + value / x) / 2f;
            return x;
        }

        /// <summary>
        /// Calculates the next value from current value towards target value with specified step size.
        /// Negative step size moves away from target.
        /// </summary>
        /// <param name="current">Current value</param>
        /// <param name="target">Target value</param>
        /// <param name="step">Step size</param>
        /// <returns></returns>
        public static float MoveTowards(float current, float target, float step)
        {
            if (Abs(current - target) < step) return target;
            return current + (current - target) / Abs(current - target) * step;
        }

        /// <summary>
        /// Performs linear interpolation with the give ratio
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        public static float Lerp(float current, float target, float ratio)
        {
            return current + (target - current) * ratio;

        }

        /// <summary>
        /// Clamps the value for the given minimum and maximum
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Clamp(int value, int min, int max)
        {
            if (value > max)
            {
                value = max;
            }
            if (value < min)
            {
                value = min;
            }
            return value;
        }
        /// <summary>
        /// Clamps the value for the given minimum and maximum
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Clamp(float value, float min, float max)
        {
            if (value > max)
            {
                value = max;
            }
            if (value < min)
            {
                value = min;
            }
            return value;
        }
         
        /// <summary>
        /// Calculates the factorial n! (1*2*..*n)
        /// </summary>
        /// <param name="factor"></param>
        /// <returns></returns>
        public static float factorial(float factor)
        {

            int i, j = 1;
            for (i = 1; i <= factor; i++)
            {
                j = j * i;
            }
            return (float)j;


            //return Sqrt(2.0 * 3.141 / x) * Pow(x / 2.71828, x);
        }

        #endregion
    }
}

