using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {
    public string level;
	// Use this for initialization
    public void Load()
    {
        SceneManager.LoadScene(level);
    }
}
