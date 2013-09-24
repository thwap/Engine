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
        
        public Scene(String name)
        {
            GC.Collect();
            App.scenes.Add(name, this);
        }

        public virtual void Update()
        {
            foreach(GameObject GO in gameObjectList)
            {
                GO.Update();
            }

            if (App.listToDestroy.Count != 0)
            {
                for (int i = App.listToDestroy.Count - 1; i >= 0; i--)
                {
                    EngineObject eo = App.listToDestroy[i];
                    if (eo != null)
                    {
                        EngineObject.RemoveObject(eo);
                    }
                    App.listToDestroy.RemoveAt(i);
                }
            }
        }

        public virtual void Draw()
        {
            foreach (GameObject GO in gameObjectList)
            {
                if (GO.sprite != null) GO.Render();
            }
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
