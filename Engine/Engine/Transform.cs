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
        public Vector3 rotation;
        public Vector3 scale;

        //Constructor of class
        public Transform(Vector3 position,Vector3 rotation,Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

   
        //Move
        public void Translate(Vector3 tr)
        { 
            
        }

        //Rotate
        public void Rotate(float angle)
        { 
            
        }

        //Scale
        public void Scale(float amount)
        {
            scale.Scale(amount);
        }



    }
}
