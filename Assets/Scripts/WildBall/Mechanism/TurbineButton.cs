using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Constants;
using WildBall.UI;
using Zenject;

namespace WildBall.Mechanism
{
    [RequireComponent(typeof(Animator))]
    public class TurbineButton : MonoBehaviour
    {
        [SerializeField] private List<Turbine> turbines;
        private PopupScreen popup;
        private bool isEnable = true;

        [Inject]
        private void Construct(PopupScreen popup)
        {
            this.popup = popup;
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
                    foreach (Turbine turbine in turbines)
                    {
                        turbine.ChangeState();
                    }

                    popup.HiddenText();
                    StartCoroutine(Enable());
                }
            }
        }

        private IEnumerator Enable()
        {
            yield return new WaitForSeconds(2f);
            isEnable = true;
        }
    }
}