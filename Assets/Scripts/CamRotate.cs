using UnityEngine;
using System.Collections;

public class CamRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        //    transform.position = new Vector3(Player.transform.position.x - xDis, Player.transform.position.y - yDis, Player.transform.position.z + zDis) * 0.25f * Time.deltaTime;
    /*    if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 40.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 40.0f);
        }*///Consider implementing camera control
    }
}
