using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour {
    private Globals theGlobals;
    public int BuildIndexToGoTo; //set in inspector
   //THIS public int thisDoorway; //which door player is leaving through. decides entranceInt in globals
    //1 is default "thisDoorway" as most maps don't have two ways to get to the same map
    //possible future use with waypoint

	void Start ()
    {
        theGlobals = GameObject.FindGameObjectWithTag("TheGM").GetComponent<Globals>();    //find the global class  
    }
	
	void Update () {
	
	}
    
    void OnTriggerEnter(Collider Other)//this script works for places you don't start in.
    {
        if (Other.gameObject.tag == "Player")
        {
            //Debug.Log("Tag == player");
            //theGlobals.tempPlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
            theGlobals.lastMap = SceneManager.GetActiveScene().buildIndex;
        //THIS    theGlobals.whichEntrance = thisDoorway;
            theGlobals.tracker = BuildIndexToGoTo;
            theGlobals.loading = true;
        }
    }
}
