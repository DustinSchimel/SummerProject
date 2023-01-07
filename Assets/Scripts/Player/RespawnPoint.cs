using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public abstract class RespawnPoint : NetworkBehaviour
{
    [Header("References")]
    protected Rigidbody2D rb;
    [SerializeField] public Transform respawnPoint;

    [Header("Other Variables")]
    protected int currentCheckpoint;
    protected GameObject currentCheckpointObject;

    public abstract void SetCurrentCheckpoint(int checkpoint, Transform checkpointPoint, GameObject currentCheckObj);

    public int GetCurrentCheckpoint()
    {
        return currentCheckpoint;
    }
}