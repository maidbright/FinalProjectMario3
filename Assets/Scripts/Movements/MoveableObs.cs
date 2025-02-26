using System.Collections;
using UnityEngine;

public abstract class MoveableObs : MonoBehaviour
{
    protected float _distance;
    protected float _speedMove =.3f;
    protected abstract float Distance { get; }
    protected virtual float SpeedMove { get; set; }

    public virtual void Initialize()
    {
        SpeedMove = _speedMove;
        StartCoroutine(StartCycle(Distance));
    }

    public virtual IEnumerator StartCycle(float distance)
    {
        yield return new WaitForSeconds(1.0f);
        Vector2 startPos = transform.position;
        Vector2 velocity = Vector2.right * SpeedMove;

        while (true) 
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
