using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
    private GameObject theGlobals;
	// Use this for initialization
	void Start () {
        theGlobals = GameObject.FindGameObjectWithTag("tracker");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter()
    {
        theGlobals.GetComponent<Globals>().sceneLoad = true;
    }
}
