using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Scene : EngineObject, IDisposable
    {
        public List<GameObject> gameObjectList;

        public Scene()
        {

        }

        public Scene(String name)
        {

        }
        public virtual void Initialization()
        {

        }
        public virtual void Update()
        {
            foreach (GameObject GO in gameObjectList)
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

    public class Scene1 : Scene
    {
        GameObject obj;
        public Scene1()
            : base("Scene1")
        {
            gameObjectList = new List<GameObject>();
        }
        public override void Initialization()
        {
            obj = new GameObject("Dog");
            obj.AddComponent<Sprite>();
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
