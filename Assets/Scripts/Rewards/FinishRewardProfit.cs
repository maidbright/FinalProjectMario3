using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRewardProfit : Reward
{
    protected override float ScorePoint => 1000.0f;
    public override void RewardProfit()
    {
        GameManager.Instance.UpdateScore(ScorePoint);
    }
}
