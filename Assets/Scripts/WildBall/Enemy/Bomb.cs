using System;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Constants;

namespace WildBall.Enemy
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private int boomRadius;
        [SerializeField] private float boomPower;
        private Rigidbody[] physicObjects;

        private void Start()
        {
            physicObjects = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
        }

        public void Boom()
        {
            foreach (Rigidbody physicObject in physicObjects)
            {
                var distance = Vector3.Distance(gameObject.transform.position, physicObject.transform.position);
                if (distance < boomRadius)
                {
                    physicObject.GetComponent<Rigidbody>()
                        .AddExplosionForce(boomPower, gameObject.transform.position, boomRadius);
                }
            }
        }
    }
}