using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {


    public float dampTime = 0.15f;

    Camera c;
    Vector3 playerPosition;
    Vector3 cameraPosition;
    private Vector3 velocity = Vector3.zero;
    
    
	// Use this for initialization
	void Start () {
        c = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        playerPosition = GameManager.player.transform.position;
        Vector3 point = c.WorldToViewportPoint(playerPosition);
        Vector3 delta = playerPosition - c.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}
