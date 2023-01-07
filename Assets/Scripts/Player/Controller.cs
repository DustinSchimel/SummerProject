using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;

public abstract class Controller : NetworkBehaviour
{
    [Header("References")]
    protected PauseMenu pauseMenu;
    protected Rigidbody2D rb;
    protected PlayerInputActions playerInputActions;
    protected SpriteRenderer sprite;
    protected Animator animator;
    [SerializeField] protected TrailRenderer tr;

    [Header("Direction")]
    public bool facingRight;

    [Header("Movement")]
    public float moveSpeed;
    public float acceleration;
    public float decceleration;
    public float velPower;
    [Space(10)]
    public float frictionAmount;

    [Header("Jump")]
    public float jumpForce;
    [Range(0, 1)]
    public float jumpCutMultiplier;
    [Space(10)]
    public float jumpCoyoteTime;
    protected float lastGroundedTime;
    public float jumpBufferTime;
    protected float lastJumpTime;
    [Space(10)]
    public float fallGravityMultiplier;
    protected float gravityScale;
    [Space(10)]
    protected bool isJumping;

    [Header("Dash")]
    [SerializeField] protected bool dashUnlocked;
    protected bool canDash;
    protected bool isDashing;
    [SerializeField] protected float dashForce;
    [SerializeField] protected float dashTime;
    [SerializeField] protected float dashCooldown;
    [Tooltip("How much to reduce the velocity by due to traveling diagonally")]
    [SerializeField] protected float diagonalReduction;


    [Header("Checks")]
    public Transform groundCheckPoint;
    public Vector2 groundCheckSize;
    [Space(10)]
    public LayerMask groundLayer;

    public void onDeath()
    {
        canDash = false;
        isDashing = false;
        lastGroundedTime = jumpCoyoteTime;
        lastJumpTime = 0;
        isJumping = false;
    }

    protected void Flip()
    {
        Vector2 currentScale = sprite.transform.localScale;
        currentScale.x *= -1;
        sprite.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    protected void Dash(InputAction.CallbackContext context)
    {
        if (canDash && dashUnlocked)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    protected IEnumerator DashCoroutine()
    {
        Vector2 moveInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;    // maybe make gravity less once dash is over
        rb.gravityScale = 0f;
        tr.emitting = true;

        if (moveInput.y != 0)   // Player is trying to move up/down
        {
            if (moveInput.x != 0)    // Player is trying to move right/left as well
            {
                rb.velocity = new Vector2(sprite.transform.localScale.x  * dashForce * diagonalReduction, 
                                        dashForce * (moveInput.y / Math.Abs(moveInput.y)) * diagonalReduction);
            }
            else if (moveInput.x == 0)  // Player is JUST trying to move up/down
            {
                rb.velocity = new Vector2(0f, dashForce * (moveInput.y / Math.Abs(moveInput.y)));
            }

            if (moveInput.y > 0)
            {
                lastGroundedTime = 0;
                lastJumpTime = 0;
                isJumping = true;
            }
        }
        else if (moveInput.x != 0)    // Player is JUST trying move right/left
        {
            rb.velocity = new Vector2(sprite.transform.localScale.x  * dashForce, 0f);
        }
        else if (moveInput.x == 0 && moveInput.y == 0)
        {
            // If the player is not moving any specific way, check which way they are facing and dash that way
            rb.velocity = new Vector2(sprite.transform.localScale.x * dashForce, 0f);
        }

        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        rb.velocity = new Vector2(0f, 0f);
        isDashing = false;

        //yield return new WaitForSeconds(dashCooldown);
        //canDash = true;
    }

    protected void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        lastGroundedTime = 0;
        lastJumpTime = 0;
        isJumping = true;
    }

    protected void JumpPressed(InputAction.CallbackContext context)
    {
        lastJumpTime = jumpBufferTime;
    }

    // when jump is released the player will fall earlier
    protected void JumpReleased(InputAction.CallbackContext context)
    {
        if (rb.velocity.y > 0 && isJumping)
        {
            rb.AddForce(Vector2.down * rb.velocity.y * jumpCutMultiplier, ForceMode2D.Impulse);
        }
    }

    public void DisableControls()
    {
        playerInputActions.Player.Disable();
    }

    public void EnableControls()
    {
        playerInputActions.Player.Enable();
    }

    public void setGravity(float gravity)
    {
        gravityScale = gravity;
    }

    protected abstract void Update();
    protected abstract void FixedUpdate();
    protected abstract void Pause(InputAction.CallbackContext context);
}