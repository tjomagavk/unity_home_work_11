using UnityEngine;
using UnityEngine.UI;
using WildBall.GlobalController;
using Zenject;

namespace WildBall.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class MainMenuButton : MonoBehaviour
    {
        private SceneController sceneController;

        [Inject]
        private void Construct(SceneController sceneController)
        {
            this.sceneController = sceneController;
        }

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(sceneController.LoadMainMenu);
        }
    }
}