using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{

    private Image _currentImage;
    [SerializeField] private Image _musicImg;
    [SerializeField] private Image _soundImg;

    [SerializeField] private Sprite _on;
    [SerializeField] private Sprite _off;

    private SettingsController _audioSettings;

    void Start()
    {
        _currentImage = GetComponent<Image>();
        _audioSettings = GetComponent<SettingsController>();
        _audioSettings.LoadSettings();
        ChangeSprite();
    }

    public void OnOffClick()
    {
        if (_currentImage.sprite == _on)
        {
            _currentImage.sprite = _off;
        }
        else
        {
            _currentImage.sprite = _on;
        }
    }

    public void CheckSprite(bool voiceStatus)
    {
        if (!voiceStatus)
        {
            _currentImage.sprite = _off;
        }
        else
        {
            _currentImage.sprite = _on;
        }
    }

    public void ChangeSprite()
    {
        if (_audioSettings.audioSettings.MusicOn == false)
        {
            _musicImg.sprite = _off;
        }
        else
        {
            _musicImg.sprite = _on;
        }
        if (_audioSettings.audioSettings.SoundOn == false)
        {
            _soundImg.sprite = _off;
        }
        else
        {
            _soundImg.sprite = _on;
        }
    }
}
