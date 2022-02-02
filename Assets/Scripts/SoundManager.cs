using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private bool _isMute;

    public static SoundManager Instance = null;
    public AudioSource MusicSource;

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
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void Mute(bool mute)
    {
        MusicSource.mute = mute;
    }

    private void PlayBackground()
    {
        MusicSource.loop = true;
        MusicSource.Play();
    }
}