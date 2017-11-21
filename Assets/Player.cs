using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator animator;
    public float health;
    public Transform gunPosition;
    public Weapon currentWeapon;
    private Rigidbody body;
    private bool recoil = false;
    

	void Start () {
        animator = GameObject.Find("PlayerModel").GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        
        currentWeapon = GetComponentInChildren<Weapon>();
        animator.SetInteger("WeaponType", (int)currentWeapon.weaponType);
        animator.SetBool("Reload", currentWeapon.reloading);
        
        Vector2 cursorHotspot;
        cursorHotspot = new Vector2(currentWeapon.crosshair.width / 2, currentWeapon.crosshair.height / 2);
        Cursor.SetCursor(currentWeapon.crosshair, cursorHotspot, CursorMode.Auto);

        FireSingleShot();
        FireAutomatic();
        Reload();

        if (!recoil)
        {
            body.velocity = new Vector3(0, 0, 0);

        }


    }

    void OnMouseOver()
    {
        gameObject.GetComponent<MouseTurn>().enabled = false;
    }

    void OnMouseExit()
    {
        Invoke("EnableMouseTurn", 0f);
    }

    void EnableMouseTurn()
    {
        gameObject.GetComponent<MouseTurn>().enabled = true;
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
                    StartCoroutine(Recoil(currentWeapon.recoilForce));
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
                    StartCoroutine(Recoil(currentWeapon.recoilForce));
                }
            }
        }
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentWeapon.ammoInClip != currentWeapon.clipSize)
            {
                StartCoroutine(currentWeapon.Reload());
            }
        }
    }

    IEnumerator Recoil(float recoilForce)
    {
        recoil = true;
        body.AddForce(-transform.forward * recoilForce);
        yield return new WaitForSeconds(0.5f);
        recoil = false;
    }
}
