using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Animation : Component
    {
        /// <summary>
        /// Animation inherits from Component
        /// </summary>
        public bool playing = true;
        AnimationClip currentAnimation;
        internal static Dictionary<string, AnimationClip> animationList;

        public void Play(string name)
        {
            currentAnimation = animationList[name];
            if (Time.time > currentAnimation.prevDeltatime + currentAnimation.speed)
            {
                currentAnimation.prevDeltatime = Time.time;

                currentAnimation.sprite.texture = Il.ilBlit(currentAnimation.texture, 0, 0, 0, currentAnimation.yCoordinate, currentAnimation.xCoordinate, 0, currentAnimation.widthOne, currentAnimation.heightOne, 1);
                currentAnimation.xCoordinate += currentAnimation.widthOne;
                if (currentAnimation.xCoordinate == currentAnimation.texture.width)
                {
                    currentAnimation.yCoordinate += currentAnimation.heightOne;
                    currentAnimation.xCoordinate = 0;
                }
                if (currentAnimation.yCoordinate == currentAnimation.texture.height)
                {
                    if (currentAnimation.loop == true)
                    {
                        currentAnimation.yCoordinate = currentAnimation.yStart;
                        currentAnimation.xCoordinate = currentAnimation.xStart;
                    }
                }
            }
        }
        public void Stop()
        {
            playing = false;
            currentAnimation.xCoordinate = currentAnimation.xStart;
            currentAnimation.yCoordinate = currentAnimation.yStart;
        }
    }
}
