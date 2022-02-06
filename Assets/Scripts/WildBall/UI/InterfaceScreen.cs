using UnityEngine;
using WildBall.UI.Buttons;

namespace WildBall.UI
{
    public class InterfaceScreen : MonoBehaviour
    {
        [SerializeField] private PlayPauseButton pauseButton;
        [SerializeField] private RestartButton restartButton;
        [SerializeField] private SoundButton soundButton;

        public PlayPauseButton PauseButton => pauseButton;
        public RestartButton RestartButton => restartButton;
        public SoundButton SoundButton => soundButton;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}