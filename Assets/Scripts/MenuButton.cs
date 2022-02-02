using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneController.LoadScene(0);
    }
}