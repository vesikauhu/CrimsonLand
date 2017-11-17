using UnityEngine;

public class MouseTurn : MonoBehaviour
{
    Camera c;
    
    void Start()
    {
        c = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Input.mousePosition;
        direction.z = 10;
        direction = c.ScreenToWorldPoint(direction);
        direction = direction - transform.position;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, -angle + 90f, 0.0f);
    }

}