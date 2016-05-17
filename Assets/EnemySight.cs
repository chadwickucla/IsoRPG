using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;
    private NavMeshAgent nav;
    private GameObject player;
    private LayerMask mask = -1;

    Animator anim;

    private Vector3 previousSighting;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        personalLastSighting = new Vector3 (0,0,0);
        playerInSight = false;
    }
    void Update()
    {
        
        if (playerInSight == true)//we r gonna be running
        {
            //Debug.Log(nav.remainingDistance);
            if (nav.remainingDistance > 3)
            {
                //Debug.Log("PlayerInSightButFar");
                anim.SetBool("isRunning", true);
                anim.SetBool("isDancing", false);
                anim.SetBool("isIdle", false);
            }
            else
            {
                //Debug.Log("PlayerInSightButNear");
                anim.SetBool("isRunning", false);
                anim.SetBool("isDancing", true);
                anim.SetBool("isIdle", false);//placeholder for attacking
            }
            personalLastSighting = player.transform.position;
        }
        else
        {
            
           // if (nav.remainingDistance < 3)
            //{
                //Debug.Log("PlayerNotInSight");
                anim.SetBool("isRunning", false);
                anim.SetBool("isDancing", false);
                anim.SetBool("isIdle", true);
            //}
        }
        //if (nav.remainingDistance > .5)
        //{
        nav.SetDestination(personalLastSighting);
        //}
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
