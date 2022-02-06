using UnityEngine;
using WildBall.GlobalController;

namespace WildBall.UI
{
    public class MainMenuScreen : MonoBehaviour
    {
        public void LoadFirstLevel()
        {
            SceneController.LoadScene(1);
        }
    }
}