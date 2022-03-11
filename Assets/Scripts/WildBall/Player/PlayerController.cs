using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using WildBall.Constants;
using WildBall.GlobalController;
using WildBall.UI;
using Zenject;

namespace WildBall.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private LevelScreenController levelScreenController;
        private bool isWin;
        private bool dying;
        private PopupScreen popup;
        private WinManager winManager;
        private PlayerState playerState;

        [Inject]
        private void Construct(PopupScreen popup, WinManager winManager, PlayerState playerState)
        {
            this.popup = popup;
            this.winManager = winManager;
            this.playerState = playerState;
        }

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

        private void FixedUpdate()
        {
            if (!dying)
            {
                playerState.Recovery();
            }

            if (isWin)
            {
                playerMovement.MovementIgnoreDisable(Vector3.up);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(TagVars.Fire))
            {
                dying = true;
            }
            else if (other.CompareTag(TagVars.FailTrigger))
            {
                playerMovement.Disable();
                StartCoroutine(DeathScreenTimer());
            }
            else if (other.CompareTag(TagVars.FinishTrigger))
            {
                if (winManager.IsConditionsMet())
                {
                    WinAction();
                }
                else
                {
                    popup.ShowText("Не все ключи найдены. Осталось " + winManager.KeysLeft());
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag(TagVars.Fire))
            {
                string currentTimeStr = Math.Round(playerState.DeathTime(), 1).ToString(CultureInfo.InvariantCulture);
                if (playerState.IsDeathTime())
                {
                    popup.HiddenText();
                    StartCoroutine(DeathScreenTimer());
                }
                else
                {
                    popup.ShowText("Ты горишь!. Осталось: " + currentTimeStr + ". Беги!");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(TagVars.Fire))
            {
                dying = false;
            }

            popup.HiddenText();
        }

        private void WinAction()
        {
            playerMovement.Stop();
            StartCoroutine(WinScreenTimer());
            isWin = true;
            if (winManager.IsLastLevel())
            {
                winManager.RunRocket();
            }
        }


        private IEnumerator DeathScreenTimer()
        {
            yield return new WaitForSeconds(1);
            levelScreenController.DeathActive();
        }

        private IEnumerator WinScreenTimer()
        {
            yield return new WaitForSeconds(1);
            if (winManager.IsLastLevel())
            {
                levelScreenController.FinalWinActive();
            }
            else
            {
                levelScreenController.WinActive();
            }
        }
    }
}