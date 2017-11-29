using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    Animator playerAnimator;
    Animator feetAnimator;
    public float normalSpeed = 1.5f;
    public float currentSpeed;
    public float stamina;
    public bool both = false;
    public bool moving = false;
    public bool sprint = false;
    bool staminaRecovery = false;
	
    void Start()
    {
        playerAnimator = GameObject.Find("PlayerModel").GetComponent<Animator>();
        feetAnimator = GameObject.Find("PlayerFeet").GetComponent<Animator>();
    }
	void Update () {

        SingleInput();
        DoubleInput();
        CheckStatus();
        
       if (both)
            currentSpeed = 0.75f * normalSpeed;
        else
            currentSpeed = normalSpeed;

        SprintInput();

        playerAnimator.SetBool("Moving", moving);
        feetAnimator.SetBool("Moving", moving);
        feetAnimator.SetBool("Sprint", sprint);

    }

    void SingleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + Vector3.left * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + Vector3.right * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + Vector3.forward * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + Vector3.back * currentSpeed * Time.deltaTime;
        }
    }

    void DoubleInput()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            both = true;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            both = true;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            both = true;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            both = true;
        }
        else
        {
            both = false;
        }
    }

    void SprintInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina <= 0)
        {
            staminaRecovery = false;
        }
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            StopAllCoroutines();
            staminaRecovery = false;
            sprint = true;
            currentSpeed *= 3;
            stamina -= Time.deltaTime * 50;
        }
        else
        {
            sprint = false;
            if (stamina < 100 && !staminaRecovery)
            {
                StartCoroutine(StaminaRecoveryDelay());
            }
            else if (staminaRecovery && stamina < 100)
            {
                stamina += Time.deltaTime * 30;
            }
        }

    }

    void CheckStatus()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            moving = true;
        else
            moving = false;
    }

    IEnumerator StaminaRecoveryDelay()
    {
        yield return new WaitForSeconds(3);
        staminaRecovery = true;
    }

}
