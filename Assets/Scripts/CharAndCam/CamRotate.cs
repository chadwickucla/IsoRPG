using UnityEngine;
using System.Collections;
[System.Serializable]
public class CamPosition
{
    public float x;
    public float y;
    public float z;
}

public class CamRotate : MonoBehaviour {

    public Transform playerTransform;
    public CamPosition cam;

	// Use this for initialization
	void Start () {
       
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            cam.x = cam.x * 1.1f;
            cam.y = cam.y * 1.1f;
            cam.z = cam.z * 1.1f;
        } else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cam.x = cam.x * .9f;
            cam.y = cam.y * .9f;
            cam.z = cam.z * .9f;
        }
        transform.position = new Vector3(
                                        playerTransform.position.x + cam.x,
                                        playerTransform.position.y + cam.y,
                                        playerTransform.position.z + cam.z
                                        );

    }
}
