using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.Platform.Windows;
using System.Windows.Forms;

namespace Engine
{
    class Input
    {
        Vector2 _cursor = new Vector2();
        MouseButtons _buttons = new MouseButtons();
        Keys _keys = new Keys();
        OpenGLControl _control;

        public Vector2 GetMousePos
        {
            get
            {
                return _cursor;
            }
        }
        public Keys GetKeys
        {
            get
            {
                return _keys;
            }
        }
        public MouseButtons GetButtons
        {
            get
            {
                return _buttons;
            }
        }
        
        public Input(OpenGLControl control)
        {
            _control = control;
            _control.MouseMove += new MouseEventHandler(MouseMove);
            _control.MouseDown += new MouseEventHandler(MouseButton);
            _control.MouseUp += new MouseEventHandler(MouseButton);

            _control.KeyDown += new KeyEventHandler(KeyboardEvent);
            _control.KeyUp += new KeyEventHandler(KeyboardEvent);
        }

        void MouseMove(object o, MouseEventArgs args) {
            _cursor.x = args.X - Screen.Width / 2;
            _cursor.y = -args.Y + Screen.Height / 2;
        }

        void MouseButton(object o, MouseEventArgs args)
        {
            _buttons = args.Button;
        }

        void KeyboardEvent(object o, KeyEventArgs args)
        {
            _keys = args.KeyData;
        }

        /*public void Update(System.Windows.Forms.Form form)
        {
            System.Drawing.Point mousePos;
            mousePos = Cursor.Position;

            _cursor.x = mousePos.X - Screen.Width / 2 - form.Location.X;
            _cursor.y = -mousePos.Y + form.Location.Y + Screen.Height / 2;

            Console.WriteLine(_cursor.y);
        }*/
    }
}
