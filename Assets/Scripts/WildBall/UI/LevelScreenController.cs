using UnityEngine;

namespace WildBall.UI
{
    public class LevelScreenController : MonoBehaviour
    {
        [SerializeField] private InterfaceScreen interfaceScreen;
        [SerializeField] private PauseScreen pauseScreen;
        [SerializeField] private DeathScreen deathScreen;
        [SerializeField] private WinScreen winScreen;
        [SerializeField] private FinalWinScreen finalWinScreen;
        [SerializeField] private GameObject ruleScreen;

        private void Awake()
        {
            interfaceScreen.SetActive(true);
            pauseScreen.SetActive(false);
            deathScreen.SetActive(false);
            winScreen.SetActive(false);
            finalWinScreen.SetActive(false);
        }

        public void DeathActive()
        {
            interfaceScreen.SetActive(false);
            pauseScreen.SetActive(false);
            deathScreen.SetActive(true);
            winScreen.SetActive(false);
            finalWinScreen.SetActive(false);
            ruleScreen.SetActive(false);
        }

        public void WinActive()
        {
            interfaceScreen.SetActive(false);
            pauseScreen.SetActive(false);
            deathScreen.SetActive(false);
            winScreen.SetActive(true);
            finalWinScreen.SetActive(false);
            ruleScreen.SetActive(false);
        }

        public void FinalWinActive()
        {
            interfaceScreen.SetActive(false);
            pauseScreen.SetActive(false);
            deathScreen.SetActive(false);
            winScreen.SetActive(false);
            finalWinScreen.SetActive(true);
            ruleScreen.SetActive(false);
        }
    }
}