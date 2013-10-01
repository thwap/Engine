using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.DevIl;

namespace Engine
{
    class AnimationClip
    {
        public int columns;
        public int rows;
        public bool loop;
        public float speed { get; set; }
        public int xCoordinate = 0;
        public int yCoordinate = 0;
        public int xStart = 0;
        public int yStart = 0;
        public float prevDeltatime = 0;
        public int widthOne;
        public int heightOne;
        public Sprite sprite;
        public Texture texture;
        public AnimationClip(Texture texture, int columns, int rows, bool loop, float speed, Sprite sprite, int xStart, int yStart, string name)
        {
            this.columns = columns;
            this.rows = rows;
            this.loop = loop;
            this.texture = texture;
            this.speed = speed;
            this.sprite = sprite;
            widthOne = texture.width / columns;
            heightOne = texture.height / rows;
            this.xCoordinate = widthOne * xStart;
            this.yCoordinate = heightOne * yStart;
            this.xStart = xCoordinate;
            this.yStart = yCoordinate;
            Animation.animationList.Add(name, this);
        }
        public AnimationClip(Texture texture, int columns, int rows, bool loop, float speed, Sprite sprite, string name)
        {
            this.columns = columns;
            this.rows = rows;
            this.loop = loop;
            this.texture = texture;
            this.speed = speed;
            this.sprite = sprite;
            widthOne = texture.width / columns;
            heightOne = texture.height / rows;
            this.xCoordinate = 0;
            this.yCoordinate = 0;
            this.xStart = 0;
            this.yStart = 0;
            Animation.animationList.Add(name, this);
        }
        public AnimationClip(Texture texture, int columns, int rows, float speed, Sprite sprite, string name)
        {
            this.columns = columns;
            this.rows = rows;
            this.loop = true;
            this.texture = texture;
            this.speed = speed;
            this.sprite = sprite;
            widthOne = texture.width / columns;
            heightOne = texture.height / rows;
            this.xCoordinate = 0;
            this.yCoordinate = 0;
            this.xStart = 0;
            this.yStart = 0;
            Animation.animationList.Add(name, this);
        }
        public AnimationClip(Texture texture, int columns, int rows, float speed, Sprite sprite, int xStart, int yStart, string name)
        {
            this.columns = columns;
            this.rows = rows;
            this.loop = true;
            this.texture = texture;
            this.speed = speed;
            this.sprite = sprite;
            widthOne = texture.width / columns;
            heightOne = texture.height / rows;
            this.xCoordinate = widthOne * xStart;
            this.yCoordinate = heightOne * yStart;
            this.xStart = xCoordinate;
            this.yStart = yCoordinate;
            Animation.animationList.Add(name, this);
        }
    }
}