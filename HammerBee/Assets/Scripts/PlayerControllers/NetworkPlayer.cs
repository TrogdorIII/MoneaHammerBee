using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(FirstPersonController))]
public class NetworkPlayer : NetworkBehaviour
{
    MonoBehaviour pc;

    void Awake()
    {
        if (GetComponent<BasePlayerController>())
            pc = GetComponent<BasePlayerController>();
        else
            pc = GetComponent<BeePlayerController>();

    }

    void Start()
    {
        if (isLocalPlayer)
        {
            pc.enabled = true;
        }
    }

    void Update()
    {

    }
}
