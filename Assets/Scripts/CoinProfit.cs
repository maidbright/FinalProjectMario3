public class CoinProfit : Reward
{
    protected override float ScorePoint => 100.0f;
    public override void RewardProfit()
    {
        coins += coinPoint;
        score += ScorePoint;
        gameManager.scoreText.text += score;
        gameManager.coinScoreText.text += coins;
        
    }
}
