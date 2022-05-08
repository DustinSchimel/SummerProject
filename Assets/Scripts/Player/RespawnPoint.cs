using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    public Transform respawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
    }

    // Add methods that update the respawn point when the player reaches checkpoints
}
