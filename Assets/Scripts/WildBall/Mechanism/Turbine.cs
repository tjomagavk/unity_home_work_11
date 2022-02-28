using System;
using UnityEngine;
using WildBall.Constants;

namespace WildBall.Mechanism
{
    [RequireComponent(typeof(Animator))]
    public class Turbine : MonoBehaviour
    {
        [SerializeField] private WindZone windZone;
        [SerializeField] bool enable;
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            Ololo();
        }

        public void ChangeState()
        {
            enable = !enable;
            Ololo();
        }

        private void Ololo()
        {
            windZone.Enable(enable);
            if (enable)
            {
                animator.SetTrigger("StartTrigger");
            }
            else
            {
                animator.SetTrigger("StopTrigger");
            }
        }
    }
}