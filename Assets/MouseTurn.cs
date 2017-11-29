using UnityEngine;

public class MouseTurn : MonoBehaviour {

    GameObject cursorPosition;
    RectTransform ammo;
    void Start()
    {
        ammo = GameObject.Find("Ammo").GetComponent<RectTransform>();
        cursorPosition = GameObject.Find("Cursor");
        //cursorPosition.GetComponent<SpriteRenderer>().enabled = true;
    }
    void Update()
    {

        Vector3 direction = Input.mousePosition;
        direction.z = 30;
        direction = Camera.main.ScreenToWorldPoint(direction);
        
        cursorPosition.transform.position = direction;
        cursorPosition.transform.rotation = transform.root.rotation;
        transform.LookAt(cursorPosition.transform);

        Vector2 direction1 = Camera.main.WorldToScreenPoint(cursorPosition.GetComponentInChildren<MeshRenderer>().transform.position);
        ammo.anchoredPosition = direction1;
        ammo.anchoredPosition += new Vector2(0, 50f);
    }

}