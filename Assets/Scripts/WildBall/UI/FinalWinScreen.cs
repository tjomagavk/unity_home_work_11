using UnityEngine;
using WildBall.UI.Buttons;

namespace WildBall.UI
{
    public class FinalWinScreen : MonoBehaviour
    {
        [SerializeField] private MainMenuButton mainMenuButton;

        public MainMenuButton MainMenuButton => mainMenuButton;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}