using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("References")]
    private Animator animator;

    [Header("Values")]
    public int checkpointNumber;
    private Transform respawnLocation;

    void Start()
    {
        animator = GetComponent<Animator>();
        respawnLocation = gameObject.transform;
    }

    public Transform GetRespawnPoint()
    {
        return respawnLocation;
    }

    public void EnableAnimation()
    {
        animator.SetBool("ObtainedCheckpoint", true);
    }

    public void DisableAnimation()
    {
        animator.SetBool("ObtainedCheckpoint", false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)    // Player has entered the checkpoint
        {
            RespawnPoint respawnPointScript = collision.gameObject.GetComponent<RespawnPoint>();

            if (checkpointNumber > respawnPointScript.GetCurrentCheckpoint())  // If this checkpoint has a higher number (is further in the level) than the player's current checkpoint, set it as their new one
            {
                respawnPointScript.SetCurrentCheckpoint(checkpointNumber, respawnLocation, gameObject);
                EnableAnimation();
            }
        }
    }
}