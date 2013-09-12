using System;
using System.Runtime.InteropServices;


namespace Engine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        #region MEMBERS
        public float x, y, z;

        /// <summary>
        /// Returns the magnitude of the vector
        /// </summary>
        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
            }
        }

        /// <summary>
        /// Returns the square of magnitude of the vector
        /// </summary>
        public float sqrMagnitude
        {
            get
            {
                return (float)((x * x) + (y * y) + (z * z));
            }
        }

        /// <summary>
        /// Returns an unit vector with the same direction
        /// </summary>
        /// <returns></returns>
        public Vector3 Normalized()
        {
            float mag = magnitude;
            return new Vector3(x / mag, y / mag, z / mag);
        }
        #endregion

        #region STATIC_VECTOR
        // Declaration for vector zero, one, right, left, up, down, forward, back
        public static readonly Vector3 LEFT     = new Vector3(-1, 0, 0);
        public static readonly Vector3 RIGHT    = new Vector3(1, 0, 0);
        public static readonly Vector3 UP       = new Vector3(0, 1, 0);
        public static readonly Vector3 DOWN     = new Vector3(0, -1, 0);
        public static readonly Vector3 FORWARD  = new Vector3(0, 0, 1);
        public static readonly Vector3 BACK     = new Vector3(0, 0, -1);
        public static readonly Vector3 ZERO     = new Vector3(0, 0, 0);
        public static readonly Vector3 ONE      = new Vector3(1, 1, 1);
        #endregion

        #region CONSTRUCTOR
        public Vector3(float x, float y, float z = 0)
            : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3(Vector3 vector)
            : this()
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
        }
        #endregion

        #region OVERRIDE
        // Override for ToString(), Equals(object o), Equals(Vector3 vec) GetHashCode()
        public override string ToString()
        {
            //ijk sounds more like complex numbers
            return x + ", "+ y + ", "+ z;
        }

        public override bool Equals(object o)
        {
            return base.Equals(o);
        }

        public bool Equals(Vector3 vec)
        {
            return this == vec;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region OPERATOR
        
        // Override of operator == , !=, + , -, * (float * Vector and Vector * float)
        // Here in order to gain efficiency you may want to perform the action inside
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
           // return v1.Subtract(v2);
            float _x = v1.x - v2.x;
            float _y = v1.y - v2.y;
            float _z = v1.z - v2.z;
            return new Vector3(_x, _y, _z);
        }

        public static Vector3 operator -(Vector3 v1)
        {
            return new Vector3(-v1.x, -v1.y, -v1.z);
        }
        // Same here
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            //return v1.Add(v2);
            float _x = v1.x + v2.x;
            float _y = v1.y + v2.y;
            float _z = v1.z + v2.z;
            return new Vector3(_x, _y, _z);
        }

        /* Here Multiply and Cross are not the same thing
         * Actually there should not be two vectors multiplied together...
        public static Vector3 operator *(Vector3 v1, Vector3 v2)
        {
            //return Cross(v1, v2);
        }*/

        public static Vector3 operator *(Vector3 v1, float number)
        {
            v1.Scale(number);
            return v1;
        }

        public static Vector3 operator *(float number, Vector3 v1)
        {
            v1.Scale(number);
            return v1; 
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z)
                return true;
            else
                return false;
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z)
                return false;
            else
                return true;
        }
        #endregion

        #region ARITHMETIC

        /// <summary>
        /// Returns the sum vector of this and the parameter
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public Vector3 Add(Vector3 vector)
        {
            float _x = x + vector.x;
            float _y = y + vector.y;
            float _z = z + vector.z;

            return new Vector3(_x, _y, _z);
        }

        /// <summary>
        /// Returns a vector that is this minus the parameter
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public Vector3 Subtract(Vector3 vector)
        {
            float _x = x - vector.x;
            float _y = y - vector.y;
            float _z = z - vector.z;

            return new Vector3(_x, _y, _z);
        }

        /// <summary>
        /// Scales this vector by given amount
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(float scale)
        {
            x = x * scale;
            y = y * scale;
            z = z * scale; 
        }

        #endregion

        /// <summary>
        /// Normalizes this vector to unity length
        /// </summary>
        public void Normalize()
        {
            float previousMagnitude = magnitude;
            x = x / previousMagnitude;
            y = y / previousMagnitude;
            z = z / previousMagnitude;
        }

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Dot(Vector3 v1, Vector3 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        /// <summary>
        /// Returns the cross product of two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            float _x = v1.y * v2.z - v2.y * v1.z;
            float _y = v1.z * v2.x - v2.z * v1.x;
            float _z = v1.x * v2.y - v2.x * v1.y; 
            return new Vector3(_x, _y, _z);
        }


        /// <summary>
        /// Interpolates between current and target, 0 being
        /// equal to current and 1 being equal to target
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        public static Vector3 Interpolate(Vector3 current, Vector3 target, float ratio)
        {
            float _x = current.x + (target.x - current.x) * ratio;
            float _y = current.y + (target.y - current.y) * ratio;
            float _z = current.z + (target.z - current.z) * ratio;
            return new Vector3(_x, _y, _z);
        }

        /// <summary>
        /// Returns a vector that is closer to target from current by an amount
        /// defined by step. If step is greater than distance, target is returned.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static Vector3 MoveStep(Vector3 current, Vector3 target, float step)
        {
            Vector3 tempVector = new Vector3(target - current);
            if (tempVector.magnitude > step)
                return (current + (tempVector.Normalized() * step)); // The distance is more than step, so return a point that is step amount closer to target than currenty
            else return target; // Return target to not overshoot (i.e. go past) the target when step was greater than the remaining distance
        }

        /// <summary>
        /// Returns a reflection of incoming off a plane defined by normal
        /// </summary>
        /// <param name="incoming"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        public static Vector3 Reflect(Vector3 incoming, Vector3 normal)
        {
            // Any ideas to optimize this? -- K.S.
            // This is actually not the equation. 
            // Dot(normal, normal)-> dot product return the ratio of a onto b and in this case a is b so this is 1.
            // Division by 1 yields 1. Also, a normal is already normalized.
            //return new Vector3(2 * (Dot(incoming, normal) / Dot(normal, normal) * normal.Normalized()) + incoming);
            // the equation is reflection = incoming - 2 * normal * (dot(incoming.normal))
            float _dot = Dot(incoming, normal) * 2f;
            Vector3 _reflection = incoming - (normal * _dot);
            return _reflection;
        }

        public static Vector3 Projection(Vector3 target, Vector3 position, Vector3 direction)
        {
            throw new NotImplementedException();       
        }
        
        public static float Angle(Vector3 v1, Vector3 v2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the distance between two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Distance(Vector3 v1, Vector3 v2)
        {
            // I would perform the arithmetic inside the method to gain a couple of cycle
            return (v1 - v2).magnitude;
        }
    }

    // Same for Vector2 and Vector4

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4
    {
        #region MEMBERS
        public float x, y, z, w;

        public float magnitude
        {
            get
            {
                return (float)(Math.Sqrt((x * x) + (y * y) + (z * z) + (w * w)));
            }
            // Setter omitted for a read-only property
        }

        public float sqrMagnitude
        {
            get
            {
                return (float)((x * x) + (y * y) + (z * z) + (w * w));
            }
            // Setter omitted for a read-only property
        }

        public Vector4 Normalized()
        {
            float mag = magnitude;
            return new Vector4(x / mag, y / mag, z / mag, w / mag);
        }

        #endregion

        #region CONSTURCTORS

        public Vector4(float x, float y, float z, float w) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4(Vector4 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
            this.w = vector.w;
        }

        #endregion

        #region STATIC_VECTOR
        // Declaration for vector zero, one, right, left, up, down, forward, back
        public static readonly Vector4 LEFT     = new Vector4(-1, 0, 0, 0);
        public static readonly Vector4 RIGHT    = new Vector4(1, 0, 0, 0);
        public static readonly Vector4 UP       = new Vector4(0, 1, 0, 0);
        public static readonly Vector4 DOWN     = new Vector4(0, -1, 0, 0);
        public static readonly Vector4 FORWARD  = new Vector4(0, 0, 1, 0);
        public static readonly Vector4 BACK     = new Vector4(0, 0, -1, 0);
        public static readonly Vector4 ZERO     = new Vector4(0, 0, 0, 0);
        public static readonly Vector4 ONE      = new Vector4(1, 1, 1, 1);

        #endregion

        #region OVERRIDE
        // Override for ToString(), Equals(object o), Equals(Vector3 vec) GetHashCode()
        public override string ToString()
        {
            // Decided that some units are better than nothing
            return x + "x, " + y + "y, " + z + "z, " + w + "w";
        }

        public override bool Equals(object o)
        {
            return base.Equals(o);
        }

        public bool Equals(Vector3 vec)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            Int64 number = x.GetHashCode() + y.GetHashCode() + z.GetHashCode() + w.GetHashCode();
            return (int)(number % Int32.MaxValue);
        }

        #endregion

        #region OPERATOR

        public static Vector4 operator -(Vector4 v1, Vector4 v2)
        {
            float _x = v1.x - v2.x;
            float _y = v1.y - v2.y;
            float _z = v1.z - v2.z;
            float _w = v1.w - v2.w;
            return new Vector4(_x, _y, _z, _w);
        }

        public static Vector4 operator -(Vector4 v1)
        {
            return new Vector4(-v1.x, -v1.y, -v1.z, -v1.w);
        }

        public static Vector4 operator +(Vector4 v1, Vector4 v2)
        {
            float _x = v1.x + v2.x;
            float _y = v1.y + v2.y;
            float _z = v1.z + v2.z;
            float _w = v1.w + v2.w;
            return new Vector4(_x, _y, _z, _w);
        }

        public static Vector4 operator *(Vector4 v1, float number)
        {
            v1.Scale(number);
            return v1;
        }

        public static Vector4 operator *(float number, Vector4 v1)
        {
            v1.Scale(number);
            return v1;
        }

        public static bool operator ==(Vector4 v1, Vector4 v2)
        {
            if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z && v1.w == v2.w)
                return true;
            else
                return false;
        }

        public static bool operator !=(Vector4 v1, Vector4 v2)
        {
            if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z && v1.w == v2.w)
                return false;
            else
                return true;
        }
        #endregion

        #region ARITHMETIC

        /// <summary>
        /// Returns the sum vector of this and the parameter
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public Vector4 Add(Vector4 vector)
        {
            float _x = x + vector.x;
            float _y = y + vector.y;
            float _z = z + vector.z;
            float _w = w + vector.w;
            return new Vector4(_x, _y, _z, _w);
        }

        /// <summary>
        /// Returns a vector that is this minus the parameter
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public Vector4 Subtract(Vector4 vector)
        {
            float _x = x - vector.x;
            float _y = y - vector.y;
            float _z = z - vector.z;
            float _w = w - vector.w;
            return new Vector4(_x, _y, _z, _w);
        }

        /// <summary>
        /// Scales this vector by given amount
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(float scale)
        {
            x = x * scale;
            y = y * scale;
            z = z * scale;
            w = w * scale;
        }

        #endregion

        #region MISC

        /// <summary>
        /// Normalizes this vector to unity length
        /// </summary>
        public void Normalize()
        {
            float previousMagnitude = magnitude;
            x = x / previousMagnitude;
            y = y / previousMagnitude;
            z = z / previousMagnitude;
            w = w / previousMagnitude;
        }

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Dot(Vector4 v1, Vector4 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z + v1.w * v2.w;
        }

        /// <summary>
        /// Interpolates between current and target, 0 being
        /// equal to current and 1 being equal to target
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        public static Vector4 Interpolate(Vector4 current, Vector4 target, float ratio)
        {
            float _x = current.x + (target.x - current.x) * ratio;
            float _y = current.y + (target.y - current.y) * ratio;
            float _z = current.z + (target.z - current.z) * ratio;
            float _w = current.w + (target.w - current.w) * ratio;
            return new Vector4(_x, _y, _z, _w);
        }

        /// <summary>
        /// Returns a vector that is closer to target from current by an amount
        /// defined by step. If step is greater than distance, target is returned.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static Vector4 MoveStep(Vector4 current, Vector4 target, float step)
        {
            Vector4 TempVector = new Vector4(target - current);
            if (TempVector.magnitude > step)
                return (current + (TempVector.Normalized() * step)); // The distance is more than step, so return a point that is step amount closer to target than currenty
            else return target; // Return target to not overshoot (i.e. go past) the target when step was greater than the remaining distance
        }

        /// <summary>
        /// Returns a reflection of incoming off a plane defined by normal
        /// </summary>
        /// <param name="incoming"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        public static Vector4 Reflect(Vector4 incoming, Vector4 normal)
        {
            // Could not see any reason why this would not work in 4D -- K.S.
            return new Vector4(2 * (Dot(incoming, normal) / Dot(normal, normal) * normal.Normalized()) + incoming);
        }

        /// <summary>
        /// Returns the distance between two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Distance(Vector4 v1, Vector4 v2)
        {
            return (v1 - v2).magnitude;
        }

        #endregion

    }
}
