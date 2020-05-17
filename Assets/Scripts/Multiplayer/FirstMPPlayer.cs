using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FirstMPPlayer : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();

    [Client]
    // Start is called before the first frame update
    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdMove();
        }
    }

    [Command]
    private void CmdMove()
    {
        //Validate the request
        RpcMove();
    }

    [ClientRpc]
    private void RpcMove()
    {
        transform.Translate(movement);

    }
}
