using System.Collections;
using UnityEngine;

public class TurtleMovement : MonoBehaviour, ICycleMovebale
{
    [SerializeField] float _distance = 2.0f;
    [SerializeField] float _speedMove = .2f;
    private SpriteRenderer renderer; 
    public SpriteRenderer SpriteRenderer { get { return renderer = renderer ?? GetComponent<SpriteRenderer>(); } }

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
            if (transform.position.x > startPos.x + Distance)
            {
                SpriteRenderer.flipX = false;
                velocity.x = -SpeedMove; //one step
            }
            else if (transform.position.x < startPos.x)
            {
                velocity.x = SpeedMove;
                SpriteRenderer.flipX = true;
            }
            transform.position += (Vector3)velocity * Time.deltaTime;
            yield return null;
        }
    }


}
