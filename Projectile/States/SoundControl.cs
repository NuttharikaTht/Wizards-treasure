using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projectile
{
    public class SoundControl
    {
        public float volume = 0.5f;
        public SoundEffect sound;
        public SoundEffectInstance instance;

        

        public SoundControl(String MUSICPATH)
        {
            sound = null;
            instance = null;

            if (MUSICPATH != null)
            {
                SetMusic(MUSICPATH);
            }
        }
        public virtual void AdjustVolume(float Volume)
        {
            if(instance != null)
            {
                instance.Volume = Volume;
                volume = Volume;
            }
        } 

        public virtual void SetMusic(string MUSICPATH)
        {
            sound = Globals.content.Load<SoundEffect>(MUSICPATH);
            instance = sound.CreateInstance();
            instance.Volume = volume;

            instance.IsLooped = true;
            instance.Play();
        }

        


    }
}
