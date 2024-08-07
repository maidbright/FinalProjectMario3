using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICycleMovebale 
{
    float Distance { get; set; }
    float SpeedMove { get; set; }

    public void Initialize(float distance, float speed);
    public IEnumerator e_StartCycle();
}
