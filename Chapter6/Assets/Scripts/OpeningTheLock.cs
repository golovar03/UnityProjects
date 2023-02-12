using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class OpeningTheLock : MonoBehaviour
{
    [SerializeField] private Text _firstPasswordNumber;
    [SerializeField] private Text _secondPasswordNumber;
    [SerializeField] private Text _thirdPasswordNumber;
    [SerializeField] private Text _timerText;

    [SerializeField] private GameObject _lossGamePanel;
    [SerializeField] private GameObject _winGamePanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _surrenderButton;

    private float _timerValue;
    private bool _timerStart = false;

    private Random _randFirstNumber = new Random();
    private Random _randSecondNumber = new Random();
    private Random _randThirdNumber = new Random();

    public void StartGame()
    {
        _timerValue = 90f;
        _firstPasswordNumber.text = (_randFirstNumber.Next(0, 9)).ToString();
        _secondPasswordNumber.text = (_randSecondNumber.Next(0, 9)).ToString();
        _thirdPasswordNumber.text = (_randThirdNumber.Next(0, 9)).ToString();
        _timerText.text = _timerValue.ToString();
        _timerStart = !_timerStart;
    }

    private void Update()
    {
        if (_timerStart == true)
        {
            if (Convert.ToSingle(_timerText.text) > 0)
            {
                _timerValue = _timerValue - Time.deltaTime;
                _timerText.text = _timerValue.ToString("F1");
            }
            else
            {
                LoseGame();
            }
        }
    }

    public void EndGame()
    {
        if ((_firstPasswordNumber.text + _secondPasswordNumber.text + _thirdPasswordNumber.text) == "385")
        {
            WinGame();
        }
        else if (_timerValue - 5 > 0)
        {
            _timerValue -= 5;
        }
        else
        {
            LoseGame();
        }
    }

    public void FirstToolButtonOnClick()
    {
        UseFirstTool();
    }

    private void UseFirstTool()
    {
        if (Convert.ToInt32(_firstPasswordNumber.text) < 9 && Convert.ToInt32(_firstPasswordNumber.text) >= 0)
        {
            _firstPasswordNumber.text = (Convert.ToInt32(_firstPasswordNumber.text) + 1).ToString();
        }
        else
        {
            _firstPasswordNumber.text = "9";
        }
        if (Convert.ToInt32(_secondPasswordNumber.text) <= 9 && Convert.ToInt32(_secondPasswordNumber.text) > 0)
        {
            _secondPasswordNumber.text = (Convert.ToInt32(_secondPasswordNumber.text) - 1).ToString();
        }
        else
        {
            _secondPasswordNumber.text = "0";
        }
    }

    public void SecondToolButtonOnClick()
    {
        UseSecondTool();
    }

    private void UseSecondTool()
    {
        if (Convert.ToInt32(_firstPasswordNumber.text) <= 9 && Convert.ToInt32(_firstPasswordNumber.text) > 1)
        {
            _firstPasswordNumber.text = (Convert.ToInt32(_firstPasswordNumber.text) - 1).ToString();
        }
        else
        {
            _firstPasswordNumber.text = "0";
        }
        if (Convert.ToInt32(_secondPasswordNumber.text) < 8 && Convert.ToInt32(_secondPasswordNumber.text) >= 0)
        {
            _secondPasswordNumber.text = (Convert.ToInt32(_secondPasswordNumber.text) + 2).ToString();
        }
        else
        {
            _secondPasswordNumber.text = "9";
        }
        if (Convert.ToInt32(_thirdPasswordNumber.text) > 0 && Convert.ToInt32(_thirdPasswordNumber.text) <= 9)
        {
            _thirdPasswordNumber.text = (Convert.ToInt32(_thirdPasswordNumber.text) - 1).ToString();
        }
        else
        {
            _thirdPasswordNumber.text = "0";
        }
    }

    public void ThirdToolButtonOnClick()
    {
        UseThirdTool();
    }

    private void UseThirdTool()
    {
        if (Convert.ToInt32(_firstPasswordNumber.text) <= 9 && Convert.ToInt32(_firstPasswordNumber.text) > 1)
        {
            _firstPasswordNumber.text = (Convert.ToInt32(_firstPasswordNumber.text) - 1).ToString();
        }
        else
        {
            _firstPasswordNumber.text = "0";
        }
        if (Convert.ToInt32(_secondPasswordNumber.text) < 9 && Convert.ToInt32(_secondPasswordNumber.text) >= 0)
        {
            _secondPasswordNumber.text = (Convert.ToInt32(_secondPasswordNumber.text) + 1).ToString();
        }
        else
        {
            _secondPasswordNumber.text = "9";
        }
        if (Convert.ToInt32(_thirdPasswordNumber.text) >= 0 && Convert.ToInt32(_thirdPasswordNumber.text) < 9)
        {
            _thirdPasswordNumber.text = (Convert.ToInt32(_thirdPasswordNumber.text) + 1).ToString();
        }
        else
        {
            _thirdPasswordNumber.text = "9";
        }
    }

    private void LoseGame()
    {
        _timerStart = false;
        _gamePanel.SetActive(false);
        _lossGamePanel.SetActive(true);
    }
    private void WinGame()
    {
        _timerStart = false;
        _gamePanel.SetActive(false);
        _winGamePanel.SetActive(true);
    }

    public void SurenderButtonOnClick()
    {
        LoseGame();
    }
}
