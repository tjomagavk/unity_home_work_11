using UnityEngine;

namespace WildBall.Player
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - player.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}