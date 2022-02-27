using UnityEngine;

namespace WildBall.GlobalController
{
    public class SoundManager
    {
        private bool muteSounds;

        private AudioSource musicSource;

        public SoundManager(AudioSource musicSource)
        {
            this.musicSource = musicSource;
        }

        public void PlayBackground(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

        public void ChangeState()
        {
            muteSounds = !muteSounds;
            musicSource.mute = muteSounds;
        }

        public bool IsMute()
        {
            return muteSounds;
        }

        private void PlayBackground()
        {
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}