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
        transform.position = new Vector3(
                                        playerTransform.position.x + cam.x,
                                        playerTransform.position.y + cam.y,
                                        playerTransform.position.z + cam.z
                                        );

    }
}
