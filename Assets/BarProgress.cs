using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarProgress : MonoBehaviour {
    float staminaprog;
    float healthprog;
    public Player soldier;
    public Image healthslider;
    public Image staminaslider;
	// Use this for initialization
	void Start () {
        staminaprog = soldier.currentstamina;
        healthprog = soldier.currenthealth;
	}
	
	// Update is called once per frame
	void Update () {

        staminaprog = soldier.currentstamina;
        staminaslider.fillAmount = staminaprog / 100;

        healthprog = soldier.currenthealth;
        healthslider.fillAmount = healthprog / 100;

    }
}
