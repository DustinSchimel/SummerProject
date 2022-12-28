using Cinemachine;
using Unity.Netcode;

public class PlayerCameraController : NetworkBehaviour
{
    private CinemachineVirtualCamera vCam;

    public void Start()
    {
        if (!IsOwner) return;

        vCam = FindObjectOfType<CinemachineVirtualCamera>();

        vCam.Follow = transform;
        vCam.LookAt = transform;
    }
}
