﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class playercontroller : MonoBehaviour
{
    public Transform SpawnItemShop;
    public Transform SpawnHealthHutPatio;
    public Transform SpawnHealthHut;
    public Transform SpawnForrest;
    public Transform SpawnDen;

    public AudioClip Beats;
    public AmbientSong musictracker;

    private bool isIdle;
    private bool isAttacking;
    private bool isRunning;
    private bool isDancing;
    private bool songOn;
    private int sceneIndex;

    public GameObject Paladin;
    Animator anim;
    Globals theGlobals;//ABCDEFG

    NavMeshAgent agent;
    private bool mouseDown;
    public LayerMask mask = -1;

    void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        loadSpawnPoints(sceneIndex); 
    }

    void Start()
    {
        isIdle = true;
        isAttacking = false;
        isRunning = false;
        isDancing = false;
        songOn = false;

        agent = GetComponent<NavMeshAgent>();
        musictracker = GameObject.FindGameObjectWithTag("musictracker").GetComponent<AmbientSong>();
        theGlobals = GameObject.FindGameObjectWithTag("TheGM").GetComponent<Globals>();//ABCDEFG
        anim = Paladin.GetComponent<Animator>();//ANIMATION BOOL TRIGGERS

        positionPlayer();
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {
            musictracker.Unpause();
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0) && GUIUtility.hotControl == 0)
        {
            mouseDown = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            agent.SetDestination(transform.position);
            if (!isDancing)
                startDance();
            else
                stopDance();
        }
        if (mouseDown == true)
        {
            stopDance();
            movePlayer();
        }
        if (agent.remainingDistance < 0.5f && !isDancing)
        {
            idlePlayer();
        }
    }
    void movePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, mask.value))
        {
            agent.SetDestination(hit.point);
        }

        if (agent.remainingDistance > 0.5f)
        {
            playerRun();
        }
        else
        {
            playerIdle();   
        }
    }
    void idlePlayer()
    {
        if (agent.remainingDistance <= 0.5f)
            playerIdle();
    }
    void startDance ()
    {
        isDancing = true;
        musictracker.Pause();

        GetComponent<AudioSource>().enabled = true;
        GetComponent<AudioSource>().PlayOneShot(Beats);
        playerDance();
    }
    void stopDance()
    {
        isDancing = false;
        playerIdle();
        musictracker.Unpause();
        GetComponent<AudioSource>().enabled = false;
    }
    void playerDance()
    {
        anim.SetBool("isDancing", true);
        anim.SetBool("isRunning", false);
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", false);
    }
    void playerIdle() {
        anim.SetBool("isDancing", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isIdle", true);
    }
    void playerAttack()
    {
        anim.SetBool("isDancing", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", true);
    }
    void playerRun()
    {
        anim.SetBool("isDancing", false);
        anim.SetBool("isRunning", true);
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", false);
    }
    void loadSpawnPoints(int sceneIndex)
    {
        if (sceneIndex == 0) {
            SpawnItemShop = GameObject.FindGameObjectWithTag("shopSpawn").GetComponent<Transform>();
            SpawnHealthHut = GameObject.FindGameObjectWithTag("healthSpawn").GetComponent<Transform>();
            SpawnHealthHutPatio = GameObject.FindGameObjectWithTag("healthSpawnPatio").GetComponent<Transform>();
            SpawnForrest = GameObject.FindGameObjectWithTag("forrestSpawn").GetComponent<Transform>();
        } else if (sceneIndex == 1) {
            SpawnDen = GameObject.FindGameObjectWithTag("denSpawn").GetComponent<Transform>();
        }
    }

    void positionPlayer()
    {
        if (theGlobals.tracker == 0) { //Entering Town
            if (theGlobals.lastMap == 2) { //from shop
                agent.enabled = false;
                gameObject.transform.position = SpawnItemShop.position;
                gameObject.transform.rotation = SpawnItemShop.rotation;
                agent.enabled = true;
            } else if (theGlobals.lastMap == 3) { //from health
                if (theGlobals.whichEntrance == 1) { //leaving through front door
                    agent.enabled = false;
                    gameObject.transform.position = SpawnHealthHut.position;
                    gameObject.transform.rotation = SpawnHealthHut.rotation;
                    agent.enabled = true;
                } else if (theGlobals.whichEntrance == 2) { //leaving through patio door
                    agent.enabled = false;
                    gameObject.transform.position = SpawnHealthHutPatio.position;
                    gameObject.transform.rotation = SpawnHealthHutPatio.rotation;
                    agent.enabled = true;
                }
            }
            else if (theGlobals.lastMap == 1) { //from forrest
                agent.enabled = false;
                gameObject.transform.position = SpawnForrest.position;
                gameObject.transform.rotation = SpawnForrest.rotation;
                agent.enabled = true;
            }
        }
        else if (theGlobals.tracker == 1) { //entering forrest
            if (theGlobals.lastMap == 4) { //from den
                agent.enabled = false;
                gameObject.transform.position = SpawnDen.position;
                gameObject.transform.rotation = SpawnDen.rotation;
                agent.enabled = true;
            } else if (theGlobals.lastMap == 0) { //from town
                //do nothing since we want the char to spawn at typical location
            }
        } else if (theGlobals.tracker == 2) { //entering shop

        } else if (theGlobals.tracker == 3) { //entering health

        } else if (theGlobals.tracker == 4) { //entering den

        }
    }
}