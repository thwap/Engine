using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// The GameObject class
    /// Is used as a container for components
    /// </summary>
    public class GameObject:EngineObject
    {
        public List<Component>compList = new List<Component>(); 
        public Sprite sprite;
        public string tag = "Default";

        /// <summary>
        /// Default constructor for GameObject, creates a new instance of GameObject
        /// </summary>
        public GameObject()
        {
            foreach (Component comp in compList)
            {
                comp.Start();
            }
        }
        public void Update()
        {
            foreach (Component comp in compList)
            {
                comp.Update();
            }
        }
        public void Render()
        {
            if(sprite!=null)
            sprite.Draw();
        }
        

        public T AddComponent<T>() where T : Component, new()
        {
            T component = new T();
            component.gameObject = this;
            if (component is Sprite)
            {
                sprite = (Sprite)((object)component);
            }
            else
                compList.Add(component);
            return component;
        }
        public T GetComponent<T>() where T : Component
        {
            foreach (Component comparisonComp in compList)
            {
                if (comparisonComp.GetType() == typeof(T))
                {
                    return comparisonComp as T;
                }
            }
            return null;
        }

        /// <summary>
        /// Find gameobject with name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject Find(string name)
        {
            foreach (GameObject go in App.GetCurrentScene().gameObjectList)
            {
                if (go.name == name)
                    return go;
            }
            
            return null;
        }

        /// <summary>
        /// Find gameobject with tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static GameObject FindGameObjectWithTag(string tag)
        {
            foreach (GameObject go in App.GetCurrentScene().gameObjectList)
            {
                if (go.tag == tag)
                    return go;
            }

            return null;
        }
        
        /// <summary>
        /// Find array of gameobjects with tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static List<GameObject> FindGameObjectsWithTag(string tag)
        {
            List<GameObject> goList = new List<GameObject>();

            foreach (GameObject go in App.GetCurrentScene().gameObjectList)
            {
                if (go.tag == tag)
                {
                    goList.Add(go);
                }
            }

            return goList;
        }
    }
}
