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
        //PI, PiOver2, PiOver4, Epsilon,Infinity, NegInfinity, Deg2Rad, Rad2Deg
        public const float PI = (float)Math.PI;
        public const float PiOver2 = PI / 2;
        public const float PiOver4 = PI / 4;
        public const float Epsilon = 0.0000001f;
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
            angle = parseAngle(angle);

            if (angle == 0 || angle == PI) return 0;
            if (angle == PiOver2) return 1;
            if (angle == 3 * PiOver4) return -1;


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
                value += divisor / dividend;
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

            int sign = 0;
            float temp = angle;
            float final = 0;
            for (int i = 1; i <= 65; i += 2)
            {
                float tempVal = temp;
                if (i > 1)
                {
                    for (int y = 1; y < i; ++y)
                    {
                        tempVal *= temp;
                    }
                    tempVal /= i;
                }
                if (sign == 0)
                {
                    final += tempVal;
                    sign = 1;
                }
                else
                {
                    final -= tempVal;
                    sign = 0;
                }
                temp = angle;
                Console.WriteLine(final);
            }
            return final;
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


        public static float Pow(float value, float exp)
        {
            float final = exp * Log(value, 10);
            return final;
        }

        public static float Log(float value, float baseLog)
        {

            if (baseLog == 10) return (float)(Ln(value) / 2.30258509299);
            if (baseLog == Math.E) return Ln(value);
            else return Ln(value) / Ln(baseLog);
           

        }

        private static float Ln(float value)
        {

            float result = (value - 1) / (value + 1);
            float multi = result;
            float coeff = result * result;
            for (int i = 3; i < 65; i += 2)
            {
                multi *= coeff;
                result += (1.0f / i) * multi;
            }
            return 2 * result;
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

