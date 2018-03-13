using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2DConroller : MonoBehaviour {

    float speedForce = 10f;
    float torqueForce = -200f;
    float driftFactorSticky = 0.9f;
    float driftFactorSlippy = 1f;
    float maxStickyVelocity = 2.5f;
    float minSlippyVelocity = 1.5f; // <---- Exercise for the viewer

	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {
        // check for button up/down here, then set a bool that you will use in FixedUPdate
    }

    // Update is called once per frame
    void FixedUpdate () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactorSlippy;

        float driftFactor = driftFactorSticky;
        if(RightVelocity().magnitude > maxStickyVelocity)
        {
            driftFactor = driftFactorSlippy;
        }

        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce(transform.up * speedForce);
            
            //GetComponent<Rigidbody2D>().AddForce(transform.up * speedForce);
            //Debug.Log("Accelerate");
        }

        if (Input.GetButton("Brakes"))
        {
            rb.AddForce(transform.up * -speedForce/2f);

            //GetComponent<Rigidbody2D>().AddForce(transform.up * speedForce);
            //Debug.Log("Accelerate");
        }

        float tf = Mathf.Lerp(0,torqueForce, rb.velocity.magnitude / 2);

        

        rb.angularVelocity = Input.GetAxis("Horizontal") * tf;

        

    }

    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot( GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }
}
