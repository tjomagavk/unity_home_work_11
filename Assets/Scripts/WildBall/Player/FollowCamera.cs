using UnityEngine;

namespace WildBall.Player
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - playerTransform.position;
        }

        private void LateUpdate()
        {
            transform.position = playerTransform.position + offset;
        }
    }
}