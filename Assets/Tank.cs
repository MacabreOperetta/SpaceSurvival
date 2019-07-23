using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Tank : MonoBehaviour
{
    private bool isgettinghit;
    float distance;
    Vector3 lookVector;
    [Header("Enemy Movement Stats")]
    public Transform target;
    public float speed;
    public float trans1;
    public float trans2;
    public float trans3;
    [Header("Enemy Laser Stats")]
    public GameObject mainProjectile;
    public ParticleSystem mainParticleSystem;
    AudioSource audioplay;
    public PlayAnimOnKeyUp soldierscript;
    float timer = 0.8f;
    public AudioClip impact;
    public int damage;
    private int health = 100;
    public int currenthealth;
    public string enemyname;
    public Image healthslider;
    public Text enemytext;
    float healthprog;
    public GameObject enemybar;
    public Transform parttorotate;
    public float turnspeed;
    // Use this for initialization

    void Start()
    {
        enemybar.SetActive(false);
        currenthealth = health;
        damage = soldierscript.damage;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        audioplay = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isgettinghit = true;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(target.position, transform.position);
        lookVector = target.transform.position - transform.position;
        if(currenthealth<0)
        {
            enemybar.SetActive(false);
            Destroy(this.gameObject);
        }
        if (distance <= 20f)
        {
            enemybar.SetActive(true);
            enemytext.text = enemyname;
            healthprog = currenthealth;
            healthslider.fillAmount = healthprog / 100;
            if (!isgettinghit && currenthealth > 0)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    LaserBeam();
                    timer = 1f;
                }


            }
            if (isgettinghit)
            {
                currenthealth -= 25;
                currenthealth -= damage;
                isgettinghit = false;
            }

        }
        if (distance < 50f && distance > 20f)
        {
            trans3 -= speed * Time.deltaTime;

            transform.Translate(0, 0, trans3);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.deltaTime * speed / 2);

        }
    }

    public void LaserBeam()
    {
        audioplay.PlayOneShot(impact);
        GameObject laser = Instantiate(mainProjectile, transform.position, Quaternion.identity);
        laser.transform.parent = GameObject.Find("TankPoint").transform;
        Destroy(laser, 1f);
    }
}
