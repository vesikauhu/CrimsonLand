using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spas : Weapon {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FireRateCheck();
	}

    public override void Fire()
    {
        
       

        //AudioSource a = audioManager.AddComponent<AudioSource>();
        //a.PlayOneShot(shotSound);
        GameObject flash = Instantiate(muzzlePrefab, transform.parent.transform, false);
        
        Destroy(flash, 0.05f);
        Quaternion spreadAdjuster = GetComponentInParent<Player>().gameObject.transform.rotation;
        spreadAdjuster.y -= 0.1f;

        for (int i = 0; i < 10; i++)
        { 
            for (int j = 0; j < 2; j++)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.SetParent(gameObject.transform);
                bullet.transform.rotation = spreadAdjuster;
            }
            spreadAdjuster.y += 0.01f;
        }

        ammoInClip--;
        ready = false;
        timer = 0;
    }
}
