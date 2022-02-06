using UnityEngine;
using WildBall.Constants;

namespace WildBall
{
    [RequireComponent(typeof(Animator))]
    public class BridgeController : MonoBehaviour
    {
        private Animator animator;
        private bool isDrop;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!isDrop && collision.gameObject.CompareTag(TagVars.Player))
            {
                animator.SetTrigger("DropTrigger");
                isDrop = true;
            }
        }
    }
}