using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FailTrigger"))
        {
            _sceneController.ReloadScene();
        }
        else if (other.CompareTag("FinishTrigger"))
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeScene + 1);
        }
    }
}