using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private bool isPaused = false;
    private bool isForcePaused = false;
    private int score;
    private int coinsCollected;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {

    }

    public void ShowEndGameScreen()
    {
        TogglePause(true);
        UIManager.Instance.ShowGameOverScreen();
    }

    public void TogglePause(bool ForcePause = false)
    {
        if (isForcePaused) return;//There is no way out of a force pause!
        if (ForcePause)
        {
            isPaused = true;
            isForcePaused = true;
        }
        else isPaused = !isPaused;

        if(isPaused)
        {
            print("paused!");
        }
        else
        {
            print("back into the action!");
        }
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    public int GetCoins()
    {
        return coinsCollected;
    }
    public int GetScore()
    {
        return score;
    }



}