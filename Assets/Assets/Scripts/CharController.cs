using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class CharController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask groundLayer;        
    [SerializeField]
    private int amountOfJumps;
    [SerializeField]
    private float wallSlidingSpeed;
    [SerializeField]
    private Vector2 wallJumpForce;
    [SerializeField]
    private Vector2 wallHopForce;

    private Rigidbody2D rigid;
    private Animator anim;
    private BoxCollider2D box2d;

    private float movementInputDirection;
    private int facingDirection = 1; // 1 = right, -1 = left
    private bool isWallSliding;
    private bool isRunning;
    private bool canJump;
    private int amountOfJumpsLeft;

    private void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        box2d = this.gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
        CheckIfWallSliding();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void CheckMovementDirection()
    {
        if (facingDirection == 1 && movementInputDirection < 0)
        {
            FlipCharacter();
        }
        else if (facingDirection == -1 && movementInputDirection > 0)
        {
            FlipCharacter();
        }

        if (rigid.velocity.x != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private void ApplyMovement()
    {
        if (IsGrounded())
        {
            rigid.velocity = new Vector2(movementInputDirection * moveSpeed, rigid.velocity.y);
        }        
        else if (!IsGrounded() && !isWallSliding && movementInputDirection != 0)
        {
            rigid.velocity = new Vector2(movementInputDirection * moveSpeed, rigid.velocity.y);
        }

        if (isWallSliding)
        {
            if (rigid.velocity.y < wallSlidingSpeed)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, wallSlidingSpeed);
            }            
        }
    }

    private void UpdateAnimations()
    {
        anim.SetFloat("yVelocity", rigid.velocity.y);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isGrounded", IsGrounded());
        anim.SetBool("isWallSliding", isWallSliding);
    }

    private void CheckIfWallSliding()
    {
        if (!IsGrounded() && IsTouchingWall() && rigid.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void CheckIfCanJump()
    {
        if ((IsGrounded() && rigid.velocity.y == 0) || isWallSliding)
        {
            amountOfJumpsLeft = amountOfJumps;
        }
        
        if (amountOfJumpsLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    private void Jump()
    {
        if (canJump && !isWallSliding)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            amountOfJumpsLeft--;
        }
        else if (isWallSliding && !IsGrounded() && canJump && movementInputDirection != 0) // wall jump
        {
            isWallSliding = false;
            FlipCharacter();
            amountOfJumpsLeft--;

            Vector2 forceToAdd = new Vector2(wallJumpForce.x * facingDirection, wallJumpForce.y);
            rigid.AddForce(forceToAdd, ForceMode2D.Impulse);
        }
        else if (isWallSliding && !IsGrounded() && canJump && movementInputDirection == 0)
        {
            isWallSliding = false;
            FlipCharacter();
            amountOfJumpsLeft--;

            Vector2 forceToAdd = new Vector2(wallHopForce.x * facingDirection, wallHopForce.y);
            rigid.AddForce(forceToAdd, ForceMode2D.Impulse);
        }
    }

    private void FlipCharacter()
    {
        if (!isWallSliding)
        {
            facingDirection *= -1;
            this.transform.localScale = new Vector3(facingDirection, 1f, 1f);
        }        
    }

    private bool IsTouchingWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(box2d.bounds.center, new Vector2(facingDirection, 0f), (box2d.size.x / 2f) + 0.1f, groundLayer);
        return hit.collider != null;
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }

}
