using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource _securitySound;
    [SerializeField] private AudioSource _farmsSound;
    [SerializeField] private AudioSource _clickSound;

    private SettingsController _audioSettings;

    private void Start()
    {
        _audioSettings = GetComponent<SettingsController>();
        _audioSettings.LoadSettings();
        if (!_audioSettings.audioSettings.SoundOn)
        {
            _securitySound.mute = true;
            _farmsSound.mute = true;
            _clickSound.mute = true;
        }
        else
        {
            _securitySound.mute = false;
            _farmsSound.mute = false;
            _clickSound.mute = false;
        }
    }
}
