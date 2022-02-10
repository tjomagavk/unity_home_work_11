using UnityEngine;

namespace WildBall.Player
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        private Vector3 offset;
        private const float SpeedZoom = 2f;

        public void ChangeOffset(float change)
        {
            if (change == 0) return;

            float distance = Vector3.Distance(playerTransform.position, transform.position);
            Vector3 direction = Vector3.Normalize(offset) * distance * -change * SpeedZoom;
            offset += direction;
        }

        public void ChangeRotation(float changeX, float changeY)
        {
            if (changeX == 0 && changeY == 0) return;
            // offset.x += changeX;
            // offset.y += changeY;
            // // transform.eulerAngles = new Vector3(changeX * 5, changeY * 5, 0.0f);
            // // transform.position = positionForCamera;
            // //set camera rotation
            // transform.rotation = Quaternion.LookRotation(playerTransform.transform.position - transform.position, offset);
        }

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