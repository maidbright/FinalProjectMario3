public class CoinProfit : Reward
{
    protected override float ScorePoint { get; } = 100.0f;
    
    public override void RewardProfit()
    {
        GameManager.Instance.UpdateScore(ScorePoint);
        GameManager.Instance.UpdateCoinScore(coinPoint);
        
    }
}
