using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject lossGameScreen;
    [SerializeField] private GameObject winGameScreen;


    private GameObject currentScreen;
    void Start()
    {
        mainMenuScreen.SetActive(true);
        currentScreen = mainMenuScreen;
    }

    public void ChangeState(GameObject state)
    {
        if(currentScreen != null)
        {
            currentScreen.SetActive(false);
            state.SetActive(true);
            currentScreen = state;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
   
}
