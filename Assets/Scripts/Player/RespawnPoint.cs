using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class RespawnPoint : NetworkBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    public Transform respawnPoint;

    [Header("Other Variables")]
    private int currentCheckpoint;
    private GameObject currentCheckpointObject;

    public override void OnNetworkSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
        currentCheckpoint = 0;
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