using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health;
    public float enemySpeed;
    GameObject targetPlayer;
    Vector3 direction;
	void Start () {
        targetPlayer = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        MoveTowardsPlayer();

        if (health <= 0)
        {
            Debug.Log("Enemy died");
            Destroy(gameObject);
        }
	}

    public void MoveTowardsPlayer()
    {
        direction = -transform.position + targetPlayer.transform.position;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -angle, 0);
        GetComponent<Rigidbody>().velocity = direction.normalized * enemySpeed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
