using UnityEngine;
using UnityEngine.SceneManagement;

namespace WildBall.GlobalController
{
    public class SceneController
    {
        private static bool _isPause;

        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
            Play();
        }

        public void LoadNextScene()
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeScene + 1);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Play();
        }

        public void ChangePlayPause()
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


        private void Play()
        {
            Time.timeScale = 1f;
            _isPause = false;
        }
    }
}