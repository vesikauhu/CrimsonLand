using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spas : Weapon {

    
	void Start () {
        timer = firerate;
        audioManager = GameObject.Find("AudioManager");
    }

    public int i;
	// Update is called once per frame
	void Update () {
        FireRateCheck();
	}

    public override void Fire()
    {

        if (ready)
        {
            i = 0;

            AudioSource a = audioManager.AddComponent<AudioSource>();
            a.PlayOneShot(shotSound);

            GameObject flash = Instantiate(muzzlePrefab, transform.parent.transform, false);
            Destroy(flash, 0.05f);

            Quaternion spreadAdjuster = GetComponentInParent<Player>().gameObject.transform.rotation;
            spreadAdjuster.y -= 0.3f;

            StartCoroutine(GetComponentInParent<Player>().Recoil(recoilForce));
            StartCoroutine(InstantiateShells());
            
            ammoInClip--;
            ready = false;
            timer = 0;
        }
    }

    IEnumerator InstantiateShells()
    {
        if (i < 10)
        {
            GameObject shellA = Instantiate(bulletPrefab, transform.position, transform.rotation);
            shellA.transform.Translate(-0.4f, 0, 0);
            shellA.transform.SetParent(gameObject.transform);

            GameObject shellB = Instantiate(bulletPrefab, transform.position, transform.rotation);
            shellB.transform.SetParent(gameObject.transform);

            GameObject shellC = Instantiate(bulletPrefab, transform.position, transform.rotation);
            shellC.transform.Translate(0.4f, 0, 0);
            shellC.transform.SetParent(gameObject.transform);

            i++;
            StartCoroutine(InstantiateShells());
        }
        yield return new WaitForFixedUpdate();
    }
}
