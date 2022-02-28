using System.Collections;
using UnityEngine;
using WildBall.Constants;
using WildBall.Player;
using Zenject;

namespace WildBall.Enemy
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class GlassTile : MonoBehaviour
    {
        private Rigidbody rb;
        private PlayerState playerState;

        [Inject]
        private void Construct(PlayerState playerState)
        {
            this.playerState = playerState;
        }

        public void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(TagVars.Player) && playerState != null)
            {
                if (PlayerType.WOOD == playerState.PlayerType())
                {
                    StartCoroutine(Crack(.1f));
                }
                else if (PlayerType.PAPER == playerState.PlayerType())
                {
                }
                else
                {
                    StartCoroutine(Crack(0));
                }
            }
        }

        private IEnumerator Crack(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}