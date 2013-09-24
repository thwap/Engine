using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Scene:EngineObject,IDisposable
    {
        protected List<GameObject> gameObjectList;
        protected List<EngineObject> listToDestroy;

        public Scene(String name)
        {
            App.scenes.Add(name, this);
        }

        public virtual void Update()
        {
            foreach(GameObject GO in gameObjectList)
            {
                GO.Update();
            }

            foreach (GameObject GO in GameObjects)
            {
                //check for destroyed
            }

        }
        public virtual void Draw()
        {
            foreach (GameObject GO in gameObjectList)
            {
                if (GO.Sprite != null) GO.Render();
            }
        }

        public void QueueDestroy(EngineObject e)
        {
            listToDestroy.Add(e);
        }

        public void Dispose() 
        {
        
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

    public class Scene2 : Scene
    {
        public Scene2()
            : base("Scene2")
        { }
    }
}
