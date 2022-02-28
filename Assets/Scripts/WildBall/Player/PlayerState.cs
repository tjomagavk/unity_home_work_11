using UnityEngine;

namespace WildBall.Player
{
    public class PlayerState
    {
        private PlayerType playerType;
        private float moveScale = 1f;
        private const float DeathTimePaper = 1f;
        private const float DeathTimeWood = 10f;
        private float deathTime = DeathTimePaper;
        private readonly GameObject playerObject;
        private readonly PlayerMovement playerMovement;

        private readonly ParticleSystem playerFireParticleSystem;
        private readonly ParticleSystem playerBurnedParticleSystem;
        private readonly GameObject paper;
        private readonly GameObject wood;

        public PlayerType PlayerType() => playerType;
        public float DeathTime() => deathTime;
        public float MoveScale() => moveScale;

        public PlayerState(
            PlayerType playerType,
            GameObject playerObject,
            ParticleSystem playerFireParticleSystem,
            ParticleSystem playerBurnedParticleSystem,
            GameObject paper,
            GameObject wood)
        {
            this.playerType = playerType;
            this.playerObject = playerObject;
            playerMovement = playerObject.GetComponent<PlayerMovement>();
            this.playerFireParticleSystem = playerFireParticleSystem;
            this.playerBurnedParticleSystem = playerBurnedParticleSystem;
            this.paper = paper;
            this.wood = wood;
        }

        public void ChangeState(PlayerType playerType)
        {
            this.playerType = playerType;

            if (this.playerType == Player.PlayerType.WOOD)
            {
                moveScale = 3f;
                deathTime = DeathTimeWood;
            }
            else
            {
                moveScale = 1f;
                deathTime = DeathTimePaper;
            }

            Rigidbody newRb = GetState().GetComponent<Rigidbody>();
            MeshRenderer newSkin = GetState().transform.Find("BallInner").GetComponent<MeshRenderer>();
            MeshRenderer skin = playerObject.transform.Find("BallInner").GetComponent<MeshRenderer>();

            skin.materials = newSkin.sharedMaterials;

            playerObject.GetComponent<Rigidbody>().mass = newRb.mass;
            playerObject.GetComponent<Rigidbody>().drag = newRb.drag;
            playerObject.GetComponent<Rigidbody>().angularDrag = newRb.angularDrag;
        }

        public GameObject GetState()
        {
            if (playerType == Player.PlayerType.WOOD)
            {
                return wood;
            }

            return paper;
        }

        public bool IsDeathTime()
        {
            deathTime -= Time.deltaTime;
            if (!playerFireParticleSystem.isPlaying)
            {
                playerFireParticleSystem.Play();
            }

            if (deathTime < 0)
            {
                playerMovement.Stop();
                playerObject.GetComponent<Collider>().enabled = false;
                playerObject.transform.Find("BallInner").GetComponent<MeshRenderer>().enabled = false;
                playerFireParticleSystem.Stop();
                playerBurnedParticleSystem.transform.position = playerObject.transform.position;
                playerBurnedParticleSystem.Play();
                return true;
            }

            return false;
        }

        public void Recovery()
        {
            if ((playerType == Player.PlayerType.WOOD && deathTime < DeathTimeWood)
                || (playerType == Player.PlayerType.PAPER && deathTime < DeathTimePaper))
            {
                deathTime += Time.deltaTime;
                playerFireParticleSystem.transform.position = playerObject.transform.position;
            }
            else
            {
                playerFireParticleSystem.Stop();
            }
        }
    }
}