using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    private Transform respawnPoint;
    private PlayerController playerController;
    private Animator animator;

    [Header("Stats")]
    public int HP = 1;

    [Header("Other Variables")]
    private bool respawning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (HP == 0)
        {
            if (respawning == false)
            {
                respawning = true;

                playerController.DisableControls();

                // Play death particle
                animator.SetBool("JumpUp", false);
                animator.SetBool("JumpDown", false);
                animator.SetBool("Death", true);

                StartCoroutine(RespawnPlayer());

                // Make the screen transition to black
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
        yield return new WaitForSeconds(3f);

        respawnPoint = rb.GetComponent<RespawnPoint>().respawnPoint;    // Updates the saved respawn point if the player's respawn point changed
        rb.gameObject.transform.position = respawnPoint.position;   // Teleport the player
        rb.position = respawnPoint.position;

        animator.SetBool("Death", false);

        // Fade away from the black

        playerController.EnableControls();

        HP = 1;
        respawning = false;
    }
}