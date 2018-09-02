using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour {

    public Transform Head;

    public Transform FirePos;

    public GameObject Fireball;
    public GameObject Fireball2;

    public GameObject Bomb;
    public GameObject pauseMenu;

    public GameObject hpGage;

    public GameObject player;

    public GameObject Dragon;

    public GameObject Microphone;
    public GameObject stt;

    public GameObject gameover;
    public int HP;
    public int ORHP;
    public float Decibel;

    
    public int count;
    public int flag;

    public int Score;

    public float shot_span = 0.2f;
    public float shot_time;
    public float span;
    public float delta;

    private float TimeLeft = 0.5f;
    private float nextTime = 0.0f;

    
    public bool isPause = false;

    public int remain_fireball;

    public bool isReload = false;
    public bool isShot = true;
    public GameObject reload_bgm;
    public GameObject bgm;
    public GameObject monster_generator;
    public GameObject scoretext;
    // Use this for initialization
    void Start () {
        span = 0.5f;
        delta = 0.0f;
        reload_bgm = GameObject.Find("ReloadBGM");
        bgm = GameObject.Find("BGM");
        
        player = GameObject.Find("Player");
        //머리 돌리면 초점도 같이 돌아감.

        HP = 100;
        ORHP = HP;

        Score = 0;
        this.hpGage = GameObject.Find("hpGage");

        Microphone = GameObject.Find("MicroPhone");
        stt = GameObject.Find("STT");
        pauseMenu = GameObject.Find("PauseMenu");
        monster_generator = GameObject.Find("MonsterGenerator");
        pauseMenu.SetActive(false);

        remain_fireball = 10;
        scoretext = GameObject.Find("Score");
        gameover = GameObject.Find("GameOver");
        gameover.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("count: " + count );
        Debug.Log("flag: " + flag);
        //Debug.Log("decibel: " + Decibel);
        if (HP <= 0)
            HP = 0;
        if(HP ==0)
        {
            //플래그 땜에 어차피 그거임
            gameover.GetComponent<Text>().text = "GameOver\n" + Score.ToString();
            gameover.SetActive(true);
            scoretext.SetActive(false);
            if (flag==2)
            {
                SceneManager.LoadScene("StartScene");
            }
        }
        
        //Decibel = Microphone.GetComponent<MicrophoneInput>().loudness;
        count = stt.GetComponent<STTCtrl>().count;
        flag = stt.GetComponent<STTCtrl>().flag;

        FirePos.transform.position = Head.position + Head.forward * 2;
        FirePos.transform.rotation = Head.rotation;
        
        if(flag == 3)
        {
            //오류!
            //모든 몬스터 움직임 멈추게 하기!
            stop_monster();
            pauseMenu.SetActive(true);
        }

        //플래그땜에 어차피 그거임

        //Item Generator 역할
        //if (Decibel > 0 && flag ==1)
       
        delta = 0.0f;
        
        if (Decibel > 3 && flag == 1)
        {
            //for (int i = 0; i < count; i++)
                //Fire();
            //StartCoroutine(Shot_delay());
            //stt.GetComponent<STTCtrl>().count = 0;
            //stt.GetComponent<STTCtrl>().flag = 0;

        }
        else if (Decibel < 3)
        {
            //stt.GetComponent<STTCtrl>().count = 0;
            //stt.GetComponent<STTCtrl>().flag = 0;
        }

    }
    void stop_monster()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");
        for (int i = 0; i < monsters.Length; i++)
        {
            monsters[i].GetComponent<mosterController>().stop = true;
        }
        monster_generator.GetComponent<monsterGenerator>().isCreate = false;
    }

    public void Fire()
    {
        
        Debug.Log("decibel: "+Decibel);
        if(Decibel >45)
        {
            Vector3 temp = new Vector3(0, 0, 0);
            Instantiate(Bomb, FirePos.position+temp, FirePos.rotation);
            GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i].GetComponent<mosterController>().die();
                this.Score += 100;
            }

        }

        if (Decibel < 20)
        {
            Vector3 temp = new Vector3(0, 0, 0);
                Instantiate(Fireball, FirePos.position+temp, FirePos.rotation);
        }
        else
        {
            Vector3 temp = new Vector3(0, 0, 0);
            Instantiate(Fireball2, FirePos.position+temp, FirePos.rotation);
        }

        remain_fireball--;

        if(remain_fireball==0)
        {
            isShot = false;
            isReload = true;
            StartCoroutine(Reload());

        }
        stt.GetComponent<STTCtrl>().count = 0;
        Microphone.GetComponent<MicrophoneInput>().max_decibel = 0;

    }

    public void Fire(Vector3 fire_position)
    {
        Debug.Log("decibel: " + Decibel);
        if (Decibel > 45)
        {
            Vector3 temp = new Vector3(0, 0, 0);
            Instantiate(Bomb, FirePos.position + temp, FirePos.rotation);
            GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i].GetComponent<mosterController>().die();
                this.Score += 100;
            }

        }

        if (Decibel < 20)
        {
            Vector3 temp = new Vector3(0, 0, 0);

            Instantiate(Fireball, FirePos.position + temp+fire_position, FirePos.rotation);
        }
        else
        {
            Vector3 temp = new Vector3(0, 0, 0);
            Instantiate(Fireball2, FirePos.position + temp+fire_position, FirePos.rotation);
        }

        remain_fireball--;

        if (remain_fireball == 0)
        {
            isShot = false;
            isReload = true;
            StartCoroutine(Reload());

        }
        stt.GetComponent<STTCtrl>().count = 0;
        Microphone.GetComponent<MicrophoneInput>().max_decibel = 0;
    }

    IEnumerator Reload()
    {
        bgm.GetComponent<AudioSource>().mute = true;
        reload_bgm.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.0f);
        remain_fireball = 10;
        isReload = false;
        bgm.GetComponent<AudioSource>().mute = false;
        isShot = true;
    }

    IEnumerator Shot_delay()
    {
        yield return new WaitForSeconds(0.2f);
    }
    public void DecreseHp(int damage)
    {
        Debug.Log("myhit");
        HP -= damage;
        float damage_percent =(float) damage / ORHP ;
        Debug.Log(damage_percent);
        this.hpGage.GetComponent<Image>().fillAmount -= damage_percent;
    }

    public int GetHP()
    {
        return HP;
    }
}
