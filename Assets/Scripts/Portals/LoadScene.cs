using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour {
    private Globals theGlobals;
    public int BuildIndexToGoTo; //set in inspector
	// Use this for initialization

	void Start () {
        theGlobals = GameObject.FindGameObjectWithTag("TheGM").GetComponent<Globals>();    //find the global class 
                             // update the current level
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter(Collider Other)//this script works for places you don't start in.
    {
        if (Other.gameObject.tag == "Player")
        {
            //Debug.Log("Tag == player");
            //theGlobals.tempPlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
            theGlobals.lastMap = SceneManager.GetActiveScene().buildIndex;
            theGlobals.tracker = BuildIndexToGoTo;
            theGlobals.loading = true;
        }
    }
}
