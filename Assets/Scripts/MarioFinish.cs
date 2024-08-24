using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Finish") && GameManager.Instance.timeLeft > 0)
        {
            GameManager.Instance.ExitGame();
        }
    }
}
