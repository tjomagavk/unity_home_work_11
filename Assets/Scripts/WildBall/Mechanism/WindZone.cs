using UnityEngine;
using WildBall.Constants;

namespace WildBall.Mechanism
{
    public class WindZone : MonoBehaviour
    {
        [SerializeField] private float windStrength = 100f;
        [SerializeField] private ParticleSystem particleSystem;
        private Vector3 centerPosition;
        private readonly Vector3 windDirection = Vector3.up;

        private void Awake()
        {
            centerPosition = transform.position;
        }

        public void Enable(bool enable)
        {
            gameObject.GetComponent<Collider>().enabled = enable;
            if (enable)
            {
                particleSystem.Play();
            }
            else
            {
                particleSystem.Stop();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(TagVars.Player))
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                Vector3 to = centerPosition;
                to.y = rb.position.y;
                Vector3 newPosition = Vector3.Lerp(rb.position, to, Time.fixedDeltaTime);
                rb.MovePosition(newPosition);
                rb.AddForce(windDirection * windStrength);
            }
        }
    }
}