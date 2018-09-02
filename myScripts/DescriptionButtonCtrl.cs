using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionButtonCtrl : MonoBehaviour {


    public GameObject Mainmenu;
    public GameObject DesMenu1 = GameObject.Find("DesMenu1");
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Fireball"))
        {
            if (this.gameObject.tag == ("Description Button"))
            {
                Debug.Log("DES!");
                Mainmenu.SetActive(false);
                DesMenu1.SetActive(true);
            }
        }
    }
}

