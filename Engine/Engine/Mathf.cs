using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Mathf
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
        public const float Deg2Rad = PI / 180f;
        public const float Rad2Deg = 180f / PI;
        #endregion

        #region CLASS_METHODS
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

        public static float Acos(float angle)
        {
            return PiOver2 - Asin(angle);
        }

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

        public static bool Approximate(float a, float b)
        {
            return a == b;
        }

        public static bool Approximate(float a, float b, float tolerance)
        {
            return (Abs(a - b) <= tolerance);
        }

        #region MIN_MAX
        public static float Max(float a, float b)
        {
            if (a > b) return a;
            return b;
        }

        public static int Round(float value)
        {
            value += 0.5f;
            return (int)value;
        }

        public static float Max(params float[] values)
        {
            float max = values[0];
            foreach (float v in values)
            {
                if (v > max) max = v;
            }
            return max;
        }


        public static float Min(float a, float b)
        {
            if (a < b) return a;
            return b;
        }


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

        public static float Expe(int x)
        {
            if (x > 0)
            {

                float result = 1 + x;
                int i = 2;
                while (i <= x)
                {
                    i++;
                    int x2 = x;
                    for (int y = 2; y <= i; y++)
                    {
                        x2 *= x;
                    }
                    result += x2 / factorial(i);
                }
                return result;

            }
            else if (x == 0)
            {
                return 1;
            }
            else
            {

                x = (int)Abs((float)x);
                float result = 1 + x;
                int i = 2;
                while (i <= x)
                {
                    i++;
                    int x2 = x;
                    for (int y = 2; y <= i; y++)
                    {
                        x2 *= x;
                    }
                    result += x2 / factorial(i);
                }

                return 1 / result;
            }

        }

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

        public static float Pow(float value, float exp)
        {
            return Ex(exp * Ln(value));
        }

        public static float Log(float value, float baseLog)
        {

            if (baseLog == 10) return (float)(Ln(value) / 2.30258509299);
            if (baseLog == Math.E) return Ln(value);
            else return Ln(value) / Ln(baseLog);
        }

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
        
        public static float Sqrt(float value)
        {
            float x = value / 2;
            for (int i = 0; i < 5; i++) x = (x + value / x) / 2f;
            return x;
        }

        public static float MoveTowards(float current, float target, float step)
        {
            if (Math.Abs(current - target) < step) return target;
            return current + (current - target) / Math.Abs(current - target) * step;
        }


        public static float Lerp(float current, float target, float ratio)
        {
            return current + (target - current) * ratio;

        }

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

