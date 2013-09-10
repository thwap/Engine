using System;
using System.Runtime.InteropServices;


namespace Engine
{
    [StructLayout(LayoutKind.Sequential)]
    public  struct Vector3
    {
        #region MEMBERS
        
        
        public float magnitude 
        {
          
        }
        public float sqrMagnitude
        {
            
        }
        public Vector3 Normalized()
        {
               
        }
        #endregion
        #region STATIC_VECTOR
		// Declaration for vector zero, one, right, left, up, down, forward, back
   
        #endregion
        #region CONSTRUCTOR
        public Vector3(float x, float y,float z = 0):this()
        {
            
        }
        public Vector3(Vector3 vector):this()
        {
            
        }
        #endregion
        #region OVERRIDE
		// Override for ToString(), Equals(object o), Equals(Vector3 vec) GetHashCode()
        #endregion
		
        #region OPERATOR
		// Override of operator == , !=, + , -, * (float * Vector and Vector * float)
        #endregion
        #region ARITHMETIC
        public Vector3 Add(Vector3 vector)
        {
            
        }
        public Vector3 Subtract(Vector3 vector)
        {
            
        }
        public void Scale(float scale) 
        {
            
        }
        #endregion
        public void Normalize() {
            
        }
        public static float Dot(Vector3 v1, Vector3 v2)
        {
            
        }
        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            
        }
        public static Vector3 Interpolate(Vector3 current, Vector3 target, float ratio) 
        {
            
        }
        public static Vector3 MoveStep(Vector3 current, Vector3 target, float step)
        {
            
        }
        public static Vector3 Reflect(Vector3 incoming, Vector3 normal)
        {
            
        }
        public static Vector3 Projection(Vector3 target, Vector3 position, Vector3 direction)
        {
            
        }
        public static float Angle(Vector3 v1, Vector3 v2) 
        {
            
        }
        public static float Distance (Vector3 v1, Vector3 v2)
        {
            
        }
    }
	// Same for Vector2 and Vector4
}
