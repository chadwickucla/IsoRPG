using UnityEngine;
using System.Collections;

public class RotateChar : MonoBehaviour {
    Vector3 mousePos;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      
       /* if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Input.mousePosition;
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }*/
    }
}
