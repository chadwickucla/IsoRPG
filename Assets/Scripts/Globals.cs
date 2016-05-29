using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
//maybe store position vectors of spawns in here? (as you find them)
public class Globals : MonoBehaviour {
    public int tracker;
    public int lastMap;
    public int whichEntrance;
    public bool loading;
    public Globals recGlobals;
    
    //Camera blackout;
   // Camera regular;
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("TheGM").Length > 1)
        {
           // Debug.Log(GameObject.FindGameObjectsWithTag("TheGM").Length);
            Destroy(gameObject);
        }
    }

    void Start()
    {
       //make  a list. check all objects with tag TheGM. if list is larger than 1, destroy this objcet
       // blackout = GameObject.FindGameObjectWithTag("BlackCam").GetComponent<Camera>();//first attempt: is it happening?
       //  regular = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
       // blackout.enabled = false;
       //  regular.enabled = true;
        DontDestroyOnLoad(gameObject);
        loading = false;//reset whichEntrance?
        tracker = lastMap = 0;
        whichEntrance = 1;
    }
    void Update()
    {
        if (loading == true)//player entered some portal
                            //tracker == scene to be entered
                            //lastMap == scene that was last in (for placement purposes in new scene)
        {
            //   blackout = GameObject.FindGameObjectWithTag("BlackCam").GetComponent<Camera>();
            //   regular = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            //set blackcam to true and regular to false
            // blackout.enabled = true;
            //  regular.enabled = false;
            // Debug.Log("Loading == true");

            if (tracker == 0)//coming into town
            {
                // Debug.Log("Tracker == 0, LastMap = " + lastMap);
                loading = false;
                SceneManager.LoadScene(0);
                
            }

            else if (tracker == 2)//coming into itemshop
            {
                // Debug.Log("Tracker == 2, LastMap = " + lastMap);
                loading = false;
                SceneManager.LoadScene(2);
                
            }

            else if (tracker == 3)//coming into health hut last
            {
                loading = false;
                SceneManager.LoadScene(3);
                
            }
            else if (tracker == 1)//coming into forrest last
            {
                loading = false;
                SceneManager.LoadScene(1);
                
            }
            else if (tracker == 4)//coming into forrest last
            {
                loading = false;
                SceneManager.LoadScene(4);
                
            }
            
            //   blackout.enabled = false;
            //  regular.enabled = true;
            //set regular cam to true and black cam to false
            //new loadedBool for player pos. updating?
            
        }
    }
}
//problem: two trackers spawn and the newest one pulls player to original location