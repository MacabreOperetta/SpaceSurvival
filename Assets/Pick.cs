using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour {
    public Transform target;
    float distance;
    public Player solinfo;
    public int health;
    private int addamount = 20;
    // Use this for initialization
    void Start () {
        health = solinfo.currenthealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update () {
        health = solinfo.currenthealth;
        distance = Vector3.Distance(target.position, transform.position);
        if(distance <=2 && health<100)
        {
            if(health<80)
            {
                health += addamount;
                solinfo.currenthealth = health;
            }
            else
            {
                solinfo.currenthealth = 100;
                    
            }
            Destroy(gameObject);
        }
    }
}
