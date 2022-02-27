using UnityEngine;
using UnityEngine.UI;
using WildBall.GlobalController;
using Zenject;

namespace WildBall.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private Sprite muteImage;
        [SerializeField] private Sprite unMuteImage;
        private SoundManager soundManager;
        private Button button;
        private Image iconSound;

        [Inject]
        private void Construct(SoundManager soundManager)
        {
            this.soundManager = soundManager;
        }

        private void Awake()
        {
            button = GetComponent<Button>();
            iconSound = button.GetComponentsInChildren<Image>()[1];
            button.onClick.AddListener(OnClickMute);
        }

        private void Start()
        {
            ChangeIcon();
        }

        private void OnClickMute()
        {
            soundManager.ChangeState();
            ChangeIcon();
        }

        private void ChangeIcon()
        {
            iconSound.sprite = soundManager.IsMute() ? muteImage : unMuteImage;
        }
    }
}