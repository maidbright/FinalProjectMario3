using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Death : MonoBehaviour
{
    protected Animator animator;
    protected CapsuleCollider2D collider2D;
    public static float deathPoint = -2.0f;
    public Animator d_Anim { get { return animator = animator ?? GetComponent<Animator>(); } }
    public CapsuleCollider2D d_CapsuleCollider2D { get { return collider2D = collider2D ?? GetComponent<CapsuleCollider2D>(); } }
    public virtual void DeathBy(Collision2D collision, string collLayer)
    {
        return;
    }

    public virtual void FallingDeath() 
    {
        Destroy(this.gameObject, 5.0f);
    }

}
