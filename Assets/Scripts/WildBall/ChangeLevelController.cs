using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WildBall.GlobalController;

namespace WildBall
{
    public class ChangeLevelController : MonoBehaviour
    {
        [SerializeField] private List<Button> levelButtons;

        private void Start()
        {
            if (levelButtons != null)
            {
                for (int i = 0; i < levelButtons.Count; i++)
                {
                    var index = i;
                    levelButtons[i].onClick.AddListener(delegate { SceneController.LoadScene(index + 1); });
                }
            }
        }
    }
}