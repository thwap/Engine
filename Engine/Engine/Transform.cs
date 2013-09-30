using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Transform
    {
        public Vector3 position;
        public Vector4 rotation;
        public Vector3 scale;

        //Constructor of class
        public Transform(Vector3 position,Vector4 rotation,Vector3 scale)
        {
  
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

   
        //Move
        public void Translate(Vector3 tr)
        {
            // position.x = position.x + tr.x;
            // position.y = position.y + tr.y;
            // position.z = position.z + tr.z;

            Matrix m = new Matrix();

            m.SetTranslation(tr.x, tr.y, tr.z);
            position = m.GetTranslation();
        }

        //Rotate
        public void Rotate(float angle)
        {
            Matrix m = new Matrix();
            m.SetRotateZ(angle);
            rotation = m * rotation;

        }

        //Scale
        public void Scale(float amount)
        {
            scale.Scale(amount);
        }



    }
}
