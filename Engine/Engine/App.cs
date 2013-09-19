using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Platform.Windows;
using Tao.OpenGl;

namespace Engine
{
    /// <summary>
    /// Projection Enumeration
    /// Contains 5 members to define the position of the origin on the viewport
    /// </summary>
    public enum Projection
    {
        Center,
        UpperLeft,
        UpperRight,
        LowerLeft,
        LowerRight

    }
    /// <summary>
    /// The App class contains most of the initialization methods for the application.
    /// </summary>
    public class App
    {
        /// <summary>
        /// Initializes and defines the OpenGLControl object needed to start the application
        /// </summary>
        /// <returns></returns>
        public static OpenGLControl Init()
        {
            OpenGLControl _openGLControl = new OpenGLControl();
            _openGLControl.AccumBits = ((byte)(0));
            _openGLControl.AutoCheckErrors = false;
            _openGLControl.AutoFinish = false;
            _openGLControl.AutoMakeCurrent = false;
            _openGLControl.AutoSwapBuffers = true;
            _openGLControl.BackColor = System.Drawing.Color.Black;
            _openGLControl.ColorBits = ((byte)(32));
            _openGLControl.DepthBits = ((byte)(16));
            _openGLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            _openGLControl.Location = new System.Drawing.Point(0, 0);
            _openGLControl.Name = "OpenGlControl";
            _openGLControl.Size = new System.Drawing.Size(284, 264);
            _openGLControl.StencilBits = ((byte)(0));
            _openGLControl.TabIndex = 0;
            return _openGLControl;
        }
        /// <summary>
        /// Initializes and defines the OpenGLControl object needed to start the application
        /// </summary>
        /// <param name="name">The given name to the application</param>
        /// <returns></returns>
        public static OpenGLControl Init(string name)
        {
            OpenGLControl _openGLControl = new OpenGLControl();
            _openGLControl.AccumBits = ((byte)(0));
            _openGLControl.AutoCheckErrors = false;
            _openGLControl.AutoFinish = false;
            _openGLControl.AutoMakeCurrent = false;
            _openGLControl.AutoSwapBuffers = true;
            _openGLControl.BackColor = System.Drawing.Color.Black;
            _openGLControl.ColorBits = ((byte)(32));
            _openGLControl.DepthBits = ((byte)(16));
            _openGLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            _openGLControl.Location = new System.Drawing.Point(0, 0);
            _openGLControl.Name = name;
            _openGLControl.Size = new System.Drawing.Size(284, 264);
            _openGLControl.StencilBits = ((byte)(0));
            _openGLControl.TabIndex = 0;
            return _openGLControl;
        }
        /// <summary>
        /// SetProjection2D defines the size and origin position of the viewport
        /// </summary>
        /// <param name="width">The width of the viewport</param>
        /// <param name="height">The height of the viewport</param>
        /// <param name="projection">The position of the center point, center by default</param>
        public static void SetProjection2D(float width, float height, Projection projection = Projection.Center)
        {
            switch (projection)
            {
                case Projection.Center:
                    float halfWidth = width / 2;
                    float halfHeight = height / 2;
                    SetProjection2D(-halfWidth, halfWidth, -halfHeight, halfHeight);
                    break;
                case Projection.UpperLeft:
                    SetProjection2D(0, width, height, 0);
                    break;
                case Projection.UpperRight:
                    SetProjection2D(width, 0, height, 0);
                    break;
                case Projection.LowerLeft:
                    SetProjection2D(0, width, 0, height);
                    break;
                case Projection.LowerRight:
                    SetProjection2D(width, 0, 0, height);
                    break;
            }
        }
        /// <summary>
        /// SetProjection2D defines the size and origin position of the viewport
        /// </summary>
        /// <param name="left">Specify the coordinates for the left vertical clipping plane</param>
        /// <param name="right">Specify the coordinates for the right vertical clipping plane</param>
        /// <param name="bottom">Specify the coordinates for the bottom horizontal clipping plane</param>
        /// <param name="top">Specify the coordinates for the top horizontal clipping plane</param>
        public static void SetProjection2D(float left, float right, float bottom, float top)
        {
            // Set a new matrix mode
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // Clear the matrix
            Gl.glLoadIdentity();
            // Create the viewing box
            Gl.glOrtho(left, right, bottom, top, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }
    }
    /// <summary>
    /// The Screen class holds information on the screen dimension
    /// The static members allow easy access.
    /// Values are read-only.
    /// </summary>
    public class Screen
    {
        private static int _width;
        private static int _height;
        /// <summary>
        /// The width of the screen
        /// </summary>
        public static int Width
        {
            get
            {
                return _width;
            }
            internal set
            {
                _width = value;
            }
        }
        /// <summary>
        /// The height of the screen
        /// </summary>
        public static int Height
        {
            get
            {
                return _height;
            }
            internal set
            {
                _height = value;
            }
        }
    }
}
