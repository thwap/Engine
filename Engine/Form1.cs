using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Tao.OpenGl;

namespace Engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Loop _loop = new Loop(GameLoop);
            InitializeComponent();
            _openGLControl.InitializeContexts();

            App.SetProjection2D(Screen.Width, Screen.Height, Projection.Center);
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
