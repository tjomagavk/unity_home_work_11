using UnityEngine;
using WildBall.Constants;

namespace WildBall
{
    public class MechanismButton : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagVars.Player))
            {
                animator.SetBool("Enable", true);
            }
        }
    }
}