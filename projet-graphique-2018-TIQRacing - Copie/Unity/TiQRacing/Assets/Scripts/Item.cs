using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Item : NetworkBehaviour 
{
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("collision detected");
		Destroy (this.gameObject);
        EventsManager.TriggerListener("OnItemDestroyed");
    }

}
