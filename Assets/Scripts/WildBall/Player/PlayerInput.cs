using UnityEngine;
using WildBall.Constants;

namespace WildBall.Player
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private PlayerMovement playerMovement;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void FixedUpdate()
        {
            if (playerMovement.IsEnableMovement())
            {
                MovementLogic();
                JumpLogic();
            }
        }

        private void MovementLogic()
        {
            float moveHorizontal = Input.GetAxis(AxisInputVars.Horizontal);

            float moveVertical = Input.GetAxis(AxisInputVars.Vertical);

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            playerMovement.MovementLogic(movement);
        }

        private void JumpLogic()
        {
            if (Input.GetAxis(AxisInputVars.Jump) > 0)
            {
                playerMovement.JumpLogic();
            }
        }
    }
}