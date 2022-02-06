using UnityEngine;
using WildBall.Constants;

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

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            enableMovement = true;
        }

        public void StopAndDisable()
        {
            Disable();
            playerRigidbody.isKinematic = true;
        }

        public void Disable()
        {
            enableMovement = true;
        }

        public void MovementLogic(Vector3 movement)
        {
            if (IsEnableMovement())
            {
                float speed = this.speed;
                if (!isGrounded)
                {
                    speed /= 3;
                }

                playerRigidbody.AddForce(movement * speed);
            }
        }

        public void JumpLogic()
        {
            if (IsEnableMovement() && isGrounded)
            {
                playerRigidbody.AddForce(Vector3.up * jumpForce);
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