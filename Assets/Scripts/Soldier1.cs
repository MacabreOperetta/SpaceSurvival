using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Soldier1 : MonoBehaviour {

    static Animator anim;
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
    float timer=0.8f;
    public AudioClip impact;
    public int damage;
    private int health=100;
    public int currenthealth;
    public string enemyname;
    public Image healthslider;
    public Text enemytext;
    float healthprog;
    public GameObject enemybar;
    public Transform parttorotate;
    public float turnspeed;
    // Use this for initialization

    void Start () {
        enemybar.SetActive(false);
        currenthealth = health;
        damage = soldierscript.damage;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        audioplay = GetComponent<AudioSource>();
        //anim.SetBool("IsDead", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isgettinghit = true;
    }

    // Update is called once per frame
    void Update () {

        distance = Vector3.Distance(target.position, transform.position);
        lookVector = target.transform.position - transform.position;
        if(currenthealth<0)
        {
            anim.SetBool("IsDead", true);
        }
        if (distance <= 20f)
        {
            LockOnTarget();
            anim.SetBool("Run", false);
            enemybar.SetActive(true);
            enemytext.text = enemyname;
            healthprog = currenthealth;
            healthslider.fillAmount = healthprog / 100;
            if (!isgettinghit && currenthealth > 0)
            {
                anim.SetBool("Hit", false);
                anim.SetBool("Aim", true);
                anim.SetBool("Fire", true);
                timer -= Time.deltaTime;

                if (timer <= 0 && currenthealth>0)
                {
                    LaserBeam();
                    timer = 1f;
                }


            }
            if (isgettinghit)
            {
                currenthealth -= 25;
                anim.SetBool("Run", false);
                anim.SetBool("Hit", true);
                currenthealth -= damage;
                anim.SetBool("Aim", false);
                anim.SetBool("Fire", false);
                isgettinghit = false;
            }

        }
        if (distance < 50f && distance > 20f)
        {

            anim.SetBool("Run", true);
            anim.SetBool("Aim", false);
            anim.SetBool("Fire", false);
            trans3 += speed * Time.deltaTime;

            transform.Translate(0, 0, trans3);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.deltaTime * speed/2);

        }
    }
    IEnumerator OnCompleteAttackAnimation()
    {
        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;
        anim.SetBool("Hit", false);

    }

    public void LaserBeam()
    {
        audioplay.PlayOneShot(impact);
        GameObject laser = Instantiate(mainProjectile, transform.position, Quaternion.identity);
        laser.transform.parent = GameObject.Find("Point").transform;
        Destroy(laser, 1f);
    }
    public void LockOnTarget()
    {
            Vector3 dir = target.position - transform.position;
            Quaternion lookrotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(parttorotate.rotation, lookrotation, Time.deltaTime * turnspeed).eulerAngles;
            parttorotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
