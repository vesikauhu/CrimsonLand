using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTurn : MonoBehaviour
{

    Camera c;
    Quaternion rotation;
    
    void Start()
    {
        c = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Input.mousePosition;
        direction.z = 15;
        direction = c.ScreenToWorldPoint(direction);
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, -angle, 0.0f);
    }

  
}