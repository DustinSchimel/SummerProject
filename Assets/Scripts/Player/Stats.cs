using System.Collections;
using UnityEngine;
using Unity.Netcode;

public abstract class Stats : NetworkBehaviour
{
    [Header("References")]
    protected Rigidbody2D rb;
    protected Transform respawnPoint;
    protected Animator animator;

    [Header("Stats")]
    public int HP = 1;
    protected float gravityScale;

    [Header("Other Variables")]
    public float respawnTime = 1f;
    protected bool respawning = false;
    public bool isPaused = false;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)    // Spikes
        {
            HP = HP - 1;

            // Make player invincible for a few seconds if they're still alive
        }
    }

    public abstract void Start();
    protected abstract void Update();
    protected abstract IEnumerator RespawnPlayer();
}