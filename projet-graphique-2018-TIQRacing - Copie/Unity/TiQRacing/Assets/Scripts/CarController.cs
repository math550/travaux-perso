using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CarController : NetworkBehaviour
{

    float speedForce = 20f;
    float torqueForce = -200f;
    
    float driftFactorSlippy = 0.95f;
    

	private bool playerHasItem;
	private bool playerUsingItem = false;
	private float keyDownTime = float.MinValue;

    private bool playerFinished = false;

    private void Awake()
    {
        EventsManager.AddListener("PlayerFinished", OnPlayerFinished);
    }

    // Use this for initialization
    void Start () {
        
    }

    public override void OnStartAuthority()
    {
        
        var camFollow = Camera.main.GetComponent<CameraFollow>();
        camFollow.setTarget(gameObject.transform);
        camFollow.enabled = true;
        
		playerHasItem = false;
		EventsManager.AddListener ("ItemGet", OnPlayerGet);
		EventsManager.AddListener ("playerOnDirt", PlayerOnDirt);
		EventsManager.AddListener ("playerOnRace", PlayerOnRace);
    }

    // Update is called once per frame
    void Update () {

       
		if(Input.GetKeyDown(KeyCode.Space) && playerHasItem && !playerUsingItem)
		{
			keyDownTime = Time.time;
			playerUsingItem = true;
		}

		if (Time.time < keyDownTime + 2) 
		{
			Boost ();
		} 
		else if(Time.time >= keyDownTime + 2 && playerUsingItem)
		{

			speedForce = 20f;
			playerHasItem = false;

			EventsManager.TriggerListener ("ItemUsed");
			Debug.Log ("Boosted finished : " + speedForce);
			playerUsingItem = false;
		}
        

    }

    void FixedUpdate()
    {
        if (playerFinished)
            return;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();


        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactorSlippy;

        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce(transform.up * speedForce);
        }

        if (Input.GetButton("Brakes"))
        {
            rb.AddForce(transform.up * -speedForce / 2);
        }

        



        rb.angularVelocity = Input.GetAxis("Horizontal") * torqueForce;


    }

	void OnPlayerGet()
	{
		playerHasItem = true;
	}

	void Boost()
	{
		speedForce = 30f;
		Debug.Log ("Boost activated : " + speedForce);
	}

	void PlayerOnDirt()
	{
		Debug.Log ("player is on dirt");

		speedForce = 5f;
	}

	void PlayerOnRace()
	{
		Debug.Log ("player is on race");

		speedForce = 20f;
	}

    void CameraFollow()
    {


    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }

    private void OnPlayerFinished()
    {
        playerFinished = true;
    }
}
