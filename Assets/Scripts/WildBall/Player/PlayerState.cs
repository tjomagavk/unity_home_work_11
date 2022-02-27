using UnityEngine;

namespace WildBall.Player
{
    public class PlayerState
    {
        private PlayerType playerType = Player.PlayerType.PAPER;

        private GameObject paper;
        private GameObject wood;

        public PlayerType PlayerType() => playerType;

        public PlayerState(PlayerType playerType)
        {
            this.playerType = playerType;
        }
    }
}