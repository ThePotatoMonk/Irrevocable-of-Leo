using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject endScreen;


    // events
    private void OnEnable()
    {
        GameManager.OnPlayerDeath += EnableEndScreen;
        Boss.OnBossDeath += EnableEndScreen;
    }  
    private void OnDisable()
    {
        GameManager.OnPlayerDeath -= EnableEndScreen;
        Boss.OnBossDeath -= EnableEndScreen;
    }

    // Sets end screen active
    public void EnableEndScreen()
    {
        endScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("CellarMain");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
