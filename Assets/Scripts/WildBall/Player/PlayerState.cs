using UnityEngine;
using WildBall.Constants;

namespace WildBall.Player
{
    public class PlayerState : MonoBehaviour
    {
        private PlayerType playerType = Player.PlayerType.PAPER;

        public PlayerType PlayerType() => playerType;
    }
}