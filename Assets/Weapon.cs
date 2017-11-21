using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public enum WeaponType
    {
        SingleShot,
        SemiAutomatic,
        Automatic
    }

    protected float timer;
    protected bool ready = true;
    protected GameObject audioManager;

    public string Name;
    public WeaponType weaponType;
    public Texture2D crosshair;
    public AudioClip shotSound;
    public int damage;
    public int clipSize;
    public int ammoInClip;
    public float reloadTime;
    public float firerate;
    public float recoilForce;
    public bool reloading = false;
    public GameObject bulletPrefab;
    public GameObject muzzlePrefab;
    


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        ammoInClip = clipSize;
        reloading = false;
    }

    public void FireRateCheck()
    {
        if (!ready)
        {
            if (timer < firerate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                ready = true;
            }
        }
    }


    public virtual void Fire() { }
    public virtual void AutomaticFire() { }
}
