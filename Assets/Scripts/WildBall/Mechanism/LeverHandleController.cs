using System;
using UnityEngine;
using WildBall.Constants;
using WildBall.UI;

namespace WildBall.Mechanism
{
    public class LeverHandleController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PopupScreen popup;
        private bool upPosition;
        public bool UpPosition => upPosition;

        private void Start()
        {
            upPosition = true;
            SetPosition(upPosition);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagVars.Player))
            {
                popup.ShowText("Нажмите E");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(TagVars.Player))
            {
                popup.HiddenText();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(TagVars.Player))
            {
                if (Input.GetAxis(AxisInputVars.Action) != 0)
                {
                    SetPosition(!upPosition);
                }
            }
        }

        public void SetPosition(bool isUp)
        {
            if (isUp != upPosition)
            {
                upPosition = isUp;
                animator.SetBool("UpPosition", upPosition);
            }
        }
    }
}