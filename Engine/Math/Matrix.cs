using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Engine
{
    public class Matrix
    {
        // I made it a 4x4 matrix. even though there are more values, some are barely used
        // But 4x4 makes transition from 2D to 3D easier
        float _m11, _m12, _m13, _m14; 
        float _m21, _m22, _m23, _m24;
        float _m31, _m32, _m33, _m34;
        float _m41, _m42, _m43, _m44;

        // Identity matrix declaration
        public static readonly Matrix Identity = new Matrix(new Vector4(1, 0, 0, 0),
                                                             new Vector4(0, 1, 0, 0),
                                                             new Vector4(0, 0, 1, 0),
                                                             new Vector4(0, 0, 0, 1));
        
        public Matrix()
            : this(Matrix.Identity)
        {

        }
        public Matrix(Matrix m)
        {
            this._m11 = m._m11;
            this._m12 = m._m12;
            this._m13 = m._m13;
            this._m14 = m._m14;

            this._m21 = m._m21;
            this._m22 = m._m22;
            this._m23 = m._m23;
            this._m24 = m._m24;

            this._m31 = m._m31;
            this._m32 = m._m32;
            this._m33 = m._m33;
            this._m34 = m._m34;
            
            this._m41 = m._m41;
            this._m42 = m._m42;
            this._m43 = m._m43;
            this._m44 = m._m44;
        }

        public Matrix(Vector4 x, Vector4 y, Vector4 z, Vector4 w)
        {
            this._m11 = x.x; this._m12 = x.y; this._m13 = x.z; this._m14 = x.w;
            this._m21 = y.x; this._m22 = y.y; this._m23 = y.z; this._m24 = y.w;
            this._m31 = z.x; this._m32 = z.y; this._m33 = z.z; this._m34 = z.w;
            this._m41 = w.x; this._m32 = w.y; this._m33 = w.z; this._m44 = w.w;
        }

        public static Matrix operator *(Matrix mA, Matrix mB)
        {
             Matrix result = new Matrix();

            result._m11 = mA._m11 * mB._m11 + mA._m12 * mB._m21 + mA._m13 * mB._m31;
            result._m12 = mA._m11 * mB._m12 + mA._m12 * mB._m22 + mA._m13 * mB._m32;
            result._m14 = mA._m11 * mB._m13 + mA._m12 * mB._m23 + mA._m13 * mB._m33;

            result._m21 = mA._m21 * mB._m11 + mA._m22 * mB._m21 + mA._m23 * mB._m31;
            result._m22 = mA._m21 * mB._m12 + mA._m22 * mB._m22 + mA._m23 * mB._m32;
            result._m24 = mA._m21 * mB._m13 + mA._m22 * mB._m23 + mA._m23 * mB._m33;

            result._m31 = mA._m31 * mB._m11 + mA._m32 * mB._m21 + mA._m33 * mB._m31;
            result._m32 = mA._m31 * mB._m12 + mA._m32 * mB._m22 + mA._m33 * mB._m32;
            result._m34 = mA._m31 * mB._m13 + mA._m32 * mB._m23 + mA._m33 * mB._m33;

            return result;
        }
			
		public static Matrix MulMatrix(Matrix mA, Matrix mB)
		{
            Matrix matrixResult = mA * mB;
            // Matrix matrixResult2 = Matrix.Multiply(mA, mB);

            return matrixResult;   
		}
        public void SetTranslation(Vector3 translation)
        {
            _m13 = translation.x;
            _m23 = translation.y;
            _m33 = translation.z;
        }
		public void SetTranslation(float x, float y, float z)
        {
            _m13 = x;
            _m23 = y;
            _m33 = z;
        }
        // Needs to return a Vector3
        public Vector3 GetTranslation()
        {
            Vector3 translationResult = new Vector3(_m11, _m22, _m33);
            return translationResult;
        }

        public void SetScale(Vector3 scale)
        {
            _m11 = scale.x;
            _m22 = scale.y;
            _m33 = scale.z;
        }
		public void SetScale(float x, float y, float z)
		{
            _m11 = x;
            _m22 = y;
            _m33 = z;
		}
        public Vector3 GetScale()
        {
            Vector3 result = new Vector3(_m11, _m22, _m33);
            return result;
        }
        public void SetRotate(Vector3 axis, float angle)
        {
            /*double angleSin = Math.Sin(angle);
            double angleCos = Math.Cos(angle);
            double a = 1.0 - angleCos;
            double ax = a * axis.x;
            double ay = a * axis.y;
            double az = a * axis.z;

            _m11 = ax * axis.x + angleCos;
            _m12 = ax * axis.y + axis.z * angleSin;
            _m13 = ax * axis.z - axis.y * angleSin;

            _m21 = ay * axis.x - axis.z * angleSin;
            _m22 = ay * axis.y + angleCos;
            _m23 = ay * axis.z + axis.x * angleSin;
            
            _m31 = az * axis.x + axis.y * angleSin;
            _m32 = az * axis.y - axis.x * angleSin;
            _m33 = az * axis.z + angleCos;*/
            /* Make it simple, you only need to use cos and sin once actually since we are rotating around the z axis only
            * cos sin  0 0
            * -sin cos 0 0
             * 0    0  1 0
             * 0    0  0 1
             * */
        }
		
        public void SetRotate(float x, float y, float z, float angle)
		{
            //Same as above
		}
        public float Determinate()
        {
            throw new NotImplementedException();
        }

        public Matrix Inverse()
        {
            throw new NotImplementedException();
        }

        public static Vector3 operator *(Vector3 v, Matrix m)
        {
            // review for 4x4 matrix
            /*return new Vector3(v.x * m._m11 + v.Y * m._m21 + v.Z * m._m31 + m._m41,
                               v.x * m._m12 + v.Y * m._m22 + v.Z * m._m32 + m._m42,
                               v.x * m._m13 + v.Y * m._m23 + v.Z * m._m33 + m._m43);*/
            throw new NotImplementedException();
        }
    }
}
