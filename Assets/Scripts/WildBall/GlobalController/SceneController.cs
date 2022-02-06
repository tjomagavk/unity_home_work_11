using UnityEngine;
using UnityEngine.SceneManagement;

namespace WildBall.GlobalController
{
    public class SceneController : MonoBehaviour
    {
        private static SceneController _instance;
        private static bool _isPause;

        public static SceneController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SceneController>();

                    if (_instance == null)
                    {
                        GameObject container = new GameObject("SceneController");
                        _instance = container.AddComponent<SceneController>();
                    }
                }

                return _instance;
            }
        }

        public static void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public static void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
            Play();
        }

        public static void LoadNextScene()
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeScene + 1);
        }

        public static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Play();
        }

        public static void ChangePlayPause()
        {
            if (_isPause)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0;
            }

            _isPause = !_isPause;
        }


        public static void Play()
        {
            Time.timeScale = 1f;
            _isPause = false;
        }
    }
}