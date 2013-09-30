using System;
using System.Runtime.InteropServices;


namespace Engine
{
    /// <summary>
    /// Class for Vector3
    /// Used for all 3D vector.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        #region MEMBERS
        /// <summary>
        /// The x component of the vector
        /// </summary>
        public float x;
        /// <summary>
        /// The y component of the vector
        /// </summary>
        public float y;
        /// <summary>
        /// The z component of the vector
        /// </summary>
        public float z;

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
        /// <summary>
        /// Shorthand for writing Vector3(-1, 0, 0).
        /// </summary>
        public static readonly Vector3 Left     = new Vector3(-1, 0, 0);
        /// <summary>
        /// Shorthand for writing Vector3(1, 0, 0).
        /// </summary>
        public static readonly Vector3 Right    = new Vector3(1, 0, 0);
        /// <summary>
        /// Shorthand for writing Vector3(0, 1, 0).
        /// </summary>
        public static readonly Vector3 Up       = new Vector3(0, 1, 0);
        /// <summary>
        /// Shorthand for writing Vector3(0, -1, 0).
        /// </summary>
        public static readonly Vector3 Down     = new Vector3(0, -1, 0);
        /// <summary>
        /// Shorthand for writing Vector3(0, 0, 1).
        /// </summary>
        public static readonly Vector3 Forward  = new Vector3(0, 0, 1);
        /// <summary>
        /// Shorthand for writing Vector3(0, 0, -1)
        /// </summary>
        public static readonly Vector3 Back     = new Vector3(0, 0, -1);
        /// <summary>
        /// Shorthand for writing Vector3(0, 0, 0).
        /// </summary>
        public static readonly Vector3 Zero     = new Vector3(0, 0, 0);
        /// <summary>
        /// Shorthand for writing Vector3(1, 1, 1).
        /// </summary>
        public static readonly Vector3 One      = new Vector3(1, 1, 1);
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor for Vector3, creates a new vector with the given values
        /// </summary>
        /// <param name="x">Value for x component</param>
        /// <param name="y">Value for y component</param>
        /// <param name="z">Value for z component</param>
        public Vector3(float x, float y, float z = 0)
            : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        /// <summary>
        /// Constructor for Vector3, creates a new vector with the given values
        /// </summary>
        /// <param name="vector">Vector3 for all components</param>
        public Vector3(Vector3 vector)
            : this()
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
        }
        /// <summary>
        /// Constructor for Vector3, creates a new vector with the given values
        /// </summary>
        /// <param name="vector">Vector2 for x and y component, z = 0 by default</param>
        public Vector3(Vector2 vector, float z = 0)
            : this()
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = 0;
        }
        #endregion

        #region OVERRIDE
        /// <summary>
        /// Returns the vector information as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return x + "x, "+ y + "y, "+ z + "z";
        }

        /// <summary>
        /// Returns true if the Vector is equal to the parameter
        /// </summary>
        /// <param name="o">The object reference to be compared with the instance</param>
        /// <returns></returns>
        public override bool Equals(object o)
        {
            if(o is Vector3) // Check if object is Vector3
            {
                return Equals((Vector3)o);
            }
            return base.Equals(o);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public bool Equals(Vector3 vec)
        {
            if (vec == null)
                return false;
            return (this.x == vec.x) && (this.y == vec.y) && (this.z == vec.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + x.GetHashCode();
                hash = hash * 23 + y.GetHashCode();
                hash = hash * 23 + z.GetHashCode();
                return hash;
            }
        }

        #endregion

        #region OPERATOR
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            float _x = v1.x - v2.x;
            float _y = v1.y - v2.y;
            float _z = v1.z - v2.z;
            return new Vector3(_x, _y, _z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 v1)
        {
            return new Vector3(-v1.x, -v1.y, -v1.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            float _x = v1.x + v2.x;
            float _y = v1.y + v2.y;
            float _z = v1.z + v2.z;
            return new Vector3(_x, _y, _z);
        }
        /// <summary>
        /// Multiply the vector by a scalar and returns a Vector3
        /// </summary>
        /// <param name="v1">Vector to be multiplied</param>
        /// <param name="number">Multiplicator</param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 v1, float number)
        {
            v1.Scale(number);
            return v1;
        }
        /// <summary>
        /// Multiply the vector by a scalar and returns a Vector3
        /// </summary>
        /// <param name="number">Multiplicator</param>
        /// <param name="v1">Vector to be multiplied</param>
        /// <returns></returns>
        public static Vector3 operator *(float number, Vector3 v1)
        {
            v1.Scale(number);
            return v1; 
        }
        /// <summary>
        /// Returns true if all components of both vectors are equal.
        /// Returns true if both parameter are the same object
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            if (Object.ReferenceEquals(v1, v2)) // both are actually the same object
            {
                return true;
            }
            //now check if one of them is not null
            if (v1 == null || v2 == null)
            {
                return false;
            }
            // Finally perform verification
            return (v1.x == v2.x) && (v1.y == v2.y) && (v1.z == v2.z);
        }
        /// <summary>
        /// Returns true if the two vectors are not equal
        /// Returns true if both parameter are the same object
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            if (Object.ReferenceEquals(v1, v2))
            {
                return false;
            }

            if (v1 == null || v2 == null)
            {
                return true;
            }

            return !((v1.x == v2.x) && (v1.y == v2.y) && (v1.z == v2.z));
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

        /// <summary>
        /// Normalizes this vector to unit length
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
                return (current + (tempVector.Normalized() * step)); // The distance is more than step, so return a point that is step amount closer to target than current
            else return target; // Return target to not overshoot (i.e. go past) the target when step was greater than the remaining distance
        }

        /// <summary>
        /// Returns a reflection of incoming off a plane defined by normal
        /// </summary>
        /// <param name="incoming">Incoming vector</param>
        /// <param name="normal">Normal vector</param>
        /// <returns></returns>
        public static Vector3 Reflect(Vector3 incoming, Vector3 normal)
        {
            float _dot = Dot(incoming, normal) * 2f;
            Vector3 _reflection = incoming - (normal * _dot);
            return _reflection;
        }
        /// <summary>
        /// Returns the vector of the projection of the target onto the normal
        /// </summary>
        /// <param name="target"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Vector3 Projection(Vector3 target, Vector3 direction)
        { 
            return Dot(target, direction) * target.Normalized();    
        }
        /// <summary>
        /// Returns the angle between v1 and v2
        /// Angle is between 0 and 180.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Angle(Vector3 v1, Vector3 v2)
        {
            float prod = Dot(v1, v2) / (v1.magnitude * v2.magnitude);
            return Mathf.Acos(prod);
        }

        /// <summary>
        /// Returns the distance between two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Distance(Vector3 v1, Vector3 v2)
        {
            float dx = v1.x - v2.x;
            float dy = v1.y - v2.y;
            float dz = v1.z - v2.z;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        #endregion
    }
    /// <summary>
    /// The class for Vector2. 
    /// Used for 2D vector and UV vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        #region MEMBERS

        public float x, y;

        public float magnitude
        {
            get
            {
                return (float)(Math.Sqrt((x * x) + (y * y)));
            }
        }

        public float sqrMagnitude
        {
            get
            {
                return (float)((x * x) + (y * y));
            }
        }

        public Vector2 Normalized()
        {
            float mag = magnitude;
            return new Vector2(x / mag, y / mag);
        }

        #endregion

        #region CONSTURCTORS

        public Vector2(float x, float y) 
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
        }

        #endregion

        #region STATIC_VECTOR
        // Declaration for vector zero, one, right, left, up, down, forward, back
        public static readonly Vector2 LEFT = new Vector2(-1, 0);
        public static readonly Vector2 RIGHT = new Vector2(1, 0);
        public static readonly Vector2 UP = new Vector2(0, 1);
        public static readonly Vector2 DOWN = new Vector2(0, -1);
        public static readonly Vector2 FORWARD = new Vector2(0, 0);
        public static readonly Vector2 BACK = new Vector2(0, 0);
        public static readonly Vector2 ZERO = new Vector2(0, 0);
        public static readonly Vector2 ONE = new Vector2(1, 1);

        #endregion

        #region OVERRIDE
        // Override for ToString(), Equals(object o), Equals(Vector3 vec) GetHashCode()
        public override string ToString()
        {
            return x + "x, " + y + "y";
        }

        public override bool Equals(object o)
        {
            if (o is Vector2)
                return o.Equals(this);
            else
                return base.Equals(o);
        }

        public bool Equals(Vector2 vec)
        {
            if (vec == null)
                return false;
            if (this.x == vec.x && this.y == vec.y)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + x.GetHashCode();
                hash = hash * 23 + y.GetHashCode();
                return hash;
            }
        }

        #endregion

        #region OPERATOR

        // Override of operator == , !=, + , -, * (float * Vector and Vector * float)
        // Here in order to gain efficiency you may want to perform the action inside
        public static Vector2 operator -(Vector2 v1, Vector2 v2)    // Difference
        {
            float _x = v1.x - v2.x;
            float _y = v1.y - v2.y;
            return new Vector2(_x, _y);
        }

        public static Vector2 operator -(Vector2 v1)                // Negation
        {
            return new Vector2(-v1.x, -v1.y);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)    // Sum
        {
            float _x = v1.x + v2.x;
            float _y = v1.y + v2.y;
            return new Vector2(_x, _y);
        }

        public static Vector2 operator *(Vector2 v1, float number)  // Vector times scalar
        {
            v1.Scale(number);
            return v1;
        }

        public static Vector2 operator *(float number, Vector2 v1)  // Scalar times vector
        {
            v1.Scale(number);
            return v1;
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            if (Object.ReferenceEquals(v1, v2))
            {
                return true;
            }
            if (v1 == null || v2 == null)
            {
                return false;
            }
            return (v1.x == v2.x) && (v1.y == v2.y);
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            if (Object.ReferenceEquals(v1, v2))
            {
                return false;
            }

            if (v1 == null || v2 == null)
            {
                return true;
            }

            return !((v1.x == v2.x) && (v1.y == v2.y));
        }

        #endregion

        #region ARITHMETIC

        /// <summary>
        /// Returns the sum vector of this and the parameter
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public Vector2 Add(Vector2 vector)
        {
            float _x = x + vector.x;
            float _y = y + vector.y;
            return new Vector2(_x, _y);
        }

        /// <summary>
        /// Returns a vector that is this minus the parameter
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public Vector2 Subtract(Vector2 vector)
        {
            float _x = x - vector.x;
            float _y = y - vector.y;
            return new Vector2(_x, _y);
        }

        /// <summary>
        /// Scales this vector by given amount
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(float scale)
        {
            x = x * scale;
            y = y * scale;
        }

        /// <summary>
        /// Normalizes this vector to unity length
        /// </summary>
        public void Normalize()
        {
            float previousMagnitude = magnitude;
            x = x / previousMagnitude;
            y = y / previousMagnitude;
        }

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }

        /// <summary>
        /// Returns the cross product of two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 Cross(Vector2 v1, Vector2 v2)
        {
            // This rotates it exactly 90 degrees CCW
            // return new Vector2(v1.y, -v1.x);
            // Cross product is only defined in 3D. 
            // 2D version is just a 3D with z = 0
            
            // OK, here comes:
            float _x = 0;
            float _y = 0;
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
        public static Vector2 Interpolate(Vector2 current, Vector2 target, float ratio)
        {
            float _x = current.x + (target.x - current.x) * ratio;
            float _y = current.y + (target.y - current.y) * ratio;
            return new Vector2(_x, _y);
        }

        /// <summary>
        /// Returns a vector that is closer to target from current by an amount
        /// defined by step. If step is greater than distance, target is returned.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static Vector2 MoveStep(Vector2 current, Vector2 target, float step)
        {
            Vector2 tempVector = new Vector2(target - current);
            if (tempVector.magnitude > step)
                return (current + (tempVector.Normalized() * step)); // The distance is more than step, so return a point that is step amount closer to target than current
            else return target; // Return target to not overshoot (i.e. go past) the target when step was greater than the remaining distance
        }

        /// <summary>
        /// Returns a reflection of incoming off a plane defined by normal
        /// </summary>
        /// <param name="incoming"></param>
        /// <param name="normal"></param>
        /// <returns></returns>
        public static Vector2 Reflect(Vector2 incoming, Vector2 normal)
        {
            float _dot = Dot(incoming, normal) * 2f;
            Vector2 _reflection = incoming - (normal * _dot);
            return _reflection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Vector2 Projection(Vector2 target, Vector2 direction)
        {
			return Dot(target, direction) * target.Normalized(); 
        }

        public static float Angle(Vector2 v1, Vector2 v2)
        {
            // here same as 3D
            float prod = Dot(v1, v2) / (v1.magnitude * v2.magnitude);
            return Mathf.Acos(prod);
        }

        /// <summary>
        /// Returns the distance between two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Distance(Vector2 v1, Vector2 v2)
        {
            float dx = v1.x - v2.x;
            float dy = v1.y - v2.y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        #endregion
    }
    /// <summary>
    /// Class for Vector4 
    /// Mainly used in computation with the 4x4 Matrix
    /// </summary>
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
            return x + "x, " + y + "y, " + z + "z, " + w + "w";
        }

        public override bool Equals(object o)
        {
            if (o is Vector4) // Check if object is Vector4
            {
                return Equals((Vector4)o);
            }
            return base.Equals(o);
        }

        public bool Equals(Vector4 vec)
        {
            return (this.x == vec.x) && (this.y == vec.y) && (this.z == vec.z) && (this.w == vec.w);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 * x.GetHashCode();
                hash = hash * 23 * y.GetHashCode();
                hash = hash * 23 * z.GetHashCode();
                hash = hash * 23 * w.GetHashCode();
                return hash;
            }
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
            if (Object.ReferenceEquals(v1, v2))
            {
                return true;
            }
            if (v1 == null || v2 == null)
            {
                return false;
            }
            return (v1.x == v2.x) && (v1.y == v2.y) && (v1.z == v2.z) && (v1.w == v2.w);
        }

        public static bool operator !=(Vector4 v1, Vector4 v2)
        {
            if (Object.ReferenceEquals(v1, v2))
            {
                return false;
            }

            if (v1 == null || v2 == null)
            {
                return true;
            }

            return !((v1.x == v2.x) && (v1.y == v2.y) && (v1.z == v2.z) && (v1.w == v2.w));
        }
        
        #endregion

        #region ARITHMETIC

        /// <summary>
        /// Returns the sum vector of this vector and the parameter
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
        /// Returns a vector that is this vector minus the parameter
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
                return (current + (TempVector.Normalized() * step)); // The distance is more than step, so return a point that is step amount closer to target than current
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
            float _dot = Dot(incoming, normal) * 2f;
            Vector4 _reflection = incoming - (normal * _dot);
            return _reflection;
        }

        public static Vector4 Projection(Vector4 target, Vector4 position, Vector4 direction)
        {
            throw new NotImplementedException();
        }

        public static float Angle(Vector4 v1, Vector4 v2)
        {
            float prod = Dot(v1, v2) / (v1.magnitude * v2.magnitude);
            return Mathf.Acos(prod);
        }

        /// <summary>
        /// Returns the distance between two vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Distance(Vector4 v1, Vector4 v2)
        {
            float dx = v1.x - v2.x;
            float dy = v1.y - v2.y;
            float dz = v1.z - v2.z;
            float dw = v1.w - v2.w;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
        }

        #endregion

    }
}
