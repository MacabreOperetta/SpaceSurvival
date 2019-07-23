using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public GameObject pausemenu;
    public GameObject mainmenu;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0;
        }
	}
    public void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }
}
