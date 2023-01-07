using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;

public class SPController : Controller
{
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        pauseMenu = GameObject.Find("Pause").GetComponent<SPPauseMenu>();

        facingRight = true;
        canDash = true;

        gravityScale = rb.gravityScale;

        // control related
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += JumpPressed;
        playerInputActions.Player.Jump.canceled += JumpReleased;
        playerInputActions.Player.Pause.performed += Pause;
        playerInputActions.Player.Dash.performed += Dash;
    }

    protected override void Update()
    {
        if (isDashing) return;

        #region Checks
        if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer)) // checks to see if the player's ground hitbox is overlaping with the ground layer
        {
            lastGroundedTime = jumpCoyoteTime; //if so sets the lastGrounded to coyoteTime

            animator.SetBool("JumpUp", false); // Disables jumping animations once player lands on ground
            animator.SetBool("JumpDown", false);

            if (!isDashing)
            {
                canDash = true; // Player can dash again once they hit the ground
            }
        }

        if (rb.velocity.y > .5)
        {
            animator.SetBool("JumpUp", true); // Player is jumping up, so play the jump up animation
            animator.SetBool("JumpDown", false);
        }

        if (rb.velocity.y < -.5)
        {
            animator.SetBool("JumpDown", true); // Player is falling / jumping down, so play the jump down animation
            animator.SetBool("JumpUp", false);
        }

        if (rb.velocity.y < 0)  // maybe change to ==
        {
            isJumping = false;
        }
        #endregion

        #region Jump
        if (lastGroundedTime > 0 && lastJumpTime > 0 && !isJumping) //checks if was last grounded within coyoteTime and that jump has been pressed within bufferTime
        {
            Jump();
        }
        #endregion

        #region Timer
        lastGroundedTime -= Time.deltaTime;
        lastJumpTime -= Time.deltaTime;
        #endregion
    }

    protected override void FixedUpdate()
    {
        if (isDashing) return;

        Vector2 moveInput = playerInputActions.Player.Movement.ReadValue<Vector2>();

        //Debug.Log("X input - x:" + moveInput.x + " , Y input - y: " + moveInput.y);

        #region Direction
        if ((moveInput.x > 0 && !facingRight) || (moveInput.x < 0 && facingRight))    // Player changes direction, flip sprite
        {
            Flip();
        }
        #endregion

        #region Animation
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x)); // If player's speed is above 0, play the running animation
        #endregion

        #region Run
        float targetSpeed = 0;

        if (moveInput.x != 0)
        {
            targetSpeed = (moveInput.x / Math.Abs(moveInput.x)) * moveSpeed;  //calculate the direction we want to move in and our desired velocity
        }

        float speedDif = targetSpeed - rb.velocity.x;   //calculate difference between current velocity and desired velocity
        float accelRate = (Mathf.Abs(targetSpeed) > 0.0f) ? acceleration : decceleration;

        //applies acceleration to speed difference, then raises to a set power so acceleration increases with higher speeds, finally multiplies by sign to reapply direction
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

        rb.AddForce(movement * Vector2.right);  //applies force force to rigidbody, multiplying by Vector2.right so that it only affects X axis 
        #endregion

        #region Friction
        if (lastGroundedTime > 0 && Mathf.Abs(moveInput.x) < 0.01f)
        {
            float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(rb.velocity.x);
            rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }
        #endregion

        #region Jump Gravity
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = gravityScale * fallGravityMultiplier; // Increases gravity after the peak of the player's jump has been reached
        }
        else
        {
            rb.gravityScale = gravityScale;
        }
        #endregion
    }

    protected override void Pause(InputAction.CallbackContext context)
    {
        pauseMenu.Pause(playerInputActions, GetComponent<SPStats>());
    }
}