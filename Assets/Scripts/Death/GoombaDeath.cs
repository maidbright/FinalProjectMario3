using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaDeath : Death
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathBy(collision, "Player"); 
    }

    public override void DeathBy(Collision2D collision, string collLayer)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(collLayer)) //by player
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 1.6f)
                {
                    Debug.Log($"{point.normal.y}");
                    d_Anim.SetBool("IsDead", true);
                    d_CapsuleCollider2D.enabled = false; //for absence collision after goombadeath 
                    Destroy(this.gameObject, 1.5f);
                    break;
                }
            }
        }
    }
}
