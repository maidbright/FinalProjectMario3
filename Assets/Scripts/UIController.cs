using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI coinScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lifesText;
    private float coins = 0.0f;
    private float score = 0.0f;
    private int lifes = 5;
    private float time = 200.0f;
    private float timeLeft = 0f;


    private void Start()
    {
        coinScoreText.text += coins;
        lifesText.text += lifes;
        timerText.text += time;
        scoreText.text += score;
    }
    private void Update() //to change
    {
        if (coins != GameManager.Instance.coins)
        {
            coins = GameManager.Instance.coins;
            coinScoreText.text = "$"+ coins;
        }
        if (lifes != GameManager.Instance.lifes)
        {
            lifes += GameManager.Instance.lifes;
            lifesText.text = "Lifes: "+ lifes;
        }
        timerText = GameManager.Instance.timerText;
        if (score != GameManager.Instance.score)
        {
            score += GameManager.Instance.score;
            scoreText.text = "Score: "+ score;
        }
    }

}
