using UnityEngine;
using UnityEngine.UI;

namespace WildBall.UI
{
    public class PopupScreen : MonoBehaviour
    {
        [SerializeField] private Text text;

        public void ShowText(string showText)
        {
            text.text = showText;
            gameObject.SetActive(true);
        }

        public void HiddenText()
        {
            gameObject.SetActive(false);
        }
    }
}