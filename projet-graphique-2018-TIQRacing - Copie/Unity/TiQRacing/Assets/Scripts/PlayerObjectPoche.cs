using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObjectPoche : NetworkBehaviour
{

    // Use this for initialization
    void Start()
    {

        if (isLocalPlayer == false)
        {
            return;
        }

        //Instantiate(PlayerUnitPrefab);

        CmdSpawnMyUnit();

    }

    public GameObject PlayerUnitPrefab;

    [SyncVar(hook = "OnPlayerNameChanged")]
    public string PlayerName = "Poche";

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            string n = "Lul" + Random.Range(1, 100);

            CmdChangePlayerName(n);

        }
    }
    void OnPlayerNameChanged(string newName)
    {
        Debug.Log("OnPlayerNameChanged: Old: " + PlayerName + " New: "+ newName);

        PlayerName = newName;

        gameObject.name = "PLayerObjectPoche [" + newName + "]";
    }

    [Command]
    void CmdSpawnMyUnit()
    {
        GameObject go = Instantiate(PlayerUnitPrefab);
        
        //go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }

    [Command]
    void CmdChangePlayerName(string n)
    {
        PlayerName = n;

        //RpcChangePlayerName(n);
    }

   /* [ClientRpc]
    void RpcChangePlayerName(string n)
    {
        PlayerName = n;
    }*/
  
}

