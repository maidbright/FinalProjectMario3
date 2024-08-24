using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranyaMovement : MoveableObs
{
    private SpriteRenderer renderer;
    private Animator animator;
    private Shooting shooter;
    protected override float Distance => .35f;
    protected override float SpeedMove => 0.1f;
    public SpriteRenderer SRenderer { get { return renderer = renderer ?? GetComponent<SpriteRenderer>(); } }
    public Animator Anim { get { return animator = animator ?? GetComponent<Animator>(); } }
    public Shooting Shooter { get { return shooter = shooter ?? GetComponent<Shooting>(); } }

    void Start()
    {
        Initialize();
    }
    public override IEnumerator StartCycle(float distance)   //moveup/down
    {
        Vector2 startPos = transform.position;
        Vector2 velocity = Vector2.down * SpeedMove;

        while (true)
        {
            if (transform.position.y > startPos.y + Distance)
            {
                Shooter.Shoot();

                yield return new WaitForSeconds(15.0f);

                velocity.y = -SpeedMove; //one step

            }
            
            else if (transform.position.y < startPos.y)
            {
                yield return new WaitForSeconds(10.0f);
                velocity.y = SpeedMove;
            }
            transform.position += (Vector3)velocity * Time.deltaTime;
            yield return null;
        }

    }
}
