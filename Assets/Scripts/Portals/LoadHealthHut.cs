using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadHealthHut : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }
    }
}
