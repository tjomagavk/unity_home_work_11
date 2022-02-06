using System;
using UnityEngine;
using WildBall.Constants;
using WildBall.GlobalController;

namespace WildBall.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement playerMovement;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagVars.FailTrigger))
            {
                SceneController.ReloadScene();
            }
            else if (other.CompareTag(TagVars.FinishTrigger))
            {
                playerMovement.StopAndDisable();
                SceneController.LoadNextScene();
            }
        }
    }
}