using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _backGroudSound; 
    
    private AudioSource _clickSound;

    private float _currentVolume;
    
    void Start()
    {
        _clickSound = GetComponent<AudioSource>();
        _currentVolume = AudioListener.volume;
        _backGroudSound.Play();
    }

    void Update()
    {
        
    }

    public void ClickMenuButton()
    {
        _clickSound.Play();
    }

    public void OnOffSounds()
    {
        if(AudioListener.volume > 0f)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = _currentVolume;
        }
    }
}
