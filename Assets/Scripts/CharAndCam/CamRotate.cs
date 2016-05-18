using UnityEngine;
using System.Collections;
[System.Serializable]
public class CamPosition
{
    public float x;
    public float y;
    public float z;
    public float maxZoom;
    public float minZoom;

}

public class CamRotate : MonoBehaviour {
    public Transform playerTransform;
    public CamPosition cam;
    private float maxX, maxY, maxZ, minX, minY, minZ;

	// Use this for initialization
	void Start () {
        

        maxX = cam.x * cam.maxZoom;
        maxY = cam.y * cam.maxZoom;
        maxZ = cam.z * cam.maxZoom;

        minX = cam.x * cam.minZoom;
        minY = cam.y * cam.minZoom;
        minZ = cam.z * cam.minZoom;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //Debug.Log("asdfasdfasdf");
            cam.x = Mathf.Max(cam.x * 1.1f, maxX);
            cam.y = Mathf.Min(cam.y * 1.1f, maxY);
            cam.z = Mathf.Min(cam.z * 1.1f, maxZ);  
           
        } else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cam.x = Mathf.Min(cam.x * 0.9f, minX);
            cam.y = Mathf.Max(cam.y * 0.9f, minY);
            cam.z = Mathf.Max(cam.z * 0.9f, minZ);
        }
        transform.position = new Vector3(
                                        playerTransform.position.x + cam.x,
                                        playerTransform.position.y + cam.y,
                                        playerTransform.position.z + cam.z
                                        );

    }//issue with max valuse
}
