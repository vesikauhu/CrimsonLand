using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon {


    // Use this for initialization
    void Start () {
        timer = firerate;
        audioManager = GameObject.Find("AudioManager");
    }
	
	// Update is called once per frame
	void Update () {
        FireRateCheck();
    }

    

    public override void AutomaticFire()
    {
        if (ready)
        {
            AudioSource a = audioManager.AddComponent<AudioSource>();
            a.PlayOneShot(shotSound);
            GameObject flash = Instantiate(muzzlePrefab, transform.parent.transform, false);
            Destroy(flash, 0.05f);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.SetParent(gameObject.transform);
            ammoInClip--;
            ready = false;
            timer = 0;
        }
    }
}
