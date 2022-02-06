using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WildBall.GlobalController;

namespace WildBall
{
    public class LevelMenu : MonoBehaviour
    {
        [SerializeField] private List<Button> restartLevelButtons;
        [SerializeField] private List<Button> pauseButtons;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button soundButton;
        [SerializeField] private Sprite muteImage;
        [SerializeField] private Sprite unMuteImage;
        private Image iconSound;
        private bool muteSound;


        private void Start()
        {
            if (restartLevelButtons != null)
            {
                foreach (Button button in restartLevelButtons)
                {
                    button.onClick.AddListener(SceneController.ReloadScene);
                }
            }

            if (pauseButtons != null)
            {
                foreach (Button button in pauseButtons)
                {
                    button.onClick.AddListener(SceneController.ChangePlayPause);
                }
            }

            if (mainMenuButton != null)
            {
                mainMenuButton.onClick.AddListener(SceneController.LoadMainMenu);
            }

            if (soundButton != null)
            {
                iconSound = soundButton.GetComponentsInChildren<Image>()[1];
                soundButton.onClick.AddListener(OnClickMute);
            }
        }

        private void OnClickMute()
        {
            iconSound.sprite = SoundManager.Instance.Mute() ? muteImage : unMuteImage;
        }
    }
}