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
    private float gravityScale;

    [Header("Other Variables")]
    public float respawnTime = 1f;
    private bool respawning = false;
    private int currentCheckpoint;
    private GameObject currentCheckpointObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        gravityScale = rb.gravityScale;
        currentCheckpoint = 0;
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
        /*
        else if (collision.gameObject.layer == 7)   // Checkpoints
        {
            Debug.Log("Entered checkpoint");
        }
        */
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnTime);

        respawnPoint = rb.GetComponent<RespawnPoint>().respawnPoint;    // Updates the saved respawn point if the player's respawn point changed
        rb.gameObject.transform.position = respawnPoint.position;   // Teleport the player
        rb.position = respawnPoint.position;

        animator.SetBool("Death", false);

        // Fade away from the black (maybe do this)

        playerController.setGravity(gravityScale);
        playerController.EnableControls();

        HP = 1;
        respawning = false;
    }

    public void SetCurrentCheckpoint(int checkpoint, Transform checkpointPoint, GameObject currentCheckObj)
    {
        if (currentCheckpointObject != null)
        {
            currentCheckpointObject.gameObject.GetComponent<Checkpoint>().DisableAnimation();
        }

        currentCheckpointObject = currentCheckObj;
        currentCheckpoint = checkpoint;
        rb.GetComponent<RespawnPoint>().respawnPoint = checkpointPoint;
    }

    public int GetCurrentCheckpoint()
    {
        return currentCheckpoint;
    }
}