using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour
{
    //assign player controller

    void Start()
    {
        if (isLocalPlayer)
        {
            //activate player controller
        }
    }

    void Update()
    {

    }
}
