using System.Collections;
using UnityEngine;
using WildBall.Constants;
using WildBall.Player;
using Zenject;

namespace WildBall.Mechanism
{
    [RequireComponent(typeof(Animator))]
    public class TransformArea : MonoBehaviour
    {
        [SerializeField] private PlayerType playerType;
        [SerializeField] private ParticleSystem particleSystem;
        [SerializeField] private Material paperParticleMaterial;
        [SerializeField] private Material woodParticleMaterial;
        private Animator animator;
        private Vector3 centerPosition;
        private PlayerState playerState;

        [Inject]
        private void Construct(PlayerState playerState)
        {
            this.playerState = playerState;
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            centerPosition = transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagVars.Player) && playerState.PlayerType() != playerType)
            {
                Move(other.GetComponent<Rigidbody>());
            }
        }

        private void ChangeAnimation()
        {
            animator.SetTrigger("TransformTrigger");
        }

        public void ChangeState()
        {
            if (playerState.PlayerType() == PlayerType.WOOD)
            {
                particleSystem.GetComponent<ParticleSystemRenderer>().material = woodParticleMaterial;
            }
            else
            {
                particleSystem.GetComponent<ParticleSystemRenderer>().material = paperParticleMaterial;
            }

            playerState.ChangeState(playerType);
            particleSystem.Play();
        }

        private void Move(Rigidbody playerRb)
        {
            Vector3 to = centerPosition;
            to.y = playerRb.position.y;
            StartCoroutine(MoveObject(playerRb, to, 1f));
        }

        private IEnumerator MoveObject(Rigidbody rb, Vector3 to, float timeSec)
        {
            float currentTime = 0f;
            rb.isKinematic = true;
            // rigidbody.MovePosition(from);

            while (currentTime <= timeSec)
            {
                currentTime += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();

                Vector3 newPosition = Vector3.Lerp(rb.position, to, currentTime / timeSec);
                rb.MovePosition(newPosition);
            }

            ChangeAnimation();
            yield return new WaitForSeconds(2f);
            rb.isKinematic = false;
        }
    }
}