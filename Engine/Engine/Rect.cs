using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Engine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        float _x, _y, _width, _height;
        float xMax, xMin, yMax, yMin;

        Vector2 _center;

		//properties for members
		// Make sure a negative value cannot be given
		

		/// <summary>
		/// Create Rectangle
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
        public Rect(float x, float y, float width, float height) : this() 
		{
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
        
        /// <summary>
        /// Create Rectangle
        /// </summary>
        /// <param name="position"></param>
        /// <param name="dimension"></param>
        public Rect(Vector2 position, Vector2 dimension):this() 
		{
            _x = position.x;
            _y = position.y;
            _width = dimension.x;
            _height = dimension.y;
        }

        /// <summary>
        /// Create Rectangle
        /// </summary>
        /// <param name="rect"></param>
        public Rect(Vector4 rect): this()
        {
            _x = rect.x;
            _y = rect.y;
            _width = rect.z;
            _height = rect.w;
        }


        /// <summary>
        /// Returns true if the x and y components of position is a point inside this rectangle.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Intersects(float x, float y)
        {
            //ToDO
            return true;
        }
        /// <summary>
        /// Returns true if the x and y components of position is a point inside this rectangle.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool Intersects(Vector2 position)
        {
            //ToDO
            return true;
        }
        /// <summary>
        /// Returns true if the x and y components of position is a point inside this rectangle.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool Intersects(Vector3 position)
        {
            //ToDO
            return true;
        }
		/// <summary>
        /// Returns true if the rectangle contains the specified point.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
		public bool Contains(Vector2 position)
		{
            //ToDO
            return true;
		}
		/// <summary>
        /// Returns true if the rectangle contains the specified rect.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
		public bool Contains(Rect rect)
		{
            //ToDO
            return true;
		}
		//Override section
        public override string ToString()
        {
            return "Rect x:" + _x + " y:" + _y + " widht:" + _width + " height" + _height;
        }
		public override bool Equals(Rect rect)
		{
            //ToDO
            return true;
		}
		public override int GetHashCode()
		{
            //ToDO
            return 0;
		}
		//Operator overload == and !=
    }
}
