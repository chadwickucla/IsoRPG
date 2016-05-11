using UnityEngine;
using System.Collections;

public class Kush : MonoBehaviour {
    //////////////////////////////////////////////////////////////////
    public AudioClip walkPastTalk;
    bool walkpastspam;
    public AudioClip walkPastSecond;            //AUDIO VARIABLES
    bool walkpastsecond;
    public AudioClip grumble;
    bool walkpastgrumble;
    //////////////////////////////////////////////////////////////////
    void Start () {
        walkpastspam = true;
        walkpastsecond = false;
        walkpastgrumble = false;
    }
	
	void Update () {
	
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (walkpastspam == true)
                StartCoroutine("WalkPast");
            else if (walkpastsecond == true)
                StartCoroutine("SecondWalkPast");
            else if (walkpastgrumble == true)
                StartCoroutine("Grumble");
        }
    }

    IEnumerator WalkPast(){
        gameObject.GetComponent<AudioSource>().PlayOneShot(walkPastTalk);
        walkpastspam = false;
        yield return new WaitForSeconds(4);
        walkpastsecond = true;
        walkpastgrumble = false;
    }
    IEnumerator SecondWalkPast()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(walkPastSecond);
        walkpastspam = false;
        walkpastsecond = false;
        yield return new WaitForSeconds(4);
        walkpastgrumble = true;
    }
    IEnumerator Grumble()
    {
        walkpastgrumble = false;
        gameObject.GetComponent<AudioSource>().PlayOneShot(grumble);
        yield return new WaitForSeconds(4);
        walkpastgrumble = true;
    }
}
