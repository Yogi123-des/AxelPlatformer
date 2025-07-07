using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Axel : MonoBehaviour
{
    //public fields
    public float Speed = 1;
    //Private fields
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    const float groundCheckRadius = 0.2f;
    float horizontalValue;
    float runSpeed = 2f;
    public float jumpPower = 500;
    bool jump = false;
    bool isGrounded = false;
    bool isRunning = false;
    bool facingRight = true;
    
   

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        //store the horizontal value
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, jump);
    }

    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    void Move(float dir, bool jumpFlag)
    {
        if (isGrounded && jumpFlag)
        {
            isGrounded = false;
            jumpFlag = false;
            rb.AddForce(new Vector2(0f, jumpPower));
        }


        #region Move and Run
        float xVal = dir * Speed * Time.fixedDeltaTime;
        if (isRunning)
        {
            xVal *= runSpeed;
        }
        Vector2 targetVelocity = new Vector2(xVal, rb.linearVelocityY);
        rb.linearVelocity = targetVelocity;

        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-4, 4, 4);
            facingRight = false;
        }
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(4, 4, 4);
            facingRight = true;
        }

        animator.SetFloat("Blend", Mathf.Abs(rb.linearVelocityX));
        #endregion

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheckCollider.position, groundCheckRadius);
    }
}

