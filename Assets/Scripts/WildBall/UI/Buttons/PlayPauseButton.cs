using UnityEngine;
using UnityEngine.UI;
using WildBall.GlobalController;

namespace WildBall.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class PlayPauseButton : MonoBehaviour
    {
        private Button button;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(SceneController.ChangePlayPause);
        }

        public Button GetButton()
        {
            return button;
        }
    }
}