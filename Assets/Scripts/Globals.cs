using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class Globals : MonoBehaviour {

    public GameObject tracker;
    public bool sceneLoad;

    bool created = false;

    Transform shopSpawn;
    Transform healthSpawn;
    Transform forrestToTownSpawn;

    // Use this for initialization

    void Start () {
        sceneLoad = false;

        if (created == false)
        {
            Instantiate(tracker, new Vector3(0, 0, 0), Quaternion.identity);
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        else
        {
            //Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (sceneLoad == true)//make some bool that gets set to true on a scene load.
        {
            LoadAScene();
        }
	}

    void LoadAScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)//town start
        {

            sceneLoad = false;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)//shop entrance
        {
            SceneManager.LoadScene(0);
            shopSpawn = GameObject.FindGameObjectWithTag("shopSpawn").transform;
            GameObject.FindGameObjectWithTag("Player").transform.position = shopSpawn.position;
            sceneLoad = false;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)//health hut
        {

           sceneLoad = false;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)//forrest
        {

           sceneLoad = false;
        }
    }
}
