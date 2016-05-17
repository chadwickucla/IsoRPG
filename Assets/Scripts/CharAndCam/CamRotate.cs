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
    Vector3 camD;
    float distance;

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
        camD = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        distance = Vector3.Distance(camD, playerTransform.position);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log(distance);
            if (distance < 20)
            {
                cam.x = Mathf.Min(cam.x * 1.1f, maxX);
                cam.y = Mathf.Max(cam.y * 1.1f, maxY);
                cam.z = Mathf.Max(cam.z * 1.1f, maxZ);
            }
           
        } else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Debug.Log(distance);
            if (distance > 4)
            {
                cam.x = Mathf.Min(cam.x * 0.9f, minX);
                cam.y = Mathf.Max(cam.y * 0.9f, minY);
                cam.z = Mathf.Max(cam.z * 0.9f, minZ);
            }
           
        }
        transform.position = new Vector3(
                                        playerTransform.position.x + cam.x,
                                        playerTransform.position.y + cam.y,
                                        playerTransform.position.z + cam.z
                                        );

    }//issue with max valuse
}
