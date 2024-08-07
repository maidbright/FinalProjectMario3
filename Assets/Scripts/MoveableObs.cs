using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObs : MonoBehaviour, ICycleMovebale
{
    float _distance = 0.5f;
    float _speedMove = .4f;
    public float Distance { get; set; }
    public float SpeedMove { get; set; }
    void Start()
    {
        Initialize(_distance, _speedMove);
    }

    public void Initialize(float distance, float speed)
    {
        Distance = distance;
        SpeedMove = speed;
        StartCoroutine(e_StartCycle());
    }

    public IEnumerator e_StartCycle()
    {
        yield return new WaitForSeconds(1.0f);
        Vector2 startPos = transform.position;
        Vector2 velocity = Vector2.right * SpeedMove;

        while (true) //sh b depended on CM image 
        {
            if (transform.position.x > startPos.x + Distance)
            {
                velocity.x = -SpeedMove; //one step
            }
            else if (transform.position.x < startPos.x - Distance)
            {
                velocity.x = SpeedMove;
            }
            transform.position += (Vector3)velocity * Time.deltaTime;
            yield return null;
        }

    }
}
