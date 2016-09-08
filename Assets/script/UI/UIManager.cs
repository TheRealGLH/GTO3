using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : Singleton<UIManager>
{

    public GameObject GameOverPanel;
    public Text GameOverScoreText;
    public Text GameOverCoinText;


    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {

    }

    public void ShowGameOverScreen()
    {
        GameOverPanel.SetActive(true);
        GameOverScoreText.text = "Score: " + GameManager.Instance.GetScore();
        GameOverCoinText.text = "Coins: " + GameManager.Instance.GetCoins();
    }
}
