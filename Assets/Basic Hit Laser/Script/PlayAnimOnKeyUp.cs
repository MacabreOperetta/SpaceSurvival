using UnityEngine;
using System.Collections;

public class PlayAnimOnKeyUp : MonoBehaviour {

    public GameObject mainProjectile;
    public ParticleSystem mainParticleSystem;
    AudioSource audioplay;
    public AudioClip impact;
    public SoldierInfo solinfo;
    public int bullet;
    public int damage=20;
    void Start()
    {
        bullet = solinfo.currentbullet;
        audioplay = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {
        bullet = solinfo.currentbullet;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(bullet>0){
                audioplay.PlayOneShot(impact);
                GameObject laser = Instantiate(mainProjectile, transform.position, Quaternion.identity);
                laser.transform.parent = GameObject.Find("LaserPoint").transform;


                Destroy(laser, 1f);
                bullet--;
            }
            solinfo.currentbullet = bullet;

        }

    }

}
