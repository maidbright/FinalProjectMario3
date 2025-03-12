using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionWithMario : MonoBehaviour
{
    private PiranyaMovement m_Movement;
    public PiranyaMovement PiranyaMovement { get { return m_Movement = m_Movement ?? GetComponentInChildren<PiranyaMovement>(); } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Collided"); //collided but not stopped
            m_Movement.StopCoroutine("StartCycle");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            m_Movement.StartCoroutine("StartCycle");
        }
    }
}
