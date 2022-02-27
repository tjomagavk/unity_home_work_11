using UnityEngine;
using WildBall.GlobalController;
using Zenject;

namespace WildBall.UI
{
    public class MainMenuScreen : MonoBehaviour
    {
        private SceneController sceneController;

        [Inject]
        private void Construct(SceneController sceneController)
        {
            this.sceneController = sceneController;
        }

        public void LoadFirstLevel()
        {
            sceneController.LoadScene(1);
        }
    }
}