using UnityEngine;
using WildBall.UI.Buttons;

namespace WildBall.UI
{
    public class DeathScreen : MonoBehaviour
    {
        [SerializeField] private RestartButton restartButton;
        [SerializeField] private MainMenuButton mainMenuButton;

        public RestartButton RestartButton => restartButton;
        public MainMenuButton MainMenuButton => mainMenuButton;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}