using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Engine
{
    public class Matrix
    {
        float _m11, _m12, _m13; 
        float _m21, _m22, _m23;
        float _m31, _m32, _m33;

        // Identity matrix declaration

        public Matrix()
            : this(Identity)
        {

        }

        public Matrix(Matrix m)
        {
            this._m11 = m._m11;
            this._m12 = m._m12;
            this._m13 = m._m13;

            this._m21 = m._m21;
            this._m22 = m._m22;
            this._m23 = m._m23;

            this._m31 = m._m31;
            this._m32 = m._m32;
            this._m33 = m._m33;
        }

        public Matrix(Vector3 x, Vector3 y, Vector3 z, Vector3 o)
        {
            this._m11 = x.x; this._m12 = x.y; this._m13 = x.z;
            this._m21 = x.x; this._m22 = x.y; this._m23 = x.z;
            this._m31 = x.x; this._m32 = x.y; this._m33 = x.z;
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
        public Vector3 GetTranslation()
        {
            float mX = _m11;
            float mY = _m22;
            float mZ = _m33;
        }

        public void SetScale(Vector3 scale)
        {
            _m11 = scale.x;
            _m21 = scale.y;
            _m31 = scale.z;
        }
		public void SetScale(float x, float y, float z)
		{
            _m11 = x;
            _m21 = y;
            _m31 = z;
		}
        public Vector3 GetScale()
        {
            Vector3 result = new Vector3();

            result.x = (new Vector3(_m11, _m12, _m13)).Length();
            result.y = (new Vector3(_m21, _m22, _m23)).Length();
            result.z = (new Vector3(_m31, _m32, _m33)).Length();
            
            return result;
        }

        public void SetRotate(Vector3 axis, float angle)
        {
            double angleSin = Math.Sin(angle);
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
            _m33 = az * axis.z + angleCos;
        }
		
        public void SetRotate(float x, float y, float z, float angle)
		{
            double angleSin = Math.Sin(angle);
            double angleCos = Math.Cos(angle);
            double a = 1.0 - angleCos;
            double ax = a * x;
            double ay = a * y;
            double az = a * z;

            _m11 = ax * x + angleCos;
            _m12 = ax * y + z * angleSin;
            _m13 = ax * z - y * angleSin;

            _m21 = ay * x - z * angleSin;
            _m22 = ay * y + angleCos;
            _m23 = ay * z + x * angleSin;

            _m31 = az * x + y * angleSin;
            _m32 = az * y - x * angleSin;
            _m33 = az * z + angleCos;
		}
        public float Determinate()
        {
            
        }

        public Matrix Inverse()
        {
            
        }

        public static Vector3 operator *(Vector3 v, Matrix m)
        {
            return new Vector3(v.X * m._m11 + v.Y * m._m21 + v.Z * m._m31 + m._m41,
                               v.X * m._m12 + v.Y * m._m22 + v.Z * m._m32 + m._m42,
                               v.X * m._m13 + v.Y * m._m23 + v.Z * m._m33 + m._m43);
        }
    }
}
