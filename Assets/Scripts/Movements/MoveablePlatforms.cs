using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatforms : MoveableObs
{
    protected override float Distance => 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
}
