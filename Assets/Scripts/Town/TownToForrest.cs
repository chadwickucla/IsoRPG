using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TownToForrest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay (Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "player")
        {
            SceneManager.LoadScene(1);
        }
    }
}
