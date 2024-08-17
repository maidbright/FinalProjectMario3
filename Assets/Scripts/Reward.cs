using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Reward : MonoBehaviour //to chnage
{
    public TextMeshProUGUI coinScoreText;
    public static TextMeshProUGUI scoreText;
    protected float coins;
    protected float coinPoint = 1.0f;
    protected abstract float ScorePoint { get; }
    protected static float score;
    protected GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //singleton
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(this.gameObject, 0.2f);
        }
    }

    public abstract void RewardProfit();

}
