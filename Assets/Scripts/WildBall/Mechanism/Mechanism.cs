using UnityEngine;

namespace WildBall.Mechanism
{
    [RequireComponent(typeof(Animator))]
    public class Mechanism : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void ChangeAnimation()
        {
            animator.SetFloat("NextAnimation", Random.Range(0, 3f));
        }
    }
}