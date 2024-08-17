using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour //gets changes from game sets on game, to change
{
    public TextMeshProUGUI coinScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lifesText;
    public float coins = 0.0f;
    public float score = 0.0f;
    public int lifes = 5; 
    public float timer = 200.0f;



    private void Start()
    {
        coinScoreText.text += coins;
        scoreText.text += score;
        timerText.text += timer;
        lifesText.text +=lifes;
    }

}
