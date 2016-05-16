using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour
{

    private bool isIdle;
    private bool isAttacking;
    private bool isRunning;
    public GameObject Paladin;
    Animator anim;

    NavMeshAgent agent;
    private bool mouseDown;
    public LayerMask mask = -1;

    void Start()
    {
        isIdle = true;
        isAttacking = false;
        isRunning = false;
        anim = Paladin.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0) && GUIUtility.hotControl == 0)
        {
            mouseDown = false;
        }

        if (mouseDown == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, mask.value))
            {
                agent.SetDestination(hit.point);
            }
        }


        if (agent.remainingDistance > 0.5f)
        {
            isRunning = true;
            isIdle = false;
            isAttacking = false;
        }

        else if (agent.remainingDistance <= 0.5f)//prob. solve for instant run deactivate
        {
            isRunning = false;
            isIdle = true;
            isAttacking = false;
        }

        if (isRunning == true)
        {
            anim.SetBool("isRunning",true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
        }
        else if (isAttacking == true)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking",true);
        }
        else if(isIdle == true)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isIdle",true);
        }
    }
    
    /*
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
    */
    /*void OnTriggerEnter (Collider Other)
    {
        Debug.Log(canWalk);
        if ((Other.tag == "wall")|| Other.tag == "NPC")
         canWalk = false;
        Debug.Log(canWalk);
    }*/

}