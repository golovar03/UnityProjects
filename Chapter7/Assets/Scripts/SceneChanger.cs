using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int ID)
    {
        SceneManager.LoadScene(ID);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
