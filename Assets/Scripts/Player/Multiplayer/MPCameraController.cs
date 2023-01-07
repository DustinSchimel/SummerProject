using Cinemachine;

public class MPCameraController : CameraController
{
    public override void Start()
    {
        if (!IsOwner) return;

        vCam = FindObjectOfType<CinemachineVirtualCamera>();

        vCam.Follow = transform;
        vCam.LookAt = transform;
    }
}