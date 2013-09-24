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

			Gl.glPushMatrix();
				Gl.glRotatef(Time.time * 50, 0.8f, 0.9f, 1f);
				Gl.glTranslatef(-50, -50, -50);
				Gl.glLineWidth(5f);
				Gl.glBegin(Gl.GL_LINE_LOOP);

					Gl.glColor3f(1, 0, 0);
						Gl.glVertex3f(0, 0, 0);
						Gl.glVertex3f(100, 0, 0);
						Gl.glVertex3f(100, 0, 100);
						Gl.glVertex3f(0, 0, 100);
						Gl.glVertex3f(0, 0, 0);
					Gl.glColor3f(0, 0, 1);
						Gl.glVertex3f(0, 100, 0);
						Gl.glVertex3f(100, 100, 0);
					Gl.glColor3f(1, 0, 0);
						Gl.glVertex3f(100, 0, 0);
					Gl.glColor3f(0, 0, 1);
						Gl.glVertex3f(100, 100, 0);
						Gl.glVertex3f(100, 100, 100);
					Gl.glColor3f(1, 0, 0);
						Gl.glVertex3f(100, 0, 100);
					Gl.glColor3f(0, 0, 1);
						Gl.glVertex3f(100, 100, 100);			
						Gl.glVertex3f(0, 100, 100);
					Gl.glColor3f(1, 0, 0);
						Gl.glVertex3f(0, 0, 100);
					Gl.glColor3f(0, 0, 1);
						Gl.glVertex3f(0, 100, 100);
						Gl.glVertex3f(0, 100, 0);
				Gl.glEnd();
			Gl.glPopMatrix();
            
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
