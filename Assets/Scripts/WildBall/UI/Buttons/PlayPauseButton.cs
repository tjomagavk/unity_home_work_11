using UnityEngine;
using UnityEngine.UI;
using WildBall.GlobalController;
using Zenject;

namespace WildBall.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class PlayPauseButton : MonoBehaviour
    {
        private SceneController sceneController;
        private Button button;

        [Inject]
        private void Construct(SceneController sceneController)
        {
            this.sceneController = sceneController;
        }

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(sceneController.ChangePlayPause);
        }

        public Button GetButton()
        {
            return button;
        }
    }
}