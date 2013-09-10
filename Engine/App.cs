using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Platform.Windows;
using Tao.OpenGl;

namespace Engine
{
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
        public static void SetProjection2D(float width, float height)
        {
            float halfWidth = width / 2;
            float halfHeight = height / 2;
            // Set a new matrix mode
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // Clear the matrix
            Gl.glLoadIdentity();
            // Create the viewing box
            Gl.glOrtho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            //Glu.gluOrtho2D(-halfWidth, halfWidth, -halfHeight, halfHeight);
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
