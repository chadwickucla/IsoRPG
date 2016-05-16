using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class Globals : MonoBehaviour {

    public int sceneNumber;
    public bool sceneLoad;
	// Use this for initialization

	void Start () {
        sceneNumber = 0;
        sceneLoad = false;
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

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
