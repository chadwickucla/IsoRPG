using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;
    private NavMeshAgent nav;
    private GameObject player;
    private LayerMask mask = -1;

    private Vector3 previousSighting;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        personalLastSighting = new Vector3 (0,0,0);
        
    }
    void Update()
    {
        if (playerInSight)
        {
            personalLastSighting = player.transform.position;
        }
        //if (nav.remainingDistance > .5)
        //{
            nav.SetDestination(personalLastSighting);
        //}
    }
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
