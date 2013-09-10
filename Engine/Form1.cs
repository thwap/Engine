using System;
using System.Drawing;
using System.Windows.Forms;
using Tao.OpenGl;

namespace Engine
{
    public partial class Form1 : Form
    {
        Loop _loop;
        bool _fullScreen = false;
        public Form1()
        {
            Loop _loop = new Loop(GameLoop);
            InitializeComponent();
            _openGLControl.InitializeContexts();
            if (_fullScreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                int width = 800;
                int height = 600;
                ClientSize = new Size(width, height);
            }
            App.SetProjection2D(100, 50);
        }

        private void GameLoop()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            _openGLControl.Refresh();
        }
        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            //Set the viewport
            Gl.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
        }
    }
}
