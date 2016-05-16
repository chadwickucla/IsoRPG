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
    //-6 14.2 4
    //Max: -18   42.6  12
    //Min: -2    4.73  1.33
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
