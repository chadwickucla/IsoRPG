using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {
    public AudioClip AmbientMusic;
    public GameObject dir_Light;

	// Use this for initialization
	void Start () {
       // gameObject.GetComponent<AudioSource>().PlayOneShot(AmbientMusic);
	}
	
	// Update is called once per frame
	void Update () {
       // dir_Light.transform.Rotate(0.03f, 0.0f, 0.0f);//light rotation
	}
}
