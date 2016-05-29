using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playercontroller : MonoBehaviour
{
    public Transform SpawnItemShop;
    public Transform SpawnHealthHutPatio;
    public Transform SpawnHealthHut;
    public Transform SpawnForrest;
    public Transform SpawnDen;

    public AudioClip Beats;
    public AmbientSong musictracker;

    private bool isIdle;
    private bool isAttacking;
    private bool isRunning;
    private bool isDancing;
    private bool songOn;

    bool stillfuck = true;
    bool itemshopfuck = true;
    bool patiospawnfuck = true;
    

    public GameObject Paladin;
    Animator anim;
    Globals theGlobals;//ABCDEFG

    NavMeshAgent agent;
    private bool mouseDown;
    public LayerMask mask = -1;

    void Awake()
    {
        Debug.Log("TESTING");
        if (SceneManager.GetActiveScene().buildIndex == 0)//ABCDEFG
        {
            SpawnItemShop = GameObject.FindGameObjectWithTag("shopSpawn").GetComponent<Transform>();
            SpawnHealthHut = GameObject.FindGameObjectWithTag("healthSpawn").GetComponent<Transform>();
            SpawnHealthHutPatio = GameObject.FindGameObjectWithTag("healthSpawnPatio").GetComponent<Transform>();
            SpawnForrest = GameObject.FindGameObjectWithTag("forrestSpawn").GetComponent<Transform>();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)//ABCDEFG
        {
            //Debug.Log("IsThisRun?");
            SpawnDen = GameObject.FindGameObjectWithTag("denSpawn").GetComponent<Transform>();
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        musictracker = GameObject.FindGameObjectWithTag("musictracker").GetComponent<AmbientSong>();
        songOn = false;

        theGlobals = GameObject.FindGameObjectWithTag("TheGM").GetComponent<Globals>();//ABCDEFG

        anim = Paladin.GetComponent<Animator>();//ANIMATION BOOL TRIGGERS
        isIdle = true;
        isAttacking = false;
        isRunning = false;
        isDancing = false;

       
        if (theGlobals.tracker == 0)//entering town     //ABCDEFG
        {
            if (theGlobals.lastMap == 2)//from shop
            {
               agent.enabled = false;
               gameObject.transform.position = SpawnItemShop.position;
               gameObject.transform.rotation = SpawnItemShop.rotation;
               agent.enabled = true;
            }
            else if (theGlobals.lastMap == 3)//from health
            {
                if (theGlobals.whichEntrance == 1)//leaving through front door
                {
                    agent.enabled = false;
                    gameObject.transform.position = SpawnHealthHut.position;
                    gameObject.transform.rotation = SpawnHealthHut.rotation;
                    agent.enabled = true;
                }
               if (theGlobals.whichEntrance == 2)//leaving through patio door
                {
                    agent.enabled = false;
                    gameObject.transform.position = SpawnHealthHutPatio.position;
                    gameObject.transform.rotation = SpawnHealthHutPatio.rotation;
                    agent.enabled = true;
                }
            }
            else if (theGlobals.lastMap == 1)//from forrest
            {
                agent.enabled = false;
                gameObject.transform.position = SpawnForrest.position;
                gameObject.transform.rotation = SpawnForrest.rotation;
                agent.enabled = true;
            }
        }
        else if (theGlobals.tracker == 1)//entering forrest
        {
            if (theGlobals.lastMap == 4)//from den
            {
                agent.enabled = false;
                gameObject.transform.position = SpawnDen.position;
                gameObject.transform.rotation = SpawnDen.rotation;
                agent.enabled = true;
            }
            else if (theGlobals.lastMap == 0)//from town
            {
                //do nothing since we want the char to spawn at typical location
            }
        }
        else if (theGlobals.tracker == 2)//entering shop
        {

        }
        else if (theGlobals.tracker == 3)//entering health
        {

        }
        
        else if (theGlobals.tracker == 4)//entering den
        {

        }
    }


    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.D)) && (isIdle == true))
        {
            Debug.Log("DANCE BITCH");
            isDancing = true;
        }
        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {
            if (isDancing == true)
            {
                musictracker.Unpause();
            }
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
            GetComponent<AudioSource>().Stop();
            isRunning = true;
            isIdle = false;
            isAttacking = false;
            isDancing = false;
       }

        else if (agent.remainingDistance <= 0.5f)//always compare with stopping distance on character
        {
            isRunning = false;
            isAttacking = false;
            if (!isDancing)
            {
                isIdle = true;
                songOn = false;
            }
            else
            {
                if (songOn == false)
                {
                        musictracker.Pause();
                        GetComponent<AudioSource>().PlayOneShot(Beats);
                        songOn = true;
                }
                isIdle = false;
            }
        }

        if (isRunning == true)
        {
            anim.SetBool("isDancing", false);
            anim.SetBool("isRunning",true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
        }
        else if (isAttacking == true)
        {
            anim.SetBool("isDancing", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking",true);
        }
        else if(isIdle == true)
        {
            anim.SetBool("isDancing", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isIdle",true);
        }
        else if (isDancing == true)
        {
            anim.SetBool("isDancing", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
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
}