using UnityEngine;
using WildBall.Constants;
using WildBall.GlobalController;
using Zenject;

namespace WildBall.Mechanism
{
    [RequireComponent(typeof(Animator))]
    public class KeyPoint : MonoBehaviour
    {
        private Animator animator;
        private WinManager winManager;

        [Inject]
        private void Construct(WinManager winManager)
        {
            this.winManager = winManager;
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagVars.Player)) animator.SetTrigger("TouchTrigger");
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}