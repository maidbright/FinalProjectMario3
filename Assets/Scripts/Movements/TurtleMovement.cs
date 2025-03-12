using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TurtleMovement : MoveableObs
{
    public bool isCollided;

    private Animator animator;
    private SpriteRenderer renderer;
    public Animator t_Anim { get { return animator = animator ?? GetComponent<Death>().d_Anim; } } //do in oth way
    public SpriteRenderer SRenderer { get { return renderer = renderer ?? GetComponent<SpriteRenderer>(); } }
    protected override float Distance => 2.0f;



    void Start()
    {
        Initialize();
    }

    public override IEnumerator StartCycle(float distance)
    {
        yield return new WaitForSeconds(1.0f);
        Vector2 startPos = transform.position;
        Vector2 velocity = Vector2.right * SpeedMove;


        while (true) 
        {
            if(isCollided)  //for changing beh depend on GO anim state //можно ли пользуя пивот спрайта, обратиться к нему через код?
            {
                if (transform.position.x > startPos.x + distance * 3)
                {
                    velocity.x = -SpeedMove;
                }
                else if (transform.position.x < startPos.x)
                {
                    velocity.x = SpeedMove;
                }
            }
            else 
            {
                if (transform.position.x > startPos.x + distance)
                {
                    SRenderer.flipX = false;
                    velocity.x = -SpeedMove;
                }
                else if (transform.position.x < startPos.x)
                {
                    velocity.x = SpeedMove;
                    SRenderer.flipX = true;
                }
            }

            transform.position += (Vector3)velocity * Time.deltaTime;
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollided = true;
        MoveBy(collision, "Player"); 

    }
    private void MoveBy(Collision2D collision, string collLayer)   //ROUNDED BY MARIO
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(collLayer)) 
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.6f)
                {
                    isCollided = false;
                    t_Anim.SetTrigger("Rotate");
                    t_Anim.SetTrigger("Stay");
                    t_Anim.SetTrigger("Walk");
                }
            }
        }
    }
}
