using System.Collections.Generic;
using UnityEngine;
using WildBall.Mechanism;

namespace WildBall.GlobalController
{
    public class WinManager
    {
        private List<KeyPoint> keyPoints;

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

        public WinManager(List<KeyPoint> keyPoints)
        {
            this.keyPoints = keyPoints;
        }

        public bool IsConditionsMet()
        {
            return KeysLeft() == 0;
        }
    }
}