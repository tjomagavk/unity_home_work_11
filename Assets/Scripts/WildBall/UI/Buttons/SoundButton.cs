using UnityEngine;
using UnityEngine.UI;
using WildBall.GlobalController;

namespace WildBall.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private Sprite muteImage;
        [SerializeField] private Sprite unMuteImage;
        private Button button;
        private Image iconSound;
        private bool muteSound;

        private void Awake()
        {
            button = GetComponent<Button>();
            iconSound = button.GetComponentsInChildren<Image>()[1];
            button.onClick.AddListener(OnClickMute);
        }

        private void OnClickMute()
        {
            iconSound.sprite = SoundManager.Instance.Mute() ? muteImage : unMuteImage;
        }
    }
}