using System.Collections;
using UnityEngine;

namespace WildBall.Mechanism
{
    [RequireComponent(typeof(Rigidbody))]
    public class ElevatorController : MonoBehaviour
    {
        [SerializeField] private Transform pointDown;
        [SerializeField] private Transform pointUp;
        [SerializeField] private LeverHandleController leverOne;
        [SerializeField] private LeverHandleController leverTwo;

        private Rigidbody elevatorRigidbody;
        public float timeSec = 5f;

        private bool leverOneUpPosition = true;
        private bool leverTwoUpPosition = true;

        private void Awake()
        {
            elevatorRigidbody = GetComponent<Rigidbody>();
            StartCoroutine(MoveObject(pointDown.position, pointUp.position, timeSec));
        }

        public void Move()
        {
            if (transform.position == pointDown.position)
            {
                StartCoroutine(MoveObject(pointDown.position, pointUp.position, timeSec));
            }
            else if (transform.position == pointUp.position)
            {
                StartCoroutine(MoveObject(pointUp.position, pointDown.position, timeSec));
            }
        }


        private IEnumerator MoveObject(Vector3 from, Vector3 to, float timeSec)
        {
            float currentTime = 0f;
            elevatorRigidbody.MovePosition(from);

            while (currentTime <= timeSec)
            {
                currentTime += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();

                Vector3 newPosition = Vector3.Lerp(from, to, currentTime / timeSec);
                elevatorRigidbody.MovePosition(newPosition);
            }
        }

        private void LateUpdate()
        {
            if (leverOne.UpPosition != leverOneUpPosition)
            {
                leverOneUpPosition = leverOne.UpPosition;
                leverTwoUpPosition = leverOneUpPosition;
                leverTwo.SetPosition(leverOneUpPosition);
                Move();
            }
            else if (leverTwo.UpPosition != leverTwoUpPosition)
            {
                leverTwoUpPosition = leverTwo.UpPosition;
                leverOneUpPosition = leverTwoUpPosition;
                leverOne.SetPosition(leverTwoUpPosition);
                Move();
            }
        }
    }
}