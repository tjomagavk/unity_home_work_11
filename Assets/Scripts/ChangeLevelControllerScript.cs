using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLevelControllerScript : MonoBehaviour
{
    [SerializeField] private List<Button> levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        if (levelButtons != null)
        {
            for (int i = 0; i < levelButtons.Count; i++)
            {
                var index = i;
                levelButtons[i].onClick.AddListener(delegate { SceneController.LoadScene(index + 1); });
            }
        }
    }
}