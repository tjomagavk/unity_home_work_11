using UnityEngine;
using WildBall.Constants;
using Zenject;

namespace WildBall.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float jumpForce = 80f;

        private bool isGrounded;
        private bool enableMovement;
        private Rigidbody playerRigidbody;

        private PlayerState playerState;

        [Inject]
        private void Construct(PlayerState playerState)
        {
            this.playerState = playerState;
        }

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            enableMovement = true;
        }

        public void Stop()
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            playerRigidbody.useGravity = false;
            Disable();
        }

        public void Disable()
        {
            enableMovement = false;
        }

        public void MovementLogic(Vector3 movement)
        {
            if (IsEnableMovement())
            {
                float speed = this.speed * playerState.MoveScale();
                if (!isGrounded)
                {
                    speed /= 3;
                }

                playerRigidbody.AddForce(movement * speed);
            }
        }

        public void MovementIgnoreDisable(Vector3 movement)
        {
            playerRigidbody.AddForce(movement);
        }

        public void JumpLogic()
        {
            if (IsEnableMovement() && isGrounded)
            {
                playerRigidbody.AddForce(Vector3.up * jumpForce * playerState.MoveScale());
            }
        }

        public bool IsEnableMovement()
        {
            return enableMovement;
        }

        private void OnCollisionEnter(Collision collision)
        {
            IsGroundedUpdate(collision, true);
        }

        private void OnCollisionStay(Collision collision)
        {
            IsGroundedUpdate(collision, true);
        }

        private void OnCollisionExit(Collision collision)
        {
            IsGroundedUpdate(collision, false);
        }

        private void IsGroundedUpdate(Collision collision, bool value)
        {
            if (collision.gameObject.CompareTag(TagVars.Ground))
            {
                isGrounded = value;
            }
        }
    }
}