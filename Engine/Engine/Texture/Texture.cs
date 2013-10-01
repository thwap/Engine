using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
   
    public struct Texture {
        int _openGLID;

        public int openGLID
        {
            get { return _openGLID; }
            set { _openGLID = value; }
        }
        int _textureID;

        public int textureID
        {
            get { return _textureID; }
            set { _textureID = value; }
        }
        public int width;
        public int height;

    
        public Texture(int OpenGLID, int textureID, int width, int height):this() {
            this.openGLID = OpenGLID;
            this.textureID = textureID;
            this.width = width ;
            this.height = height;
        }
    }
}
