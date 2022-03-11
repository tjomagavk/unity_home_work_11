using UnityEngine;
using WildBall.Constants;

namespace WildBall.Mechanism
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Collider pointA;
        [SerializeField] private Collider pointB;
        [SerializeField] private float secondsOnRoad = 3f;
        [SerializeField] private float secondsStop = 1f;
        private Vector3 startPosition;
        private Rigidbody rb;
        private float currentRoadTime;
        private float currentStopTime;
        private bool toPointA;

        private void Awake()
        {
            rb = gameObject.GetComponent<Rigidbody>();
            startPosition = gameObject.transform.position;
        }

        private void FixedUpdate()
        {
            if (currentStopTime <= 0)
            {
                Move();
            }
            else
            {
                currentStopTime -= Time.deltaTime;
            }
        }

        private void Move()
        {
            Vector3 to;
            if (toPointA)
            {
                to = pointB.transform.position;
            }
            else
            {
                to = pointA.transform.position;
            }

            currentRoadTime += Time.fixedDeltaTime;

            Vector3 newPosition = Vector3.Lerp(startPosition, to, currentRoadTime / secondsOnRoad);
            rb.MovePosition(newPosition);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagVars.MovingPlatformWall))
            {
                toPointA = !toPointA;
                currentRoadTime = 0;
                startPosition = transform.position;
                currentStopTime = secondsStop;
            }
        }
    }
}