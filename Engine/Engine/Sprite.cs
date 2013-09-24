using System;
using System.Collections.Generic;
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
        Transform transform;
        Vector3 vertex;
        Vector2 vertexUVs;
        Texture texture;
        Colorf vertexColor;
        int vertexAmount;


        public void InitVertexPositions(Vector3 position, float width, float height)
        {
        }

        public void Draw()
        {
        }

        public void ApplyMatrix(Matrix compositeMatrix)
        {
        }

        public void SetPosition(Vector3 position)
        {
        }
    }
}
