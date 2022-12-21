using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCameraController : NetworkBehaviour
{
    public CinemachineVirtualCamera vCam;

    /*
    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;

        vCam = FindObjectOfType<CinemachineVirtualCamera>();

        if (SceneManager.GetActiveScene().name == "Multiplayer")
        {
            vCam.Follow = transform;
            vCam.LookAt = transform;
        }
    }
    */

    public void Start()
    {
        if (!IsOwner) return;

        vCam = FindObjectOfType<CinemachineVirtualCamera>();

        vCam.Follow = transform;
        vCam.LookAt = transform;
    }
}
