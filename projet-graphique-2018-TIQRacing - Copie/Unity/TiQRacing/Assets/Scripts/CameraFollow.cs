using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform playerTransform;

    public Vector3 cam;

    // Use this for initialization
    void Start ()
    {

        cam = new Vector3(0f, 0f, -25f);
    }
    

    // Update is called once per frame
    void Update () {
        cam.x = playerTransform.position.x;
        cam.y = playerTransform.position.y;

        transform.position = cam;
    }

    public void setTarget(Transform target)
    {
        playerTransform = target;
    }

    public void UnzoomCam()
    {
        Debug.Log("UnzoomCam");

        Debug.Log(playerTransform);

        cam.x = 0f;
        cam.y = 4f;
        cam.z = -80f;

        transform.position = cam;
    }
}
