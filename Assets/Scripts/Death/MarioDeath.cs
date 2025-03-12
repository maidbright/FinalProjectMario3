using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioDeath : Death
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer renderer;
    private bool isDead = false;
    public Rigidbody2D d_Rb2D { get { return rigidbody2D = rigidbody2D ?? GetComponent<Rigidbody2D>(); } }
    public SpriteRenderer d_PlayerRend { get { return renderer = renderer ?? GetComponent<SpriteRenderer>(); } }

    void Update()
    {  

        if (d_Rb2D.position.y <= deathPoint && !isDead)
        {
            isDead = true;
            FallingDeath();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathBy(collision, "Enemy"); //?
    }

    public override void DeathBy(Collision2D collision, string collLayer)
    {
        if (collision.gameObject.layer == 8) //by enemy
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y == 0 && point.normal.x != 0) //custommethod
                {
                    d_Anim.SetTrigger("Dead");
                    ///ÇÀÄÅÐÆÊÀ
                    GameManager.Instance.GameOver();
                    break;
                }
            }
        }
        if (collision.gameObject.layer == 12) //by enemy_fireball
        {
            d_Anim.SetTrigger("Dead");
            ///ÇÀÄÅÐÆÊÀ
            GameManager.Instance.GameOver();
        }
    }

    public override void FallingDeath()
    {
        GameManager.Instance.GameOver();
    }

}
