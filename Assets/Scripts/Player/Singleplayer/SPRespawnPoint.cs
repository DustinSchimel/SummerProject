using UnityEngine;

public class SPRespawnPoint : RespawnPoint
{
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
        currentCheckpoint = 0;
    }

    public override void SetCurrentCheckpoint(int checkpoint, Transform checkpointPoint, GameObject currentCheckObj)
    {
        if (currentCheckpointObject != null)
        {
            currentCheckpointObject.gameObject.GetComponent<Checkpoint>().DisableAnimation();
        }

        currentCheckpointObject = currentCheckObj;
        currentCheckpoint = checkpoint;
        rb.GetComponent<SPRespawnPoint>().respawnPoint = checkpointPoint;
    }
}