using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour {
    public GameObject menupanel;
    public GameObject loadingpanel;
    public string level;
    // Update is called once per frame
    private void Start()
    {
        menupanel.SetActive(true);
        loadingpanel.SetActive(false);
    }
    public void Load () {
        menupanel.SetActive(false);
        loadingpanel.SetActive(true);
        Invoke("LoadScene", 5f);
	}
    public void LoadScene()
    {
        SceneManager.LoadScene(level);
    }
}
