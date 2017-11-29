using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public enum WeaponType
    {
        SingleShot,
        Shotgun,
        Automatic
    }

    public string Name; 
    public WeaponType weaponType; 
    public AudioClip shotSound;
    public AudioClip reloadSound;
    public int damage;
    public int clipSize;
    public int ammoInClip;
    public bool reloading = false;
    public int maxPierces;
    public float reloadTime;
    public float firerate;
    public float recoilForce;
    public float bulletSpeed;
    public float bulletForce;
    public GameObject bulletPrefab;
    public GameObject muzzlePrefab;

    protected float timer;
    protected bool ready = true;
    protected GameObject audioManager;
    protected Mod[] weaponMods;


    void Awake()
    {
        weaponMods = GetComponentsInChildren<Mod>();
        foreach (Mod m in weaponMods)
        {
            m.ModifyWeapon(this);
        }
        ammoInClip = clipSize;
    }


    public IEnumerator Reload()
    {
        reloading = true;
        AudioSource a = audioManager.AddComponent<AudioSource>();
        a.PlayOneShot(reloadSound);
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
