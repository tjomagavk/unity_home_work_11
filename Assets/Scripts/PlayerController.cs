using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FailTrigger"))
        {
            SceneController.ReloadScene();
        }
        else if (other.CompareTag("FinishTrigger"))
        {
            _playerMovement.StopAndDisable();
            SceneController.LoadNextScene();
        }
    }
}