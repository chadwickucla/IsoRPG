using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadTown : MonoBehaviour {
    Globals theGlobals;
    int currentMap;
	// Use this for initialization
	void Start () {
        theGlobals = GameObject.FindGameObjectWithTag("TheGM").GetComponent<Globals>();
        currentMap = SceneManager.GetActiveScene().buildIndex;

        if (theGlobals.tracker == 2)
        {
            //transport player to itemshop entrance
        }
        else if (theGlobals.tracker == 1)
        {
            //teleport player to forrest entrance
        }
        else if (theGlobals.tracker == 3)
        {
            //teleport player to healthhut entrance

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay(Collider other)
    {
    
    }
}
