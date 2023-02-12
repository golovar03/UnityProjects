using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class OpeningTheLock : MonoBehaviour
{
    [SerializeField] private Text firstPasswordNumber;
    [SerializeField] private Text secondPasswordNumber;
    [SerializeField] private Text thirdPasswordNumber;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject lossGamePanel;
    [SerializeField] private GameObject winGamePanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject surrenderButton;
    private float timerValue;
    private bool timerStart = false;
    private Random randFirstNumber = new Random();
    private Random randSecondNumber = new Random();
    private Random randThirdNumber = new Random();


    public void StartGame()
    {
        timerValue = 90f;
        firstPasswordNumber.text = (randFirstNumber.Next(0, 9)).ToString();
        secondPasswordNumber.text = (randSecondNumber.Next(0, 9)).ToString();
        thirdPasswordNumber.text = (randThirdNumber.Next(0, 9)).ToString();
        timerText.text = timerValue.ToString();
        timerStart = !timerStart;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (timerStart == true)
        {
            if (Convert.ToSingle(timerText.text) > 0)
            {
                timerValue = timerValue - Time.deltaTime;
                timerText.text = timerValue.ToString("F1");
            }
            else
            {
                LoseGame();
            }
        }
    }

    public void EndGame()
    {
        
        if ((firstPasswordNumber.text + secondPasswordNumber.text + thirdPasswordNumber.text) == "385")
        {
            WinGame();
        }
        else if (timerValue - 5 > 0)
        {
            timerValue -= 5;
        }
        else
        {
            LoseGame();
        }
    }


    public void FirstButtonOnClick()
    {
        FirstButtonClick();
    }

    private void FirstButtonClick()
    {
        if (Convert.ToInt32(firstPasswordNumber.text) < 9 && Convert.ToInt32(firstPasswordNumber.text) >= 0)
        {
            firstPasswordNumber.text = (Convert.ToInt32(firstPasswordNumber.text) + 1).ToString();
        }
        else
        {
            firstPasswordNumber.text = "9";
        }
        if (Convert.ToInt32(secondPasswordNumber.text) <= 9 && Convert.ToInt32(secondPasswordNumber.text) > 0)
        {
            secondPasswordNumber.text = (Convert.ToInt32(secondPasswordNumber.text) - 1).ToString();
        }
        else
        {
            secondPasswordNumber.text = "0";
        }

    }

    public void SecondButtonOnClick()
    {
        SecondButtonClick();
    }

    private void SecondButtonClick()
    {
        if (Convert.ToInt32(firstPasswordNumber.text) <= 9 && Convert.ToInt32(firstPasswordNumber.text) > 1)
        {
            firstPasswordNumber.text = (Convert.ToInt32(firstPasswordNumber.text) - 1).ToString();
        }
        else
        {
            firstPasswordNumber.text = "0";
        }
        if (Convert.ToInt32(secondPasswordNumber.text) < 8 && Convert.ToInt32(secondPasswordNumber.text) >= 0)
        {
            secondPasswordNumber.text = (Convert.ToInt32(secondPasswordNumber.text) + 2).ToString();
        }
        else
        {
            secondPasswordNumber.text = "9";
        }
        if (Convert.ToInt32(thirdPasswordNumber.text) > 0 && Convert.ToInt32(thirdPasswordNumber.text) <= 9)
        {
            thirdPasswordNumber.text = (Convert.ToInt32(thirdPasswordNumber.text) - 1).ToString();
        }
        else
        {
            thirdPasswordNumber.text = "0";
        }
    }

    public void ThirdButtonOnClick()
    {
        ThirdButtonClick();
    }

    private void ThirdButtonClick()
    {
        if (Convert.ToInt32(firstPasswordNumber.text) <= 9 && Convert.ToInt32(firstPasswordNumber.text) > 1)
        {
            firstPasswordNumber.text = (Convert.ToInt32(firstPasswordNumber.text) - 1).ToString();
        }
        else
        {
            firstPasswordNumber.text = "0";
        }
        if (Convert.ToInt32(secondPasswordNumber.text) < 9 && Convert.ToInt32(secondPasswordNumber.text) >= 0)
        {
            secondPasswordNumber.text = (Convert.ToInt32(secondPasswordNumber.text) + 1).ToString();
        }
        else
        {
            secondPasswordNumber.text = "9";
        }
        if (Convert.ToInt32(thirdPasswordNumber.text) >= 0 && Convert.ToInt32(thirdPasswordNumber.text) < 9)
        {
            thirdPasswordNumber.text = (Convert.ToInt32(thirdPasswordNumber.text) + 1).ToString();
        }
        else
        {
            thirdPasswordNumber.text = "9";
        }
    }

    private void LoseGame()
    {
        timerStart = false;
        gamePanel.SetActive(false);
        lossGamePanel.SetActive(true);
    }
    private void WinGame()
    {
        timerStart = false;
        gamePanel.SetActive(false);
        winGamePanel.SetActive(true);
    }

    public void SurenderButtonOnClick()
    {
        LoseGame();
    }
}
