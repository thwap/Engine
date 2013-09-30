using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.DevIl;
using Tao.OpenGl;
using Tao.Platform.Windows;


namespace Engine {
    public class Sprite : Component {
        Transform transform { get;set; }
        Vector3[] vertex;
        Vector2[] vertexUVs {get;set;}
        Texture texture {get;set;}
        Color[] vertexColor {get;set;}
        int vertexAmount {get;set;}

        public Sprite() {
            
        }

        public void InitVertexPositions(Vector3 position, float width, float height)
        {
            vertex = new Vector3[6];
            vertex[3] = vertex[0] =
                new Vector3(width / 2, height / 2, 0) + position; // upperright
            vertex[1] =
                new Vector3(width / 2, -height / 2, 0) + position; // lowerright
            vertex[4] = vertex[2] =
                new Vector3(-width / 2, -height / 2, 0) + position; // lowerleft
            vertex[5] =
                new Vector3(-width / 2, +height / 2, 0);  //topleft

        }

        public void Draw() {
            foreach (Vector3 vertx in vertex) {

            }
        }

        public void DrawVertex(Vector3 position, Color color, Vector2 uvs) {
            Gl.glColor4f(color.r, color.g, color.b, color.a);
            Gl.glTexCoord2f(uvs.x, uvs.y);
            Gl.glVertex3f(position.x, position.y, position.z);
        }
        public void ApplyMatrix(Matrix compositeMatrix) {
            foreach (Vector3 v in vertex) {

            }
        }

        public void SetPosition(Vector3 position) {
               
                   
        }
    }
}
