using Tao.Platform.Windows;
namespace Engine
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private OpenGLControl _openGLControl;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.components = new System.ComponentModel.Container();
            this.Text = "Form1";

            _openGLControl = App.Init(300, 300, false, this, GameLoop, "EBIN GAEM ENGINEER!!11one"); // Initializing the Form and OpenGL
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this._openGLControl);
            this.ResumeLayout(false);
        }

        #endregion
    }
}

