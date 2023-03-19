using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] private Sprite _onSound;
    [SerializeField] private Sprite _offSound;

    private Image _currentImage;
    
    void Start()
    {
        _currentImage = GetComponent<Image>();
    }

    public void OnOffClick()
    {
        if (_currentImage.sprite == _onSound)
        {
            _currentImage.sprite = _offSound;
        }
        else
        {
            _currentImage.sprite = _onSound;
        }
    }
}
