using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.DevIl;

namespace Engine
{
    public class Animation : Component
    {
        /// <summary>
        /// Animation inherits from Component
        /// </summary>
        public bool playing = true;
        public AnimationClip clip;
        internal static Dictionary<string, AnimationClip> animationList;

        public override void Update()
        {
            if (!playing)
                return;
            Play();
        }
        public void Play()
        {
            if (Time.time > clip.prevDeltatime + clip.speed)
            {
                clip.prevDeltatime = Time.time;

                Il.ilBlit(clip.texture.openGLID, 0, 0, 0, clip.yCoordinate, clip.xCoordinate, 0, clip.widthOne, clip.heightOne, 1);
                clip.xCoordinate += clip.widthOne;
                if (clip.xCoordinate == clip.texture.width)
                {
                    clip.yCoordinate += clip.heightOne;
                    clip.xCoordinate = 0;
                }
                if (clip.yCoordinate == clip.texture.height)
                {
                    if (clip.loop == true)
                    {
                        clip.yCoordinate = clip.yStart;
                        clip.xCoordinate = clip.xStart;
                    }
                }
            }
        }
        public void Play(string name)
        {
            clip = animationList[name];
        }
        public void Stop()
        {
            playing = false;
            clip.xCoordinate = clip.xStart;
            clip.yCoordinate = clip.yStart;
        }
    }
}
