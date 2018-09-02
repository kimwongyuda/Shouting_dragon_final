using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCtrl : MonoBehaviour {

    public Transform Head;

    public Transform FirePos;

    public GameObject Fireball;

	// Use this for initialization
	void Start () {
        FirePos.rotation = Head.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
        {
            Fire();
        }
	}

    void Fire()
    {
        Instantiate(Fireball, FirePos.position, FirePos.rotation);
    }
}
