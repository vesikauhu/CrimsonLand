using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

    Camera c;
    Vector3 playerPosition;
    Vector3 cameraPosition;
    
	// Use this for initialization
	void Start () {
        c = GetComponent<Camera>();
        

	}
	
	// Update is called once per frame
	void Update () {
        playerPosition = GameObject.Find("Player").transform.position;
        cameraPosition = playerPosition + new Vector3(0, 25, 0);
        c.transform.position = cameraPosition;
    }
}
