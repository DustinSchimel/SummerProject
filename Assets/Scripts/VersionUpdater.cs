using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class VersionUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text versionNumberText;

    void Start()
    {
        ushort protocolVersion = NetworkManager.Singleton.NetworkConfig.ProtocolVersion;

        versionNumberText.text = "V0." + protocolVersion.ToString();
    }
}
