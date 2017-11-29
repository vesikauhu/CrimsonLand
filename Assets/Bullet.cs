using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public enum ProjectileType
    {
        Bullet,
        ShotgunShell,
        PiercingBullet
    }

    public ProjectileType projectileType;
    public float damage;

    private float bulletSpeed;
    private float bulletForce;
    private int maxPierces;
    private int pierceCounter = 0;
    private GameObject bulletTrail;



    void Start () {
        maxPierces = GetComponentInParent<Weapon>().maxPierces;
        bulletSpeed = GetComponentInParent<Weapon>().bulletSpeed;
        damage = GetComponentInParent<Weapon>().damage;
        transform.SetParent(null);
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        bulletTrail = GetComponentInChildren<TrailRenderer>().gameObject;
        StartCoroutine(DestroyBullet());
    }
	
	// Update is called once per frame
	void Update () {

        if (projectileType == ProjectileType.ShotgunShell)
        {
            damage -= Time.deltaTime * 100;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
            return;

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(gameObject.GetComponent<Rigidbody>().velocity * bulletForce, collision.transform.position);
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            pierceCounter++;
            
            if (pierceCounter > maxPierces)
            {
                bulletTrail.transform.SetParent(null);
                StartCoroutine(DestroyBulletTrail(bulletTrail));
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }


    IEnumerator DestroyBulletTrail(GameObject bulletTrail)
    {
        Destroy(bulletTrail, 0.3f);
        yield return 0;
    }
}
