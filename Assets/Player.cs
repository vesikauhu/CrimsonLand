using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float health;
    public Transform gunPosition;
    public GameObject bulletPrefab;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, gunPosition.position, transform.rotation);
        }
    }
}
