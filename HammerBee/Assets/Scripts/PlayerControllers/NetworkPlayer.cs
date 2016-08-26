using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(FirstPersonController))]
public class NetworkPlayer : NetworkBehaviour
{
    FirstPersonController fpc;

    void Awake()
    {
        fpc = GetComponent<FirstPersonController>();
    }

    void Start()
    {
        if (isLocalPlayer)
        {
            //activate player controller
            fpc.enabled = true;
        }
    }

    void Update()
    {

    }
}
