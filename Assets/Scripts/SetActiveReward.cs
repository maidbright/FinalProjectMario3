using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetActiveReward : MonoBehaviour
{
    public SpriteRenderer[] rewardSprite;
    void Start()
    {
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        foreach(var reward in rewardSprite)
        {
            if(!reward.enabled)
            {
                reward.enabled = true;
            }
            else
            {
                reward.enabled = false;
            }
            yield return null;
        }
    }
}
