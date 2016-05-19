using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playercontroller : MonoBehaviour
{
    public Transform SpawnItemShop;
    //THIS public Transform SpawnHealthHutPatio;
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
    //bool fuckthisspawnglitch = false;
    //bool doublefuckthisspawnglitch = false;

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
            //THIS SpawnHealthHutPatio = GameObject.FindGameObjectWithTag("healthSpawnPatio").GetComponent<Transform>();
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

        anim = Paladin.GetComponent<Animator>();
        isIdle = true;
        isAttacking = false;
        isRunning = false;
        isDancing = false;

       
        if (theGlobals.tracker == 0)//entering town     //ABCDEFG
        {
            if (theGlobals.lastMap == 2)//from shop
            {
               gameObject.transform.position = SpawnItemShop.position;
            }
            else if (theGlobals.lastMap == 3)//from health
            {
                gameObject.transform.position = SpawnHealthHut.position;//THIS
                //THIS      if (theGlobals.whichEntrance == 1)//leaving through front door
                //THIS      {
                //THIS          gameObject.transform.position = SpawnHealthHut.position;
                //THIS      }
                //THIS      if (theGlobals.whichEntrance == 2)//leaving through patio door
                //THIS      {
                //THIS         gameObject.transform.position = SpawnHealthHutPatio.position;
                //THIS       }
            }
            else if (theGlobals.lastMap == 1)//from forrest
            {
                gameObject.transform.position = SpawnForrest.position;
            }
        }
        else if (theGlobals.tracker == 1)//entering forrest
        {
            if (theGlobals.lastMap == 4)//from den
            {
                Debug.Log(SpawnDen.position);
                gameObject.transform.position = SpawnDen.position;
                //gameObject.transform.position = SpawnForrestMiddle.position;
                //gameObject.transform.position = new Vector3(SpawnDen.position.x, SpawnDen.position.y, SpawnDen.position.z);//new Vector3(30.0f, 0.0f, 0.0f);//SpawnDen.position;
                //fuckthisspawnglitch = true;
                //doublefuckthisspawnglitch = true;
                //fuckin weird ass problem here where the player doesn't spawn at spawnden
                //the player will move with this line on, but doesn't move to the right location... they end up by some tree
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
        //THIS  if (theGlobals.tracker == 1 && theGlobals.lastMap == 4 && stillfuck == true)        //ABCDEFG
        //THIS  {
        //THIS      gameObject.transform.position = SpawnDen.position;
        //THIS      stillfuck = false;
        //THIS  }
        //THIS  if (theGlobals.tracker == 0 && theGlobals.lastMap == 2 && itemshopfuck == true)
        //THIS   {
        //THIS      SpawnItemShop = GameObject.FindGameObjectWithTag("shopSpawn").GetComponent<Transform>();///
        //THIS      gameObject.transform.position = SpawnItemShop.position;
        //THIS        itemshopfuck = false;
        //THIS   }
        //THIS  if (theGlobals.tracker == 0 && theGlobals.lastMap == 3 && patiospawnfuck == true && theGlobals.whichEntrance == 2)
        //THIS    {
        //THIS        SpawnHealthHutPatio = GameObject.FindGameObjectWithTag("healthSpawnPatio").GetComponent<Transform>();//
        //THIS        gameObject.transform.position = SpawnHealthHutPatio.position;
        //THIS        patiospawnfuck = false;
        //THIS   }


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