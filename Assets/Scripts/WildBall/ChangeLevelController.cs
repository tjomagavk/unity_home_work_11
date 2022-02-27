using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using WildBall.GlobalController;
using Zenject;

namespace WildBall
{
    public class ChangeLevelController : MonoBehaviour
    {
        [SerializeField] private List<Button> levelButtons;
        private SceneController sceneController;

        [Inject]
        private void Construct(SceneController sceneController)
        {
            this.sceneController = sceneController;
        }

        private void Start()
        {
            if (levelButtons != null)
            {
                for (int i = 0; i < levelButtons.Count; i++)
                {
                    var index = i;
                    levelButtons[i].onClick.AddListener(delegate { sceneController.LoadScene(index + 1); });
                }
            }
        }
    }
}