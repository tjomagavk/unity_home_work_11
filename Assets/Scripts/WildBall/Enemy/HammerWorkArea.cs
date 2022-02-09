using System;
using UnityEngine;
using WildBall.Constants;

namespace WildBall.Enemy
{
    [RequireComponent(typeof(BoxCollider))]
    public class HammerWorkArea : MonoBehaviour
    {
        private Vector3 startPosition;

        public void StartPosition()
        {
            startPosition = gameObject.transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagVars.Player))
            {
                Vector3 vector3 = startPosition - gameObject.transform.position;
                vector3.x = -vector3.x;
                vector3.z = -vector3.z;
                other.GetComponent<Rigidbody>().AddForce(vector3.normalized * 20, ForceMode.Impulse);
            }
        }
    }
}