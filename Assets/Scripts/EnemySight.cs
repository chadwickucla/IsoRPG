using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;
    private NavMeshAgent nav;
    private GameObject player;
    private LayerMask mask = -1;

    public float reduceRunAnim; //added this

    Animator anim;

    private Vector3 previousSighting;

    void Start()
    {
        reduceRunAnim = 1.0f;
        anim = gameObject.GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        personalLastSighting = gameObject.transform.position;//new Vector3 (0,0,0);//this 0,0,0 was sending them to the central scene location on scene load. replaced with current position. works
        playerInSight = false;
    }
    void Update()
    {
        
        if (playerInSight == true)//we r gonna be running
        {
           Debug.Log(nav.remainingDistance);
            if (nav.remainingDistance > 3)//CHASE RANEG
            {
                //Debug.Log("PlayerInSightButFar");
                
                anim.SetBool("isRunning", true);
               //GetComponent<Animation>()["Vampire_A_Lusth@running_inPlace"].speed = reduceRunAnim;//possible way to reduce odd run look
                anim.SetBool("isDancing", false);
                anim.SetBool("isIdle", false);
            }
            else
            {
                //Debug.Log("PlayerInSightButNear");
                if (nav.remainingDistance <3 )//ATTACL/DANCE RANGE
                { 
                anim.SetBool("isRunning", false);
                anim.SetBool("isDancing", true);
                anim.SetBool("isIdle", false);//placeholder for attacking
                }
            }
            personalLastSighting = player.transform.position;
        }
        else//PLAYER ESCAPED
        {
            //Debug.Log("PlayerNotInSight");
            anim.SetBool("isRunning", false);
            anim.SetBool("isDancing", false);
            if (nav.remainingDistance < 3)
                anim.SetBool("isIdle", true);
        }
       // if (nav.remainingDistance > .5)
      //  {
        
        nav.SetDestination(personalLastSighting);
       // }
    }
    /*void OnLevelWasLoaded(int level)
    {
        playerInSight = false;
        anim.SetBool("isRunning", false);
        anim.SetBool("isDancing", true);
        anim.SetBool("isIdle", false);
    }*/

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInSight = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInSight = false;
        }
    }
}
