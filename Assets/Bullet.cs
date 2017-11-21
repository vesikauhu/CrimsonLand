using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public enum ProjectileType
    {
        Bullet,
        Shell
    }

    public ProjectileType projectileType;
    public float bulletSpeed;
    public float bulletForce;
    private float damage;

	void Start () {
        damage = GetComponentInParent<Weapon>().damage;
        transform.SetParent(null);
        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        StartCoroutine(DestroyBullet());
    }
	
	// Update is called once per frame
	void Update () {

        if (projectileType == ProjectileType.Shell)
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
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        //StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
