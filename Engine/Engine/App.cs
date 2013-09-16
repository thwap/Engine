using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Platform.Windows;
using Tao.OpenGl;

namespace Engine
{
    // I put it outside to save one level
    // from App.Projection.Value t Projection.Value
    public enum Projection
    {
        Center,
        UpperLeft,
        UpperRight,
        LowerLeft,
        LowerRight

    }
    public class App
    {
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
    public class Screen
    {
        private static int _width;
        private static int _height;
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
