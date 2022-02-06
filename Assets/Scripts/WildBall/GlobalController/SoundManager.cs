using UnityEngine;

namespace WildBall.GlobalController
{
    public class SoundManager : MonoBehaviour
    {
        private bool isMute;

        public static SoundManager Instance = null;
        public AudioSource musicSource;

        private void Start()
        {
            // PlayBackground();
        }

        // Initialize the singleton instance.
        private void Awake()
        {
            // If there is not already an instance of SoundManager, set it to this.
            if (Instance == null)
            {
                Instance = this;
            }
            //If an instance already exists, destroy whatever this object is to enforce the singleton.
            else if (Instance != this)
            {
                Destroy(gameObject);
            }

            //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad(gameObject);
        }

        public void PlayBackground(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

        public bool Mute()
        {
            isMute = !isMute;
            musicSource.mute = isMute;
            return isMute;
        }

        private void PlayBackground()
        {
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}