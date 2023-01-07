using Cinemachine;
using Unity.Netcode;

public abstract class CameraController : NetworkBehaviour
{
    protected CinemachineVirtualCamera vCam;

    public abstract void Start();
}
