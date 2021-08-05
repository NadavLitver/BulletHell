﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public UnityEvent PlayerLost;
    public UnityEvent PlayerWon;
    private void Awake()
    {
        gm = this;
        if (PlayerLost == null)
            PlayerLost = new UnityEvent();
        if(PlayerWon == null)
            PlayerWon = new UnityEvent();

    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); ;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
