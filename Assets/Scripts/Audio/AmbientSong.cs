using UnityEngine;
using System.Collections;

public class AmbientSong : MonoBehaviour {

    public static AmbientSong instance;

    public AudioClip musicTown;
    public AudioClip musicForrest;

    bool isTown;
    bool isForrest;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("LevelLoaded!");
        if (level == 0)
        {
            if (isTown == false)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = musicTown;
                GetComponent<AudioSource>().Play();
                isTown = true;
                isForrest = false;
            }
        }
        else if (level == 1)
        {
            if (isForrest == false)
            { 
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = musicForrest;
                GetComponent<AudioSource>().Play();
            }
            isTown = false;
            isForrest = true;
        }
        else//level == 2, 3
        {
            return;
        }
    }

	// Use this for initialization
	void Start () {
        isTown = true;
        GetComponent<AudioSource>().clip = musicTown;
        GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
