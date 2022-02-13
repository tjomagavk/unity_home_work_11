using System.Collections;
using UnityEngine;
using WildBall.Constants;
using WildBall.Player;

namespace WildBall.Enemy
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class GlassTile : MonoBehaviour
    {
        private Rigidbody rigidbody;
        private PlayerState playerState;

        public void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            playerState = FindObjectOfType<PlayerState>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(TagVars.Player) && playerState != null)
            {
                if (PlayerType.WOOD == playerState.PlayerType())
                {
                    StartCoroutine(Crack(.1f));
                }
                else
                {
                    StartCoroutine(Crack(.1f));
                }
            }
        }

        private IEnumerator Crack(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
        }
    }
}