using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            new WaitForSeconds(5.0f);
            LevelTransition.ChangeScene(0);
        }
    }
}
