using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour
{
    private float moveSpeed;
    public float playerSpeed;
    public Transform myTransform;
    private Vector3 destinationPosition;
    private float destinationDistance;
    private bool mouseDown = false;
    bool canWalk;
    // Use this for initialization
    void Start()
    {
        canWalk = true;
        destinationPosition = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);

        if (destinationDistance < .5f)
        {
            moveSpeed = 0;
        }
        else if (destinationDistance > .5f)
        {
            moveSpeed = playerSpeed;
        }


        // Moves the Player if the Left Mouse Button was clicked
        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0) && GUIUtility.hotControl == 0)
        {
            mouseDown = false;
            canWalk = true;
        }
        if (mouseDown == true)
        { 
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                destinationPosition = hit.point;
            }
        }


        // To prevent code from running if not needed
        if ((destinationDistance > .5f) && canWalk == true)
        {
            myTransform.position = Vector3.MoveTowards(myTransform.position, new Vector3(destinationPosition.x, myTransform.position.y, destinationPosition.z), moveSpeed * Time.deltaTime);
        }

    }
    void OnTriggerEnter (Collider Other)
    {
        Debug.Log(canWalk);
        if ((Other.tag == "wall")|| Other.tag == "NPC")
         canWalk = false;
        Debug.Log(canWalk);
    }
    
}