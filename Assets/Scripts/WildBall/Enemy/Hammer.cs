using System;
using UnityEngine;
using WildBall.Constants;

namespace WildBall.Enemy
{
    public class Hammer : MonoBehaviour
    {
        [SerializeField] private HammerWorkArea hammerWorkArea;

        public void StartPosition()
        {
            hammerWorkArea.StartPosition();
        }
    }
}