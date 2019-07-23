using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBullet : MonoBehaviour {
    public GameObject[] gamearray;
    public SoldierInfo solinfo;
    int bullet;
	// Use this for initialization
	public void Start () {
        for (int i = 0; i < gamearray.Length; i++)
        {
            gamearray[i].SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
        bullet = solinfo.currentbullet;
        for (int i = bullet; i <gamearray.Length; i++)
        {
            gamearray[i].SetActive(false);
        }
    }
}
