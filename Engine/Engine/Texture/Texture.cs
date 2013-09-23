using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Engine.Texture
{
    class Texture
    {
        int OpenGLID;
        int textureID;
        int width;
        int height;

        public Texture(int OpenGLID, int textureID, int width, int height) {
            this.OpenGLID = OpenGLID;
            this.textureID = textureID;
            this.width = width ;
            this.height = height;
        }






    }
}
