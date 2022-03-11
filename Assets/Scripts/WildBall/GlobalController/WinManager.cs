using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Mechanism;

namespace WildBall.GlobalController
{
    public class WinManager
    {
        private List<KeyPoint> keyPoints;
        private ParticleSystem rocket;
        private bool finalLevel;

        public int KeysLeft()
        {
            int count = keyPoints.Count;
            keyPoints.ForEach(point =>
            {
                if (!point.isActiveAndEnabled)
                {
                    count--;
                }
            });

            return count;
        }

        public WinManager(List<KeyPoint> keyPoints, ParticleSystem rocket, bool finalLevel)
        {
            this.keyPoints = keyPoints;
            this.rocket = rocket;
            this.finalLevel = finalLevel;
        }

        public bool IsConditionsMet()
        {
            return KeysLeft() == 0;
        }

        public bool IsLastLevel()
        {
            return finalLevel;
        }

        public void RunRocket()
        {
            if (rocket != null)
            {
                rocket.Play();
            }
        }
    }
}