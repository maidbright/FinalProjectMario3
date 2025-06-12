using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Mario_movement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private CapsuleCollider2D collider2D;
    private Animator animator;
    private SpriteRenderer renderer;
    private GameObject currentPlatform;

    [SerializeField] private float runSpeed = .6f;
    [SerializeField] private float jumpForce = 4.0f;
    [SerializeField] private bool isGround = true;

    public static float rayDistance = 0.6f;
    public CapsuleCollider2D CapsuleCollider2D { get { return collider2D = collider2D ?? GetComponent<CapsuleCollider2D>(); } }
    public Rigidbody2D Rb2D { get { return rigidbody2D = rigidbody2D ?? GetComponent<Rigidbody2D>(); } }
    public Animator PlayerAnim { get { return animator = animator ?? GetComponent<Animator>(); } }
    public SpriteRenderer PlayerRend { get { return renderer = renderer ?? GetComponent<SpriteRenderer>(); } }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Rb2D.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));  // LayerMask.GetMask("Ground")
        isGround = hit.collider != null ? true : false;

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            Run(Input.GetAxisRaw("Horizontal"));
        }
        else
        {
            IdleState();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
        if (currentPlatform != null)
        { StartCoroutine(DisableCollision()); }

    }

    public IEnumerator DisableCollision() //when on platform -- ognore collision ?????
    {
        EdgeCollider2D platformColl = currentPlatform.GetComponent<EdgeCollider2D>();
        Physics2D.IgnoreCollision(CapsuleCollider2D, platformColl);
        yield return new WaitForSeconds(0.1f);
        Physics2D.IgnoreCollision(CapsuleCollider2D, platformColl, false);
    }

    void Run(float inputX)
    {

        if (inputX < 0 && !PlayerRend.flipX)
        {
            PlayerAnim.SetTrigger("Rotate");
            PlayerRend.flipX = true;
        }
        else if ((inputX > 0 && PlayerRend.flipX))
        {
            PlayerRend.flipX = false;
        }

        PlayerAnim.SetFloat("Run", 1);
        Rb2D.velocity = new Vector2(inputX * runSpeed, Rb2D.velocity.y);
    }

    void IdleState()
    {
        PlayerAnim.SetFloat("Run", 0);
        if (isGround)
        {
            PlayerAnim.SetBool("IsGround", true);
        }
    }

    void Jump()
    {
        PlayerAnim.SetFloat("Run", 0);
        PlayerAnim.SetBool("IsGround", false);

        Rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGround = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)  //mov grounds colls
    {
        if (collision.gameObject.tag == "MovingGround")
        {
            this.transform.parent = collision.transform;
            currentPlatform = collision.gameObject;
            isGround = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            currentPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "MovingGround")
        {
            this.transform.parent = null;
            currentPlatform = null;
            isGround = false;
        }
        if (collision.gameObject.tag == "Ground")
        {
            currentPlatform = null;
        }
    } //mov grounds colls

}
