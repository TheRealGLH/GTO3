using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public int ScoreRaiseAmountEasy;
    public int ScoreRaiseAmountMedium;
    public int ScoreRaiseAmountHard;
    public int ScoreRaiseAmountExtreme;
    private bool isPaused = false;
    private bool isForcePaused = false;
    private int score;
    private int coinsCollected;
    private Player player;
    private int currentSceneIndex;

    public int scoreRaiseAmount { get; private set; }

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        scoreRaiseAmount = ScoreRaiseAmountEasy;
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

    public void PickupCoin()
    {
        print("kaching");
        coinsCollected++;
    }

    public void RaiseScore(int amount)
    {
        score += amount;
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void RaiseDifficulty(GameDifficulty diff)
    {
        player.MoveSpeed += 3;
        switch (diff)
        {
            case GameDifficulty.easy:
                scoreRaiseAmount = ScoreRaiseAmountEasy;//this isn't supposed to happen;
                break;
            case GameDifficulty.medium:
                scoreRaiseAmount = ScoreRaiseAmountMedium;
                break;
            case GameDifficulty.hard:
                scoreRaiseAmount = ScoreRaiseAmountHard;
                break;
            case GameDifficulty.EuropeanExtreme:
                scoreRaiseAmount = ScoreRaiseAmountExtreme;
                break;
            default:
                break;
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
    



}