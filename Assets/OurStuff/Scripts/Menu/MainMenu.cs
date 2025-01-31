﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        //Plays game from main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Quits application
        Debug.Log("quit");
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        //Returns to mainmenu from end screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
