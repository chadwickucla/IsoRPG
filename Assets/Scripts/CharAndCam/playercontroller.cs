using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playercontroller : MonoBehaviour
{
    public Transform SpawnItemShop;
    public Transform SpawnHealthHut;
    public Transform SpawnForrest;

    private bool isIdle;
    private bool isAttacking;
    private bool isRunning;
    public GameObject Paladin;
    Animator anim;
    Globals theGlobals;

    NavMeshAgent agent;
    private bool mouseDown;
    public LayerMask mask = -1;

    void Start()
    {
        theGlobals = GameObject.FindGameObjectWithTag("TheGM").GetComponent<Globals>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SpawnItemShop = GameObject.FindGameObjectWithTag("shopSpawn").GetComponent<Transform>();
            SpawnHealthHut = GameObject.FindGameObjectWithTag("healthSpawn").GetComponent<Transform>();
            SpawnForrest = GameObject.FindGameObjectWithTag("forrestSpawn").GetComponent<Transform>();
        }

        isIdle = true;
        isAttacking = false;
        isRunning = false;
        anim = Paladin.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (theGlobals.tracker == 0)//entering town
        {
            if (theGlobals.lastMap == 2)//from shop
            {
                gameObject.transform.position = SpawnItemShop.position;
            }
            else if (theGlobals.lastMap == 3)//from health
            {
                gameObject.transform.position = SpawnHealthHut.position;
            }
            else if (theGlobals.lastMap == 1)//from forrest
            {
                gameObject.transform.position = SpawnForrest.position;
            }
        }
        else if (theGlobals.tracker == 2)//entering shop
        {

        }
        else if (theGlobals.tracker == 3)//entering health
        {

        }
        else if (theGlobals.tracker == 1)//entering forrest
        {

        }
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