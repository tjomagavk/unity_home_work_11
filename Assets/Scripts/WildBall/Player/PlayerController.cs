using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Constants;
using WildBall.GlobalController;
using WildBall.UI;

namespace WildBall.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private LevelScreenController levelScreenController;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            GameObject levelScreen = GameObject.FindWithTag(TagVars.LevelScreen);
            if (levelScreen == null)
            {
                throw new ArgumentNullException("LevelScreen");
            }

            levelScreenController = levelScreen.GetComponent<LevelScreenController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagVars.FailTrigger))
            {
                playerMovement.Disable();
                StartCoroutine(DeathScreenTimer());
            }
            else if (other.CompareTag(TagVars.FinishTrigger))
            {
                playerMovement.StopAndDisable();
                SceneController.LoadNextScene();
            }
        }

        private IEnumerator DeathScreenTimer()
        {
            yield return new WaitForSeconds(1);
            levelScreenController.DeathActive();
        }
    }
}