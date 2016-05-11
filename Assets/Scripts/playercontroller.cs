using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private Vector3 targetPosition;
    private Vector3 playerPosition;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        

    }
    void FixedUpdate ()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
              
        }
    
        
    }
}
