using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Tao.OpenGl;

namespace Engine
{
    public partial class Form1 : Form
    {
        Loop _loop;
        bool _fullScreen = false;
        int width = 400;
        int height = 400;
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
                
                ClientSize = new Size(width, height);
            }
            App.SetProjection2D(width, height);
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
