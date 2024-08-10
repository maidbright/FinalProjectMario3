using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaDeath : MonoBehaviour
{
    private Animator animator;
    private CapsuleCollider2D collider2D;
    public Animator d_GoombaAnim { get { return animator = animator ?? GetComponent<Animator>(); } }
    public CapsuleCollider2D d_CapsuleCollider2D { get { return collider2D = collider2D ?? GetComponent<CapsuleCollider2D>(); } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.6f)
                {
                    Death();
                }
            }
        }
    }
    void Death()
    {
        d_GoombaAnim.SetTrigger("IsDead");
        Destroy(this.gameObject, 1.0f);
    }
}
