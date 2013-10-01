using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.DevIl;
using Tao.OpenGl;
using Tao.Platform.Windows;


namespace Engine
{
    public class Sprite : Component
    {
        Vector3[] _vertexPositions;
        Vector2[] vertexUVs { get; set; }
        public Texture texture { get; set; }
        Color[] vertexColor { get; set; }
        int vertexAmount { get; set; }

        public Sprite()
            : base()
        {
            InitVertexPositions(new Vector3(0, 0, 0), 2, 2);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

        }

        public void InitVertexPositions(Vector3 position, float width, float height)
        {

            float halfWidth = width / 2;
            float halfHeight = height / 2;
            _vertexPositions = new Vector3[6];

            _vertexPositions[0] = _vertexPositions[3] = new Vector3(position.x - halfWidth, position.y + halfHeight, position.z); //topleft
            _vertexPositions[1] = new Vector3(position.x + halfWidth, position.y + halfHeight, position.z); //topright
            _vertexPositions[2] = _vertexPositions[5] = new Vector3(position.x - halfWidth, position.y - halfHeight, position.z); //bottomleft
            _vertexPositions[4] = new Vector3(position.x + halfWidth, position.y - halfHeight, position.z); //bottomright



        }

        internal void Draw()
        {
            foreach (Vector3 vertx in _vertexPositions)
            {
                //  Classic openGL drawing
            }
        }

        public void DrawVertex(Vector3 position, Color color, Vector2 uvs)
        {
            Gl.glColor4f(color.r, color.g, color.b, color.a);
            Gl.glTexCoord2f(uvs.x, uvs.y);
            Gl.glVertex3f(position.x, position.y, position.z);
        }
        public void ApplyMatrix(Matrix compositeMatrix)
        {
            foreach (Vector3 v in _vertexPositions)
            {

            }
        }

        public void SetPosition(Vector3 position)
        {


        }
    }
}
