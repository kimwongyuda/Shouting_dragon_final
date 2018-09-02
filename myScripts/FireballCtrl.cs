﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCtrl : MonoBehaviour {

    public GameObject Player;
    public GameObject Target;
    

    public float MoveSpeed = 10.0f;
    public GameObject Microphone;
    public float Decibel;

    public float sensitivity = 2.0f;
    
    private float TimeLeft = 0.5f;
    private float nextTime = 0.0f;

    public float span = 3.0f;
    public float delta = 0.0f;
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("player");
        Target = GameObject.Find("target");


        transform.LookAt(Target.transform.position);
        // Microphone = GameObject.Find("MicroPhone");

        //Decibel = Microphone.GetComponent<MicrophoneInput>().loudness;
        Decibel = Player.GetComponent<PlayerCtrl>().Decibel;
        MoveSpeed = Decibel * sensitivity;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.tag == "BOMB")
        {
            delta += Time.deltaTime;
            if(delta>span)
            {
                Destroy(this.gameObject);
                delta = 0;
            }
        }
        else
        {
            Move();
        }
	}

    void Move()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Map")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Fireball" || collision.gameObject.tag == "Fireball2" || collision.gameObject.tag == "Player")
        {
            return;
        }
    }
}
