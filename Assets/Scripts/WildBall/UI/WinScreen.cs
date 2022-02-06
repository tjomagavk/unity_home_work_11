using UnityEngine;
using WildBall.UI.Buttons;

namespace WildBall.UI
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private NextLevelButton nextLevelButton;
        [SerializeField] private RestartButton restartButton;
        [SerializeField] private MainMenuButton mainMenuButton;

        public NextLevelButton NextLevelButton => nextLevelButton;
        public RestartButton RestartButton => restartButton;
        public MainMenuButton MainMenuButton => mainMenuButton;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}