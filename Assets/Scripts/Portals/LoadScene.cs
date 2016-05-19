using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour {
    private Globals theGlobals;
    public int BuildIndexToGoTo; //set in inspector; corresponds to the scene the door should take you tozcf
    public int thisDoorway;/*      which door player is leaving through. decides entranceInt in globals
                                   1 is default "thisDoorway" as most maps don't have two ways to get to the same map
                                   possible future use with waypoint                                        */

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
            theGlobals.whichEntrance = thisDoorway;
            theGlobals.lastMap = SceneManager.GetActiveScene().buildIndex;
            theGlobals.tracker = BuildIndexToGoTo;
            theGlobals.loading = true;              
        }
    }
}
