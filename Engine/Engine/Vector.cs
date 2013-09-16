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
        /// <summary>
        /// Returns the vector information as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return x + ", "+ y + ", "+ z;
        }

        /// <summary>
        /// Returns true if the Vector is equal to the parameter
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(object o)
        {
            if(o is Vector3) // Check if object is Vector3
            {
                return Equals((Vector3)o);
            }
            return base.Equals(o);
        }

        public bool Equals(Vector3 vec)
        {
            return (this.x == vec.x) && (this.y == vec.y) && (this.z == vec.z);
        }

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
        
        // Override of operator == , !=, + , -, * (float * Vector and Vector * float)
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            float _x = v1.x - v2.x;
            float _y = v1.y - v2.y;
            float _z = v1.z - v2.z;
            return new Vector3(_x, _y, _z);
        }

        public static Vector3 operator -(Vector3 v1)
        {
            return new Vector3(-v1.x, -v1.y, -v1.z);
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            float _x = v1.x + v2.x;
            float _y = v1.y + v2.y;
            float _z = v1.z + v2.z;
            return new Vector3(_x, _y, _z);
        }

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
            // Missing some details here for safety
            /*if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z)
                return true;
            else
                return false;*/
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
            float _dot = Dot(incoming, normal) * 2f;
            Vector3 _reflection = incoming - (normal * _dot);
            return _reflection;
        }

        public static Vector3 Projection(Vector3 target, Vector3 direction)
        {

            return Dot(target.Normalized(), direction) * target.Normalized();    
        }
        /// <summary>
        /// Returns the angle between v1 and v2
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static float Angle(Vector3 v1, Vector3 v2)
        {
            // Yes, but proper way would be:

            Vector3 v1Norm = v1.Normalized();
            Vector3 v2Norm = v2.Normalized();
            //float prod = Dot(v1, v2) / (v1.magnitude * v2.magnitude);
            float dot = Dot(v1Norm, v2Norm);
            return Mathf.Acos(dot);
            // Actually here, best would be to benchmark (test for speed) to see which one goes faster.
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
            // return (v1 - v2).magnitude; // Here comes:
            return (float)Math.Sqrt((v1.x - v2.x) + (v1.y - v2.y) + (v1.z - v2.z));
        }

        #endregion
    }

    // Same for Vector2 and Vector4

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
        public static readonly Vector2 FORWARD = new Vector2(0, 0); // Keep or remove?
        public static readonly Vector2 BACK = new Vector2(0, 0);    // Keep or remove?
        public static readonly Vector2 ZERO = new Vector2(0, 0);
        public static readonly Vector2 ONE = new Vector2(1, 1);

        #endregion

        #region OVERRIDE
        // Override for ToString(), Equals(object o), Equals(Vector3 vec) GetHashCode()
        public override string ToString()
        {
            // Decided that some units are better than nothing
            return x + "x, " + y + "y";
        }

        public override bool Equals(object o)
        {
            Vector3 v3 = (Vector3)o;
            if ((System.Object)v3 != null)
            {
                // Is castable to Vector3
                if (v3.x == x && v3.y == y && v3.z == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                // Is not castable to Vector3
                Vector4 v4 = (Vector4)o;
                if ((System.Object)v4 != null)
                {
                    // Is castable to Vector4
                    if (v4.x == x && v4.y == y && v4.z == 0 && v4.w == 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        public bool Equals(Vector2 vec)
        {
            // Tests value equality, should I test reference equality instead?
            if ((System.Object)vec == null)
                return false;
            else if (vec.GetHashCode() == GetHashCode())
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            // I truly, really, honestly assume that this is supposed to work like md5,
            // without the need of being cryptographically valid
           
            //Int64 number = x.GetHashCode() + y.GetHashCode();
            //return (int)(number % Int32.MaxValue);
            // Indeed, this is supposedely creating some kind of cryptographic version
            // In fact, the method is used for Dictionary so we should come up with something fast and providing a chance of avoiding collision
            // We probably won't use directly though but avoiding collision is important.
            // For instance, I would think your way would get (1,0,0) and (0,1,0) to return the same value 
            // Then the dictionary would get teh same value and store both object in the same "bucket"
            // Let's make it so that it won't happen
            // This is based on Jon Skeet answer on StackOverflow
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

        public static bool operator ==(Vector2 v1, Vector2 v2)      // Equality
        {
            if (v1.x == v2.x && v1.y == v2.y)
                return true;
            else
                return false;
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)      // Inequality
        {
            if (v1.x == v2.x && v1.y == v2.y)
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
        public static Vector2 Cross(Vector2 v1)
        {
            // This rotates it exactly 90 degrees CCW
            return new Vector2(v1.y, -v1.x);
            // Cross product is only defined in 3D. 
            // 2D version is just a 3D with z = 0
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
                return (current + (tempVector.Normalized() * step)); // The distance is more than step, so return a point that is step amount closer to target than currenty
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

        public static Vector2 Projection(Vector2 target, Vector2 direction)
        {
			return Dot(target.Normalized(), direction) * target.Normalized(); 
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
        public static float Distance(Vector3 v1, Vector3 v2)
        {
            return (float)Math.Sqrt((v1.x - v2.x) + (v1.y - v2.y));
        }

        #endregion



    }

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
            // Fixed this too. Had the direction of incoming reversed. -- K.S.
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
            // return (v1 - v2).magnitude;
            return (float)Math.Sqrt((v1.x - v2.x) + (v1.y - v2.y) + (v1.z - v2.z) + (v1.w - v2.w));
        }

        #endregion

    }
}
