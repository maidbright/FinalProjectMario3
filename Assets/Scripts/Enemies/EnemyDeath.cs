using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private CapsuleCollider2D collider2D;
    public CapsuleCollider2D CapsuleCollider2D { get { return collider2D = collider2D ?? GetComponent<CapsuleCollider2D>(); } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.transform.position.y > CapsuleCollider2D.transform.position.y)
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
