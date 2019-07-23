using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawn : MonoBehaviour {
    public GameObject enemy;
    public Soldier sol;
    public GameObject wincanvas;
    public GameObject menucanvas;
    public Text text;
    public int count;
    // Use this for initialization
    private void Update()
    {
        count = transform.childCount;
        if (transform.childCount==0)
        {
            Time.timeScale = 0;
            menucanvas.SetActive(false);
            wincanvas.SetActive(true);
            text.text = (2 * 100).ToString();

}
    }
}
