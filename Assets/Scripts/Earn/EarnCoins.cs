using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnCoins : Earn
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        e_Animator.SetTrigger("GetSmth");
        //instance of the coin high
        CreationOfPrefab();
    }

    public override void CreationOfPrefab()
    {
        throw new System.NotImplementedException();
    }
}
