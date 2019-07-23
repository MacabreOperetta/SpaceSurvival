using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    
        static Animator anim;
        [Header("Soldier Attributes")]
        public float speed = 2.0f;
        public float jumspeed = 0.2f;
        public float backspeed = 1.0f;
        public float rotationspeed = 75f;// Use this for initialization
        
        [Header("Stamina Health Attributes")]

        
        public float currentstamina;
        private float stamina=100;
        bool isstaminaregen;
        public float staminaregen;
        public int currenthealth;
        private int health = 100;

        [Header("Panel")]
        public GameObject youwincanvas;
        public GameObject youlostcanvas;
        public GameObject gamecanvas;
        public Text healthtext;
        public GameObject light1;
        public GameObject light2;
        public Spawn spawn;
        public Text text;
        void Start()
        {
            light1.SetActive(true);
            light2.SetActive(true);
            Time.timeScale = 1;
            gamecanvas.SetActive(true);
            currentstamina = stamina;
            currenthealth = health;
            anim = GetComponent<Animator>();
        }
        private void OnCollisionEnter(Collision collision)
        {
           currenthealth -= 10;
           Destroy(collision.gameObject);
        }
    // Update is called once per frame
        void Update()
        {
            float translation = Input.GetAxis("Vertical");
            healthtext.text = health.ToString() + " / " + currenthealth.ToString();
            if (translation > 0)
            {
                translation *= speed;

            }
            else
            {
                translation *= backspeed;
            }
            if(currentstamina<=0)
            {
                translation = 0;
            }
            float rotation = Input.GetAxis("Horizontal") * rotationspeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime; ;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
            if(currenthealth==0)
            {
                anim.SetBool("IsDead", true);
                Invoke("Die", 1f);
                youlostcanvas.SetActive(true);
                text.text = ((2 - spawn.count) * 100).ToString();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("IsShot", true);
            }
            else
            {
                if (translation < 0)
                {
                    
                    anim.SetBool("IsBackWalk", true);
                    anim.SetBool("IsWalking", false);
                    anim.SetBool("IsShot", false);
                }
                if (translation > 0 && currentstamina>0)
                {
                    currentstamina -= 0.1f;
                    anim.SetBool("IsWalking", true);
                    anim.SetBool("IsBackWalk", false);
                    anim.SetBool("IsShot", false);
                }
                if (translation == 0 || currentstamina==0)
                {
                    anim.SetBool("IsShot", false);
                    anim.SetBool("IsWalking", false);
                    anim.SetBool("IsBackWalk", false);
                    if(currentstamina<stamina)
                    {
                        currentstamina = Mathf.Clamp(currentstamina + (staminaregen * Time.deltaTime), 0.0f, stamina);
                }
                }
            }
        }
    private IEnumerator RegainHealthOverTime()
    {
        isstaminaregen = true;
        while (currentstamina < stamina)
        {
            StaminaRegen();
            yield return new WaitForSeconds(1);
        }

        isstaminaregen = false;
    }
    public void StaminaRegen()
    {
        currentstamina += staminaregen;

    }
    void Die()
    {
        youlostcanvas.SetActive(true);
        anim.SetBool("IsDead", true);
        Time.timeScale=0;

    }
}


