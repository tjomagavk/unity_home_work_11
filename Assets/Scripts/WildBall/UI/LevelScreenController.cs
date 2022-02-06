using UnityEngine;
using UnityEngine.Serialization;

namespace WildBall.UI
{
    public class LevelScreenController : MonoBehaviour
    {
        [SerializeField] private InterfaceScreen interfaceScreen;
        [SerializeField] private PauseScreen pauseScreen;
        [SerializeField] private DeathScreen deathScreen;
        [SerializeField] private WinScreen winScreen;

        private void Awake()
        {
            interfaceScreen.SetActive(true);
            pauseScreen.SetActive(false);
            deathScreen.SetActive(false);
            winScreen.SetActive(false);
        }

        public void DeathActive()
        {
            interfaceScreen.SetActive(false);
            pauseScreen.SetActive(false);
            deathScreen.SetActive(true);
            winScreen.SetActive(false);
        }

        public void WinActive()
        {
            interfaceScreen.SetActive(false);
            pauseScreen.SetActive(false);
            deathScreen.SetActive(false);
            winScreen.SetActive(true);
        }
    }
}