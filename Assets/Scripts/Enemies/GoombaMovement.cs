using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour, ICycleMovebale
{
    [SerializeField] float _distance = 0.87f;
    [SerializeField] float _speedMove = .2f;
    public float Distance { get; set; }
    public float SpeedMove { get; set; }
    void Start()
    {
        Initialize(_distance, _speedMove);
        StartCoroutine(e_StartCycle());
    }

    public void Initialize(float distance, float speed)
    {
        Distance = distance;
        SpeedMove = speed;
    }

    public IEnumerator e_StartCycle()
    {
        yield return new WaitForSeconds(1.0f);
        Vector2 startPos = transform.position;
        Vector2 velocity = Vector2.right * SpeedMove;

        while (true) //sh b depended on CM image 
        {
            if(transform.position.x > startPos.x + Distance)
            {
                velocity.x = -SpeedMove; //one step
            }
            else if(transform.position.x < startPos.x - Distance)
            {
                velocity.x = SpeedMove;
            }
            transform.position += (Vector3)velocity * Time.deltaTime;
            yield return null;
        }

    }
}
