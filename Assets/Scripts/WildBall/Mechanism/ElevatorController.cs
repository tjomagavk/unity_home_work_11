using UnityEngine;
using WildBall.Constants;

namespace WildBall.Mechanism
{
    public class ElevatorController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private LeverHandleController leverOne;
        [SerializeField] private LeverHandleController leverTwo;

        private bool leverOneUpPosition = true;
        private bool leverTwoUpPosition = true;

        private void LateUpdate()
        {
            if (leverOne.UpPosition != leverOneUpPosition)
            {
                leverOneUpPosition = leverOne.UpPosition;
                leverTwoUpPosition = leverOneUpPosition;
                leverTwo.SetPosition(leverOneUpPosition);
                ChangePosition();
            }
            else if (leverTwo.UpPosition != leverTwoUpPosition)
            {
                leverTwoUpPosition = leverTwo.UpPosition;
                leverOneUpPosition = leverTwoUpPosition;
                leverOne.SetPosition(leverTwoUpPosition);
                ChangePosition();
            }
        }

        private void ChangePosition()
        {
            animator.SetTrigger("ChangePosition");
        }
    }
}