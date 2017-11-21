using UnityEngine;

public class MouseTurn : MonoBehaviour {

    Transform gunPosition;
    GameObject cursorPosition;
    
    void Start()
    {
        gunPosition = gameObject.GetComponent<Player>().gunPosition;
        cursorPosition = GameObject.Find("Cursor");
        //cursorPosition.GetComponent<SpriteRenderer>().enabled = true;
    }
    void Update()
    {
        Vector3 direction = Input.mousePosition;
        direction.z = 30;
        direction = Camera.main.ScreenToWorldPoint(direction);
        cursorPosition.transform.position = direction;
        direction = direction - gameObject.GetComponent<Player>().gunPosition.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        Transform lookTarget = 
        transform.LookAt(cursorPosition.transform);
        //transform.rotation = Quaternion.Euler(0, angle, 0);
        


    }

}