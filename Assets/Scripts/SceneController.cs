using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;

    public static SceneController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneController>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("SceneController");
                    _instance = container.AddComponent<SceneController>();
                }
            }

            return _instance;
        }
    }

    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void LoadNextScene()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene + 1);
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}