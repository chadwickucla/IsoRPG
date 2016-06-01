using UnityEngine;
using System.Collections;

public class weaponController : MonoBehaviour {

    Animator anim;
    GameObject parent;
    GameObject player;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "enemy" && other.GetType() == typeof(CapsuleCollider) && player.GetComponentInChildren<Animator>().GetBool("isAttacking"))
        {
            parent = other.transform.parent.gameObject;
            anim = parent.GetComponent<Animator>();
            anim.SetBool("isDead", true);
        }
    }
}
