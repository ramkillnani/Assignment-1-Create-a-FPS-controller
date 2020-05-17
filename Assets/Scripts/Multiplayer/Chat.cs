using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using System;

public class Chat : NetworkBehaviour
{
    [SerializeField] private GameObject chatUI = null;
    [SerializeField] private TMP_Text chatText = null;
    [SerializeField] private TMP_InputField chatInput = null;

    private static event Action<string> OnMessage;

    public override void OnStartAuthority()
    {
        chatUI.SetActive(true);

        OnMessage += HandleNewMessage;
    }

    [ClientCallback]

    private void OnDestroy()
    {
        if(!hasAuthority)
        {
            return;
        }

        OnMessage -= HandleNewMessage;
    }

    private void HandleNewMessage(string message)
    {
        chatText.text += chatText.text;
    }

    [Client]
    public void Send(string message)
    {
        if(!Input.GetKeyDown(KeyCode.Return) && string.IsNullOrWhiteSpace(message))
        {
            return;

        }

        CmdSendMessage(message);

        chatInput.text = string.Empty;
    }

    [Command]
    private void CmdSendMessage(string message)
    {
        RpcHandleMessage($"[{connectionToClient.connectionId}]:{message}");
    }

    [ClientRpc]
    private void RpcHandleMessage(string message)
    {
        OnMessage?.Invoke("\n" + message);
    }

}
