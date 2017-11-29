using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health;
    public float enemySpeed;
    public float damage;
    public GameObject emitBlood;
    public Material[] bloodMaterials;
    public GameObject[] bloodTrails;
    public GameObject locationIndicator;
    Animator animator;
    GameObject targetPlayer;
    Vector3 direction;
    bool isDead = false;
    bool moving;
	void Start () {
        targetPlayer = GameObject.Find("Player");
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        animator.SetBool("Dead", isDead);

        if (!isDead)
        {
            if (GetComponent<Rigidbody>().velocity != Vector3.zero)
                moving = true;

            MoveTowardsPlayer();
            animator.SetBool("Moving", moving);
            

            if (health <= 0)
            {
                isDead = true;
            }

            if (isDead)
            {
                Die();
            }
        }
	}

    public void MoveTowardsPlayer()
    {
        direction = -transform.position + targetPlayer.transform.position;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -angle, 0);
        GetComponent<Rigidbody>().velocity = direction.normalized * enemySpeed;
    }

    void Die()
    {
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<SphereCollider>());
        transform.Translate(0, -0.9f, 0f);

        int rnd = Random.Range(0, 7);
        Material[] temp = new Material[2];
        temp[0] = GetComponentInChildren<SkinnedMeshRenderer>().material;
        temp[1] = bloodMaterials[rnd];
        GetComponentInChildren<SkinnedMeshRenderer>().materials = temp;
        GameObject bt = Instantiate(bloodTrails[rnd], transform.position, Quaternion.identity);
        bt.transform.Translate(0, -2.4f, 0);
        rnd = Random.Range(1, 360);
        bt.transform.Rotate(0, rnd, 0);
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject playerHit = collision.gameObject;
            playerHit.GetComponent<Player>().TakeDamage(damage);
        }
    }

    void OnCOllisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
        }
    }

    public void TakeDamage(float damage)
    {
        GameObject blood = Instantiate(emitBlood, transform, false);
        Destroy(blood, 2f);
        health -= damage;
    }
}
