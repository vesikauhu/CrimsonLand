using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator animator;
    public float health;
    public int cash;

    public Transform gunPosition;
    public Weapon[] weapons;
    public Weapon currentWeapon;
    public Grenade grenade;
    
    
    private Rigidbody body;
    private MeshRenderer cursor;
    private bool grenadeMode = false;
    private bool recoil = false;

	void Start () {
        weapons = GetComponentsInChildren<Weapon>();
        currentWeapon = weapons[0];
        grenade = GetComponentInChildren<Grenade>();
        animator = GameObject.Find("PlayerModel").GetComponent<Animator>();
        cursor = GameObject.Find("Cursor").GetComponentInChildren<MeshRenderer>();
        body = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

        weapons = GetComponentsInChildren<Weapon>();
        //currentWeapon = GetComponentInChildren<Weapon>();
        animator.SetInteger("WeaponType", (int)currentWeapon.weaponType);
        animator.SetBool("Reload", currentWeapon.reloading);

        //Vector2 cursorHotspot;
        //cursorHotspot = new Vector2(currentWeapon.crosshair.width / 2, currentWeapon.crosshair.height / 2);
        //Cursor.SetCursor(currentWeapon.crosshair, cursorHotspot, CursorMode.Auto);

        Grenade();

        if (!grenadeMode)
        {
            SelectWeapon();
            FireSingleShot();
            FireShotgun();
            FireAutomatic();
            Reload();
        }
        

        if (!recoil)
        {
            body.velocity = new Vector3(0, 0, 0);

        }


    }

    void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = weapons[0];
        }
        if (weapons.Length >= 2)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentWeapon = weapons[1];
            }
        }
        if (weapons.Length >= 3)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentWeapon = weapons[2];
            }
        }
        if (weapons.Length >= 4)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                currentWeapon = weapons[3];
            }
        }
    }

    void FireSingleShot()
    {
        if (currentWeapon.weaponType == Weapon.WeaponType.SingleShot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentWeapon.ammoInClip > 0 && !currentWeapon.reloading)
                {
                    currentWeapon.Fire();
                }
            }
        }
    }

    void FireShotgun()
    {
        if (currentWeapon.weaponType == Weapon.WeaponType.Shotgun)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentWeapon.ammoInClip > 0 && !currentWeapon.reloading)
                {
                    currentWeapon.Fire();
                }
            }
        }
    }

    

    void FireAutomatic()
    {
        if (currentWeapon.weaponType == Weapon.WeaponType.Automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (currentWeapon.ammoInClip > 0 && !currentWeapon.reloading)
                {
                    currentWeapon.AutomaticFire();
                    //StartCoroutine(Recoil(currentWeapon.recoilForce));
                }
            }
        }
    }

    void Grenade()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            grenadeMode = true;
            // Cursor change

            if (Input.GetKey(KeyCode.Mouse0))
            {
                grenade.ThrowGrenade(cursor.transform.position);
            }

        }
        else
        {
            grenadeMode = false;
        }
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && !currentWeapon.reloading)
        {
            if (currentWeapon.ammoInClip != currentWeapon.clipSize)
            {
                StartCoroutine(currentWeapon.Reload());
            }
        }
    }

    public IEnumerator Recoil(float recoilForce)
    {
        recoil = true;
        body.AddForce(-transform.forward * recoilForce);
        yield return new WaitForSeconds(0.5f);
        recoil = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    /*void OnMouseOver()
    {
        cursor.enabled = false;
        gameObject.GetComponent<MouseTurn>().enabled = false;
        Cursor.visible = true;
    }

    void OnMouseExit()
    {
        Invoke("EnableMouseTurn", 0f);
        Cursor.visible = false;
        cursor.enabled = true;
    }

    void EnableMouseTurn()
    {
        gameObject.GetComponent<MouseTurn>().enabled = true;
    }
    */

}
