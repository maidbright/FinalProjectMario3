using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMario_movement : MonoBehaviour
{

    [SerializeField] public float runSpeed = 1.2f;
    [SerializeField] public float jumpForce = 25.0f;
    public bool isGround;
    [SerializeField] public float rayDistance = 0.1f;
    //RaycastHit2D hit;
    public CapsuleCollider2D CapsuleCollider2D { get { return collider2D = collider2D ?? GetComponent<CapsuleCollider2D>(); } }
    public Rigidbody2D Rigidbody2D { get { return rigidbody2D = rigidbody2D ?? GetComponent<Rigidbody2D>(); } }

    private Rigidbody2D rigidbody2D;
    private CapsuleCollider2D collider2D;

    void FixedUpdate()
    {
        Run(Input.GetAxisRaw("Horizontal"));
        RaycastHit2D hit = Physics2D.Raycast(Rigidbody2D.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
        isGround = hit.collider != null ? true : false;

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();

        }


    }

    void Run(float inputX)
    {
        Rigidbody2D.velocity = new Vector2(inputX * runSpeed, 0);
    }

    void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGround = false;
    }
}
