using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startplayerCtrl : MonoBehaviour
{

    public Transform Head;

    public GameObject player;
    public Transform FirePos;

    public GameObject Microphone;
    public GameObject stt;
    public GameObject Fireball;
    public GameObject Fireball2;
    public GameObject hpGage;

    public int count;
    public int flag;

    public int HP;
    public float Decibel;
    public int Score;

    public float span;

    public GameObject Dragon;

    private float TimeLeft = 0.5f;
    private float nextTime = 0.0f;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        //머리 돌리면 초점도 같이 돌아감.

        HP = 100;

        Score = 0;
        this.hpGage = GameObject.Find("hpGage");

        Microphone = GameObject.Find("MicroPhone");
        stt = GameObject.Find("STT2");
    }

    // Update is called once per frame
    void Update()
    {
        Decibel = Microphone.GetComponent<MicrophoneInput>().loudness;
        //count = stt.GetComponent<STTCtrl_start>().count;
        //flag = stt.GetComponent<STTCtrl_start>().flag;
        FirePos.transform.position = Head.position + Head.forward * 2;
        FirePos.transform.rotation = Head.rotation;


    }
    public void Fire()
    {

        Debug.Log(Decibel);

        Debug.Log("스타트 발사");
        if (Decibel < 10)
        {
            Vector3 temp = new Vector3(0, 0, 0);
            Instantiate(Fireball, FirePos.position + temp, FirePos.rotation);
        }
        else
        {
            Vector3 temp = new Vector3(0, 0, -10);
            Instantiate(Fireball2, FirePos.position + temp, FirePos.rotation);
        }

    }
    public int GetHP()
    {
        return HP;

    }
}