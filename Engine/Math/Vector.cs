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
        /// Returns the magnitude or length of teh vector
        /// </summary>
        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
            }
            //Removed the setter to make it private
        }
        /// <summary>
        /// Returns the squared magnitude or squared length of the vector
        /// </summary>
        public float sqrMagnitude
        {
            get
            {
                return (float)(x * x) + (y * y) + (z * z);
            }
            //remove the setter setter to make it private
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vector3 Normalized()
        {
            /*Vector3 TempVector;
            
            TempVector.x = (float)(x/(Math.Sqrt((x * x) + (y * y) + (z * z))));
            TempVector.y = (float)(y/(Math.Sqrt((x * x) + (y * y) + (z * z))));
            TempVector.z = (float)(z/(Math.Sqrt((x * x) + (y * y) + (z * z))));
                  
            return TempVector;*/
            //The idea was right but the way is not.
            // TempVector is just a pointer that goes nowhere and you ry assigning something to it
            // You would get a runtime error saying you are trying to assign to something non-initialized
            // Also you may store the magnitude to call it only once.
            float mag = (float)(x / (Math.Sqrt((x * x) + (y * y) + (z * z))));
            float _x = x / mag;
            float _y = y / mag;
            float _z = z / mag;
            // return a new vector with the value
            return new Vector3(_x, _y, _z);

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
        //public static readonly Vector3 ONE = new Vector3(0.57735f, 0.57735f, 0.57735f);
        //Vector.ONE is a vector with all ones, not length one.
        public static readonly Vector3 ONE = new Vector3(1, 1, 1);

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
        public Vector3 Add(Vector3 vector)
        {
            float _x = x + vector.x;
            float _y = y + vector.y;
            float _z = z + vector.z;

            return new Vector3(_x, _y, _z);
        }
        public Vector3 Subtract(Vector3 vector)
        {
            Vector3 TempVector;
            TempVector.x = x - vector.x;
            TempVector.y = y - vector.y;
            TempVector.z = z - vector.z;

            return TempVector;
            //throw new NotImplementedException();
        }
        public void Scale(float scale)
        {

            x = x * scale;
            y = y * scale;
            z = z * scale; 

            //throw new NotImplementedException();
        }
        #endregion
        public void Normalize()
        {

            float TempX = x, TempY = y, TempZ = z;

            x = (float)(TempX / (Math.Sqrt((TempX * TempX) + (TempY * TempY) + (TempZ * TempZ))));
            y = (float)(TempY / (Math.Sqrt((TempX * TempX) + (TempY * TempY) + (TempZ * TempZ))));
            z = (float)(TempZ / (Math.Sqrt((TempX * TempX) + (TempY * TempY) + (TempZ * TempZ))));

        }
        public static float Dot(Vector3 v1, Vector3 v2)
        {
            float result = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
            return result;
        }
        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            Vector3 TempVector;

           TempVector.x = v1.y * v2.z - v2.y * v1.z;
           TempVector.y = v1.z * v2.x - v2.z * v1.x;
           TempVector.z = v1.x * v2.y - v2.x * v1.y; 

            return TempVector;
            
            //throw new NotImplementedException();
        }
        public static Vector3 Interpolate(Vector3 current, Vector3 target, float ratio)
        {
            Vector3 TempVector;

            TempVector.x = current.x + (target.x - current.x) * ratio;
            TempVector.y = current.y + (target.y - current.y) * ratio;
            TempVector.z = current.z + (target.z - current.z) * ratio;

            return TempVector;
            //throw new NotImplementedException();
        }
      
       /* public static Vector3 MoveStep(Vector3 current, Vector3 target, float step)
        {
            Vector3 TempVector;

             


            return TempVector;

            //throw new NotImplementedException();
        }*/
        public static Vector3 Reflect(Vector3 incoming, Vector3 normal)
        {
            throw new NotImplementedException();
        }
        public static Vector3 Projection(Vector3 target, Vector3 position, Vector3 direction)
        {
            throw new NotImplementedException();
        }
        public static float Angle(Vector3 v1, Vector3 v2)
        {
            throw new NotImplementedException();
        }
        public static float Distance(Vector3 v1, Vector3 v2)
        {
            
            throw new NotImplementedException();
        }
    }
    // Same for Vector2 and Vector4
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4
    {
        #region MEMBERS
        public float x, y, z, w;
        public Vector4(float x, float y, float z, float w) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    #endregion
    }
}
