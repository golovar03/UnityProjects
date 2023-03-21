using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonController : MonoBehaviour
{

    [SerializeField] private Image _pauseButton;
    [SerializeField] private Image _muteButton;

    [SerializeField] private Sprite _startGame;
    [SerializeField] private Sprite _pauseGame;
    [SerializeField] private Sprite _onMute;
    [SerializeField] private Sprite _offMute;

    [SerializeField] private new AudioListener audio;
    [SerializeField] private GameObject manager;
    void Start()
    {
        _pauseButton.sprite = _pauseGame;
        _muteButton.sprite = _offMute;
    }
    
    public void PauseButtonClick()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            _pauseButton.sprite = _startGame;
            manager.SetActive(false);

        }
        else
        {
            Time.timeScale = 1;
            _pauseButton.sprite = _pauseGame;
            manager.SetActive(true);
        }
    }

    public void MuteClick()
    {
        if (audio.enabled == true)
        {
            audio.enabled = false;
            _muteButton.sprite = _onMute;
        }
        else
        {
            audio.enabled = true;
            _muteButton.sprite = _offMute;
        }
    }

}
