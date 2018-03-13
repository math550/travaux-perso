using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {

	// Use this for initialization
	void Start ()
    {
        // Is this actually my own local PlayerObject?
        if( isLocalPlayer == false)
        {
            // This object belongs to another player
            return;
        }

        // Since the PlayerObject is invisible and not part of the world,
        // give me something physical to move around!

        // Instantiate() only creates an object on the LOCAL COMPUTER.
        // Even if it has a NetworkIdentity is still will NOT exist on
        // the network (and therefore not on any other client ) UNLESS
        // NetworkServer.Spawn() is called on this object.

        //Instantiate(PlayerUnitPrefab);

        // Command (politely) the server to SPAWN our unit
        CmdSpawnMyUnit();
	}
    
    //Debug.Log("PlayerObject::Start -- Spawning my own personal unit.");
    public GameObject PlayerUnitPrefab;

    // SyncVars are variables where is their value changes on the SERVER, then all clients
    // are automatically informed of the new value
    [SyncVar(hook ="OnPlayerNameChanged")]
    public string PlayerName = "Anonymous";

	// Update is called once per frame
	void Update () {
        // Remember: Update runs on EVERYONE's computer, whether or not they own this
        // particular player object.

        if (isLocalPlayer == false)
        {
            return;
        }

        
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Spacebar was hit -- we could instruct the server
            // to do something with our unit
            CmdSpawnMyUnit();
        }

        if( Input.GetKeyDown(KeyCode.Q))
        {
            string n = "Quill" + Random.Range(1, 100);

            CmdChangePlayerName(n);
        }
    }

    
    void OnPlayerNameChanged(string newName)
    {
        Debug.Log("OnPlayerNameChanged: OldName: " + PlayerName+" NewName:" + newName);

        // WARNING : If you use a hook on a SyncVar, then our local value does not get automatically
        PlayerName = newName;

        gameObject.name = "PlayerObject [" + newName + "]";
    }

    /////////////////////////////////// COMMANDS
    // Commands are special functions that ONLY get executed on the server.

    //GameObject myPlayerUnit;

    [Command]
    void CmdSpawnMyUnit()
    {
        // We are guaranteed to be on the server right now.
        GameObject go = Instantiate(PlayerUnitPrefab);

        //myPlayerUnit = go;

        //go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);


        // Now that the object exists on the server, propagate it to all
        // the clients (and also wire up the NetworkIdentity)

        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }

    [Command]
    void CmdChangePlayerName(string n)
    {
        

        // Maybe we should check the name doesn't have any blacklisted words it?
        // If there is a bad word in the name, do we just ignore this request and do nothing?
        // ... or do we still call the Rpc but with the original name?
        
        PlayerName = n;

        // Tell all th eclient what this player's name now is.
        //RpcChangePlayerName(PlayerName);

    }

    ///////////////////////////////// RPC
    // RPCs are special functions that ONLY get executed on the clients

        /*
    [ClientRpc]
    void RpcChangePlayerName(string n)
    {
        PlayerName = n;
    }*/

    /*
    [Command]
    void CmdMoveUnitUp()
    {
        if(myPlayerUnit == null)
        {
            return;
        }

        myPlayerUnit.transform.Translate(0, 1, 0);
    }*/
}
