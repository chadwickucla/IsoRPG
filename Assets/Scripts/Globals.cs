using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Globals : MonoBehaviour {
    public int tracker;
    public int lastMap;
    public bool loading;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("TheGM").Length > 1)
        {
            Debug.Log(GameObject.FindGameObjectsWithTag("TheGM").Length);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //make  a list. check all objects with tag TheGM. if list is larger than 1, destroy this objcet
        
        DontDestroyOnLoad(gameObject);
        loading = false;
        tracker = lastMap = 0;
    }
    void Update()
    {
        if (loading == true)//player entered some portal
                            //tracker == scene to be entered
                            //lastMap == scene that was last in (for placement purposes in new scene)
        {
            Debug.Log("Loading == true");
            if (tracker == 0)//coming into town
            {
                Debug.Log("Tracker == 0, LastMap = " + lastMap);
                SceneManager.LoadScene(0);
                
                loading = false;
            }

            else if (tracker == 2)//coming into itemshop
            {
                Debug.Log("Tracker == 2, LastMap = " + lastMap);
                SceneManager.LoadScene(2);
                loading = false;
            }

            else if (tracker == 3)//coming into health hut last
            {
                SceneManager.LoadScene(3);
                loading = false;
            }
            else if (tracker == 1)//coming into forrest last
            {
                SceneManager.LoadScene(1);
                loading = false;
            }
        }
        
    }
}
//problem: two trackers spawn and the newest one pulls player to original location