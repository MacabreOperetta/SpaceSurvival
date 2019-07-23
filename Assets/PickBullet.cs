using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBullet : MonoBehaviour {
    public Transform target;
    float distance;
    public SoldierInfo solinfo;
    public int bullet;
    private int addamount = 5;
    public ShowBullet show;
    // Use this for initialization
    void Start () {
        bullet = solinfo.currentbullet;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        bullet = solinfo.currentbullet;
        distance = Vector3.Distance(target.position, transform.position);
        
        if (distance <= 2 && bullet < 5)
        {
            bullet = 5;
            solinfo.currentbullet = bullet;
            show.Start();
            Destroy(gameObject);
        }
    }
}
