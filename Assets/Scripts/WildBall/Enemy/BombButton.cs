using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using WildBall.Constants;
using WildBall.UI;
using Zenject;

namespace WildBall.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class BombButton : MonoBehaviour
    {
        private PopupScreen popup;
        [SerializeField] private int boomRadius;
        [SerializeField] private float boomPower;
        [SerializeField] private GameObject boomPoint;
        private Animator animator;
        private bool isEnable = true;

        [Inject]
        private void Construct(PopupScreen popup)
        {
            this.popup = popup;
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private IEnumerator Boom()
        {
            float currentTime = 5f;

            while (currentTime >= 0)
            {
                currentTime -= Time.fixedDeltaTime;
                string currentTimeStr = Math.Round(currentTime, 1).ToString(CultureInfo.InvariantCulture);
                popup.ShowText("Осталось: " + currentTimeStr + ". Беги!");

                yield return new WaitForFixedUpdate();
            }

            popup.HiddenText();
            if (FindObjectsOfType(typeof(Rigidbody)) is Rigidbody[] physicObjects)
            {
                foreach (Rigidbody physicObject in physicObjects)
                {
                    var distance = Vector3.Distance(boomPoint.transform.position, physicObject.transform.position);
                    if (distance < boomRadius)
                    {
                        physicObject.GetComponent<Rigidbody>()
                            .AddExplosionForce(boomPower, boomPoint.transform.position, boomRadius);
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isEnable && other.CompareTag(TagVars.Player))
            {
                popup.ShowText("Нажмите E");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(TagVars.Player))
            {
                popup.HiddenText();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (isEnable && other.CompareTag(TagVars.Player))
            {
                if (Input.GetAxis(AxisInputVars.Action) != 0)
                {
                    isEnable = false;
                    popup.HiddenText();
                    animator.SetTrigger("ActivateTrigger");
                    StartCoroutine(Boom());
                }
            }
        }
    }
}