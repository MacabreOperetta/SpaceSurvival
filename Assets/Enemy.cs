using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    float distance;
    public Transform target;
    static Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        distance= Vector3.Distance(target.position, transform.position);
        if (distance < 20f)
        {
            Debug.Log("Yakın");

            anim.SetBool("Run", true);

        }
        if(distance<50f)
        {
            anim.SetBool("Run", true);
        }
    }
}
