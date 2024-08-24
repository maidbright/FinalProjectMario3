using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Reward : MonoBehaviour //to chnage
{

    protected float coins;
    protected float coinPoint = 1.0f;
    protected virtual float ScorePoint { get; } = 50;
    protected float score;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(this.gameObject, 0.2f);
            RewardProfit();
        }
    }

    public abstract void RewardProfit();

}
