using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GoombaDeath : Death
{
    private GoombaMovement goombaMovementInstance;
    public GoombaMovement GoombaMovementInstance { get { return goombaMovementInstance = goombaMovementInstance ?? GetComponent<GoombaMovement>(); } } 
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
                Debug.Log($"Goomba {point.normal.y},{point.normal.x}");
                if (point.normal.y < 0 && point.normal.x <0)  
                    goombaMovementInstance.StopAllCoroutines();
                    d_Anim.SetBool("IsDead", true);
                    Destroy(this.gameObject, 1.7f);
                    break;
                
            }
        }
    }
}
