using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
		
	void Update () {
		if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(0.0f, 0.0f, 1.0f) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + new Vector3(0.0f, 0.0f, -1.0f) * speed * Time.deltaTime;
        }
	}
}
