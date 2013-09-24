﻿using System;
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
        GameObject()
        {
            foreach (Component comp in compList)
            {
                comp.Start();
            }
        }
        T addComp<T>() where T : Component, new()
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
    }
}
