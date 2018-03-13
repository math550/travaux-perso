using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {


    //private Transform spawn1;
    //private Transform spawn2;
    //private Transform spawn3;

	GameObject car;

    private Vector3 position1race1;
    private Vector3 position2race1;
    private Vector3 position3race1;
    private Vector3 position4race1;

    private Vector3 position1race2;
    private Vector3 position2race2;
    private Vector3 position3race2;
    private Vector3 position4race2;

    private Vector3 position1race3;
    private Vector3 position2race3;
    private Vector3 position3race3;
    private Vector3 position4race3;

    // Use this for initialization
    void Start () {

		if (hasAuthority)
		{
			EventsManager.AddListener("PlayerNameFinished", AddPlayerClassement);
		}


        if(isLocalPlayer == false)
        {
            return;
        }

        

        

        position1race1 = new Vector3(-2f, -41.5f, 0f);
        position2race1 = new Vector3(-2f, -40, 0f);
        position3race1 = new Vector3(10.2f, -38.5f, 0f);
        position4race1 = new Vector3(10.2f, -36f, 0f);

        position1race2 = new Vector3(-16f, -43.5f, 0f);
        position2race2 = new Vector3(-3.6f, -42f, 0f);
        position3race2 = new Vector3(-3.6f, -40.5f, 0f);
        position4race2 = new Vector3(-3.6f, -39f, 0f);

        position1race3 = new Vector3(-2f, -40f, 0f);
        position2race3 = new Vector3(0.3f, -38.5f, 0f);
        position3race3 = new Vector3(0.3f, -36f, 0f);
        position4race3 = new Vector3(0.3f, -34.5f, 0f);

        //Instantiate(PlayerUnitPrefab);


        SpawnMyUnit();

    }

    public GameObject PlayerUnitPrefab;

    [SyncVar(hook= "OnPlayerNameChanged")]
    public string PlayerName = "Math";
	
	// Update is called once per frame
	void Update () {

        if (isLocalPlayer == false)
        {
            return;
        }


        
    }

    void OnPlayerNameChanged(string newName)
    {
        Debug.Log("OnPlayerNameChanged: OldName: " + PlayerName+ "NewName" + newName);

        PlayerName = newName;

        gameObject.name = "PlayerConnectionObject ["+newName+"]";
    }

    
    void SpawnMyUnit()
    {

        Debug.Log("CmdSpawnMyUnit()");

        

        if (ControllerCourse.getActiveRace() == 1)
        {
            Debug.Log("active1");

            if(ControllerCourse.getNumberPlayers() == 0)
            {
                Debug.Log("ya 1 joueur");

                CmdSpawnPlayer(position1race1);
            }
            else if (ControllerCourse.getNumberPlayers() == 1)
            {
                Debug.Log("ya 2 joueur");

                CmdSpawnPlayer(position2race1);
            }
            else if (ControllerCourse.getNumberPlayers() == 2)
            {
                CmdSpawnPlayer(position3race1);
            }
            else if (ControllerCourse.getNumberPlayers() == 3)
            {
                CmdSpawnPlayer(position4race1);
            }

            
        }

        else if (ControllerCourse.getActiveRace() == 2)
        {
            Debug.Log("active2");

            if (ControllerCourse.getNumberPlayers() == 0)
            {
                Debug.Log("ya 1 joueur");

                CmdSpawnPlayer(position1race2);
            }
            else if (ControllerCourse.getNumberPlayers() == 1)
            {
                Debug.Log("ya 2 joueur");

                CmdSpawnPlayer(position2race2);
            }
            else if (ControllerCourse.getNumberPlayers() == 2)
            {
                CmdSpawnPlayer(position3race2);
            }
            else if (ControllerCourse.getNumberPlayers() == 3)
            {
                CmdSpawnPlayer(position4race2);
            }
        }

        else if (ControllerCourse.getActiveRace() == 3)
        {
            Debug.Log("active3");

            if (ControllerCourse.getNumberPlayers() == 0)
            {
                Debug.Log("ya 1 joueur");

                CmdSpawnPlayer(position1race3);
            }
            else if (ControllerCourse.getNumberPlayers() == 1)
            {
                Debug.Log("ya 2 joueur");

                CmdSpawnPlayer(position2race3);
            }
            else if (ControllerCourse.getNumberPlayers() == 2)
            {
                CmdSpawnPlayer(position3race3);
            }
            else if (ControllerCourse.getNumberPlayers() == 3)
            {
                CmdSpawnPlayer(position4race3);
            }
        }


    }

	public void AddPlayerClassement()
	{
		Debug.Log ("AddPlayerClassement()");

		if(car.gameObject.name == "car1")
		{
			Debug.Log ("car 1 in AddPlayerClassement()");

			EventsManager.TriggerListener("Player1Finished");
		}
			
		else if(car.gameObject.name == "car2")
		{
			Debug.Log ("car 2 in AddPlayerClassement()");

			EventsManager.TriggerListener("Player2Finished");
		}
		else if(car.gameObject.name == "car3")
			EventsManager.TriggerListener("Player3Finished");
		else if(car.gameObject.name == "car4")
			EventsManager.TriggerListener("Player4Finished");
	}

    [Command]
    void CmdSpawnPlayer(Vector3 playerPosition)
    {
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 90f);

        car = Instantiate(PlayerUnitPrefab, playerPosition, spawnRotation);

        NetworkServer.SpawnWithClientAuthority(car, connectionToClient);

        car.GetComponent<playerCollision>().playerObject = this;

        ControllerCourse.AddNumberPlayer();

         car.gameObject.name = "car" + ControllerCourse.getNumberPlayers();
    }

    

    [Command]
    void CmdChangePlayerName(string n)
    {
        Debug.Log("CmdChangePlayerName: " + n);
        PlayerName = n;

        //RpcChangePlayerName(PlayerName);
    }

	public PlayerObject getInstance()
	{
		return this;
	}

    /*    [ClientRpc]
        void RpcChangePlayerName(string n)
        {
            Debug.Log("RpcChangePlayerName: WE were asked to change the p;ayer name : " + n);
            PlayerName = n;
        }
    */
}
