using UnityEngine;

namespace WildBall.Enemy
{
    public class Hammer : MonoBehaviour
    {
        [SerializeField] private HammerWorkArea hammerWorkArea;

        public void StartPosition()
        {
            hammerWorkArea.StartPosition();
        }

        public void UpperStrike()
        {
            hammerWorkArea.UpperStrike();
        }

        public void NotUpperStrike()
        {
            hammerWorkArea.NotUpperStrike();
        }
    }
}