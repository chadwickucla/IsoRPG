using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LoadForrestOnE : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }
}
