using System.Collections;
using UnityEngine;
using TMPro;

public class MPStats : Stats
{
    [Header("References")]
    private MPController playerController;
    public TMP_Text usernameText;

    [Header("Stats")]
    private string username;

    public override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<MPController>();
        animator = GetComponentInChildren<Animator>();
        gravityScale = rb.gravityScale;
        usernameText.text = username;
    }

    public void updateUsername(string name)
    {
        if (!IsOwner) return;
        
        usernameText.text = name;
    }

    protected override void Update()
    {
        if (!IsOwner) return;

        if (HP == 0)
        {
            if (respawning == false)
            {
                respawning = true;

                playerController.DisableControls();
                rb.velocity = Vector2.zero;
                playerController.setGravity(0f);

                // Play death particle
                animator.SetBool("JumpUp", false);
                animator.SetBool("JumpDown", false);
                animator.SetBool("Death", true);

                StartCoroutine(RespawnPlayer());

                // Make the screen transition to black (maybe do this)
            }
        }
    }

    protected override IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnTime);

        respawnPoint = rb.GetComponent<MPRespawnPoint>().respawnPoint;    // Updates the saved respawn point if the player's respawn point changed
        rb.gameObject.transform.position = new Vector2(respawnPoint.position.x, respawnPoint.position.y + .005f);   // Teleports the player, and fixes issue with not being able to jump after death
        rb.position = respawnPoint.position;

        animator.SetBool("Death", false);

        // Fade away from the black (maybe do this)

        playerController.setGravity(gravityScale);

        // The player can still die while paused, so don't enable controls if they are paused
        if (!isPaused)
        {
            playerController.EnableControls();
        }

        HP = 1;
        respawning = false;
        playerController.onDeath();
    }
}