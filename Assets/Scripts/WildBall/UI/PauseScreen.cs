using UnityEngine;
using WildBall.UI.Buttons;

namespace WildBall.UI
{
    public class PauseScreen : MonoBehaviour
    {
        [SerializeField] private RestartButton restartButton;
        [SerializeField] private PlayPauseButton returnButton;
        [SerializeField] private MainMenuButton mainMenuButton;

        public RestartButton RestartButton => restartButton;
        public PlayPauseButton ReturnButton => returnButton;
        public MainMenuButton MainMenuButton => mainMenuButton;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}