public class TurtleDeath : Death
{
    private void Update()
    {
        if (d_CapsuleCollider2D.transform.position.y <= deathPoint)
        {
            FallingDeath();
        }
    }
}
