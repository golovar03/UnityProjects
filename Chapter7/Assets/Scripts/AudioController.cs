using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _backGroudSound;
    
    private AudioSource _clickSound;
    
    private float _savedMusicVolume;
    private float _savedClickVolume;

    
    void Start()
    {
        _clickSound = GetComponent<AudioSource>();
        _savedClickVolume = _clickSound.volume;
        _savedMusicVolume = _backGroudSound.volume;
        _backGroudSound.Play();
    }

    public void ClickMenuButton()
    {
        _clickSound.Play();
    }

    public void OnOffMusic()
    {
        if(_backGroudSound.volume > 0f)
        {
            _backGroudSound.volume = 0f;
        }
        else
        {
            _backGroudSound.volume = _savedMusicVolume;
        }
    }

    public void OnOffSounds()
    {
        if(_clickSound.volume > 0f)
        {
            _clickSound.volume = 0f;
        }
        else
        {
            _clickSound.volume = _savedClickVolume;
        }
    }
}
