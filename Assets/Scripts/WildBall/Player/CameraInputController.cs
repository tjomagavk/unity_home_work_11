using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Constants;
using WildBall.GlobalController;
using WildBall.UI;

namespace WildBall.Player
{
    [RequireComponent(typeof(CameraMovement))]
    public class CameraInputController : MonoBehaviour
    {
        private CameraMovement cameraMovement;

        private void Awake()
        {
            cameraMovement = GetComponent<CameraMovement>();
        }

        private void Update()
        {
            ZoomLogic();
            MovementLogic();
        }

        private void ZoomLogic()
        {
            float zoom = Input.GetAxis(AxisInputVars.MouseScrollWheel);

            cameraMovement.ChangeOffset(zoom);
        }

        private void MovementLogic()
        {
            float moveHorizontal = Input.GetAxis(AxisInputVars.MouseX);

            float moveVertical = Input.GetAxis(AxisInputVars.MouseY);

            cameraMovement.ChangeRotation(moveHorizontal, moveVertical);
        }
    }
}