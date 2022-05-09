using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    private PlayerInputActions playerInputActions;
    private Animator animator;

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
    private float lastGroundedTime;
    public float jumpBufferTime;
    private float lastJumpTime;
    [Space(10)]
    public float fallGravityMultiplier;
    private float gravityScale;
    [Space(10)]
    private bool isJumping;

    [Header("Checks")]
    public Transform groundCheckPoint;
    public Vector2 groundCheckSize;
    [Space(10)]
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;

        gravityScale = rb.gravityScale;

        // control related
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += JumpPressed;
        playerInputActions.Player.Jump.canceled += JumpReleased;
    }

    private void Update()
    {
        #region Checks
        if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer)) // checks to see if the player's ground hitbox is overlaping with the ground layer
        {
            lastGroundedTime = jumpCoyoteTime; //if so sets the lastGrounded to coyoteTime

            animator.SetBool("JumpUp", false); // Disables jumping animations once player lands on ground
            animator.SetBool("JumpDown", false);
        }

        if (rb.velocity.y > .5)
        {
            animator.SetBool("JumpUp", true); // Player is jumping up, so play the jump up animation
            animator.SetBool("JumpDown", false); // Player is jumping up, so play the jump up animation
        }

        if (rb.velocity.y < -.5)
        {
            animator.SetBool("JumpDown", true); // Player is falling / jumping down, so play the jump down animation
            animator.SetBool("JumpUp", false);
        }

        if (rb.velocity.y < 0)
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

    void FixedUpdate()
    {
        Vector2 moveInput = playerInputActions.Player.Movement.ReadValue<Vector2>();

        #region Direction
        if (moveInput.x > 0 && !facingRight)    // Player is moving towards the right and isn't facing right
        {
            Flip();
        }
        else if (moveInput.x < 0 && facingRight)    // Player is moving towards the left and isn't facing left
        {
            Flip();
        }
        #endregion

        #region Animation
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x)); // If player's speed is above 0, play the running animation
        #endregion

        #region Run
        float targetSpeed = moveInput.x * moveSpeed;    //calculate the direction we want to move in and our desired velocity
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

    private void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (lastGroundedTime > 0 && lastJumpTime > 0 && !isJumping && context.performed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            lastGroundedTime = 0;
            lastJumpTime = 0;
            isJumping = true;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
    }

    public void JumpPressed(InputAction.CallbackContext context)
    {
        lastJumpTime = jumpBufferTime;
    }

    // when jump is released the player will fall earlier
    public void JumpReleased(InputAction.CallbackContext context)
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
}