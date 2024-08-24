using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetActiveEnum : MonoBehaviour //++
{
    public SpriteRenderer[] rewardSprites;

    private void Start()
    {
        StartCoroutine(Activate());
    }
    public IEnumerator Activate()
    {
        while(true)
        {
            foreach (var reward in rewardSprites)
            {
                if (!reward.enabled)
                {
                    reward.enabled = true;
                }
                yield return new WaitForSeconds(.3f);
                if (reward.enabled)
                {
                    reward.enabled = false;
                }
            }
            yield return null ;
        }
    }
    
}
