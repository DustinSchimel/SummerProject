using Cinemachine;

public class SPCameraController : CameraController
{
    public override void Start()
    {
        vCam = FindObjectOfType<CinemachineVirtualCamera>();

        vCam.Follow = transform;
        vCam.LookAt = transform;
    }
}