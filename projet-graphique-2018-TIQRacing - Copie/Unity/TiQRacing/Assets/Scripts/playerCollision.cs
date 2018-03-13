using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class playerCollision : NetworkBehaviour {


	public PlayerObject playerObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasAuthority)
        {

            if (collision.gameObject.tag == "item")
            {
                //Destroy(collision.gameObject);


                //collision.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
                //ControllerCourse.instance.CmdDestroyItem(collision.gameObject);
				//EventsManager.TriggerListener("ItemGet");

				Debug.Log(this.gameObject.GetComponent<NetworkIdentity> ());

				//Debug.Log (collision.gameObject.GetComponent<NetworkIdentity> ().netId);
				CmdPlayerGotItem (collision.gameObject.GetComponent<NetworkIdentity>().netId );

            }

			if (collision.gameObject.tag == "insideWall")
			{
				EventsManager.TriggerListener("playerOnRace");
			}

            if (collision.gameObject.name == "finish")
            {
				
                //ControllerCourse.OnPlayerFinish();
                ControllerCourse.ChangePlayerLap();

            }

            if (collision.gameObject.tag == "checkpoint")
            {
                Debug.Log("Player pass checkpoint");
            }


        }

    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (hasAuthority) 
		{
			if (collision.gameObject.tag == "insideWall")
			{
				EventsManager.TriggerListener("playerOnDirt");
			}
		}
	}

	[Command]
	private void CmdPlayerGotItem(NetworkInstanceId idItem)
	{
		if (NetworkServer.FindLocalObject (idItem) != null) 
		{
			Debug.Log(this.playerObject.connectionToClient);


			//NetworkConnection connection = NetworkServer.objects [this.gameObject.GetComponent<NetworkIdentity> ().netId].connectionToServer;

			TargetPlayerGotItem (this.playerObject.connectionToClient);
		} 
		else 
		{
			Debug.Log ("Item doesn't exist");
		}

       
	}

   

    [TargetRpc]
	private void TargetPlayerGotItem(NetworkConnection player)
	{
		EventsManager.TriggerListener ("ItemGet");
	}
}
