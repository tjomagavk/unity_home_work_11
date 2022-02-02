using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Sprite muteImage;
    [SerializeField] private Sprite unMuteImage;
    [SerializeField] private SoundManager soundManager;
    private Button _button;
    private Image _icon;

    private bool _mute;

    // Start is called before the first frame update
    void Start()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(OnClick);

        _icon = _button.GetComponentsInChildren<Image>()[1];
    }

    private void OnClick()
    {
        _mute = !_mute;
        SoundManager.Instance.Mute(_mute);
        _icon.sprite = _mute ? muteImage : unMuteImage;
    }
}