using UnityEngine;
using UnityEngine.UI;
using WildBall.GlobalController;

namespace WildBall.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(SceneController.ReloadScene);
        }
    }
}