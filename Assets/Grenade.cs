using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public int amount;


	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ThrowGrenade(Vector3 targetPosition)
    {
        RaycastHit[] targetsHit = Physics.SphereCastAll(targetPosition, 5.0f, transform.forward, 5, 2);
        foreach (RaycastHit ray in targetsHit)
        {
            Destroy(ray.transform.gameObject);
        }
    }

}
