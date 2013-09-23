using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Engine
{
    public class Scene:EngineObject,IDisposable
    {
        protected List<GameObject> GameObjects;

        public Scene(String name)
        {
            App.scenes.Add(name, this);
        }

        public virtual void Update()
        {
            foreach(GameObject GO in GameObjects){
              //  GO.Update();
            }
        }
        public virtual void Draw()
        {
            foreach (GameObject GO in GameObjects)
            {
               // if (GO.Sprite != null) GO.Render();
            }
        }
        
        

   }

    class Scene1 : Scene

    {
        public Scene1()
            : base("Scene1")
        {
        }

        public Scene1(String name)
            : base(name)
        {
        }
    }

    class Scene2 : Scene
    {

    }
}
