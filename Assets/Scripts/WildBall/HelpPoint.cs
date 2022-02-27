using UnityEngine;
using WildBall.Constants;
using WildBall.UI;
using Zenject;

namespace WildBall
{
    public class HelpPoint : MonoBehaviour
    {
        [SerializeField] private string text;
        private PopupScreen popup;

        [Inject]
        private void Construct(PopupScreen popup)
        {
            this.popup = popup;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagVars.Player))
            {
                popup.ShowText(text);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(TagVars.Player))
            {
                popup.HiddenText();
            }
        }
    }
}