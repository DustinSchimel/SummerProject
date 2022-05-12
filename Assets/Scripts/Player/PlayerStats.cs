using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    private Transform respawnPoint;
    //private PlayerController playerController;
    private MultiplayerPlayerController playerController;
    private Animator animator;

    [Header("Stats")]
    public int HP = 1;
    private float gravityScale;

    [Header("Other Variables")]
    public float respawnTime = 1f;
    private bool respawning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerController = GetComponent<PlayerController>();
        playerController = GetComponent<MultiplayerPlayerController>();
        animator = GetComponent<Animator>();
        gravityScale = rb.gravityScale;
    }

    void Update()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)    // Spikes
        {
            // -1 HP from player
            HP = HP - 1;

            // Make player invincible for a few seconds if they're still alive
        }
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnTime);

        respawnPoint = rb.GetComponent<RespawnPoint>().respawnPoint;    // Updates the saved respawn point if the player's respawn point changed
        rb.gameObject.transform.position = new Vector2(respawnPoint.position.x, respawnPoint.position.y + .005f);   // Teleports the player, and fixes issue with not being able to jump after death
        rb.position = respawnPoint.position;

        animator.SetBool("Death", false);

        // Fade away from the black (maybe do this)

        playerController.setGravity(gravityScale);
        playerController.EnableControls();

        HP = 1;
        respawning = false;
    }
}