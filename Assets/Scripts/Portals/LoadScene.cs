using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour {
    private Globals theGlobals;
    public int BuildIndexToGoTo; //set in inspector; corresponds to the scene the door should take you tozcf
    public int thisDoorway;/*      which door player is leaving through. decides entranceInt in globals
                                   1 is default "thisDoorway" as most maps don't have two ways to get to the same map
                                   possible future use with waypoint    
                                   */
    public LayerMask mask = -1;
    private GameObject hitObj;
	void Start ()
    {
        theGlobals = GameObject.FindGameObjectWithTag("TheGM").GetComponent<Globals>();    //find the global class  
    }
	
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, mask.value))
        {
            if (hit.collider.tag == "portal")
            {
                hitObj = hit.transform.gameObject; 
                Renderer rend = hitObj.GetComponent<Renderer>();
                rend.enabled = true;
            }
            else
            {
                Component[] allComponents = hitObj.GetComponents<Component>();
                if (allComponents.Length == 1)
                {
                    //do nothing
                } else
                {
                    Renderer rend = hitObj.GetComponent<Renderer>();
                    rend.enabled = false;
                }   
            }
        }


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
