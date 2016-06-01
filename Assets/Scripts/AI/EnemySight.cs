using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;
    private SphereCollider col;
    private NavMeshAgent nav;
    private GameObject player;
    public LayerMask mask = -1;
    private bool isDead = false;

    public float reduceRunAnim; //added this

    Animator anim;

    private Vector3 previousSighting;

    void Start()
    {
        reduceRunAnim = 1.0f;
        col = GetComponent<SphereCollider>(); 
        anim = gameObject.GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        personalLastSighting = gameObject.transform.position;//new Vector3 (0,0,0);//this 0,0,0 was sending them to the central scene location on scene load. replaced with current position. works
        playerInSight = false;
    }
    void Update()
    {
        if (!isDead)
        {
            if (anim.GetBool("isDead") == true)
            {
                isDead = true;
                //remove navmeshagent
                transform.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                //move enemy child to the ignore click layer
                foreach (Transform child in transform)
                {
                    if (child.gameObject.tag == "enemy")
                    {
                        child.gameObject.layer = LayerMask.NameToLayer("ignoreclick");
                    }
                }
                return;
            }
            if (playerInSight == true)
            {

                personalLastSighting = player.transform.position;
                if (Vector3.Distance(player.transform.position, gameObject.transform.position) > 3)
                {
                    pursuePlayer();
                    nav.SetDestination(personalLastSighting);
                }
                else
                    danceWithPlayer();
            }
            else if (playerInSight == false && nav.remainingDistance <= 3)
                patrolArea();
        }
        
    }
    void pursuePlayer () {
        anim.SetBool("isRunning", true);
        anim.SetBool("isDancing", false);
        anim.SetBool("isIdle", false);

    }

    void danceWithPlayer()
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("isDancing", true);
        anim.SetBool("isIdle", false);//placeholder for attacking
    }
    
    void patrolArea()
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("isDancing", false);
        anim.SetBool("isIdle", true);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle < fieldOfViewAngle * 0.5f)
            {

                RaycastHit hit;
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if (hit.collider.gameObject == player)
                        playerInSight = true;
                    //else
                    //playerInSight = false;
                }
                //else
                    //playerInSight = false;

            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) > 3)
            {
                playerInSight = false;
            }
        }
    }
}
