using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioDeath : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private float rayDistance = 1.0f;
    private CapsuleCollider2D collider2D;
    private SpriteRenderer renderer;

    public CapsuleCollider2D d_CapsuleCollider2D { get { return collider2D = collider2D ?? GetComponent<CapsuleCollider2D>(); } }
    public Rigidbody2D d_Rb2D { get { return rigidbody2D = rigidbody2D ?? GetComponent<Rigidbody2D>(); } }
    public Animator d_PlayerAnim { get { return animator = animator ?? GetComponent<Animator>(); } }
    public SpriteRenderer d_PlayerRend { get { return renderer = renderer ?? GetComponent<SpriteRenderer>(); } }

    void Update()
    {
        RaycastHit2D hitD = Physics2D.Raycast(d_Rb2D.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
        if (hitD == null)
        {
            FallingDeath();
        }
    }

    void FallingDeath()
    {
        d_PlayerAnim.SetTrigger("Dead");
        Invoke("Respawn", 2.0f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            d_PlayerAnim.SetTrigger("Dead");
            d_PlayerRend.sortingOrder = 2;
            Invoke("Respawn", 2.0f);
        }
    }
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
    }

}
