using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeCtrl : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject monster_generator;
    // Use this for initialization
    void Start()
    {

        pauseMenu = GameObject.Find("PauseMenu");
        monster_generator = GameObject.Find("MonsterGenerator");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Fireball")|| collision.gameObject.tag == ("Fireball2"))
        {
            if (this.gameObject.tag == ("Resume Button"))
            {
                pauseMenu.SetActive(false);
                GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");
                for (int i = 0; i < monsters.Length; i++)
                {
                    monsters[i].GetComponent<mosterController>().stop = false;
                }
                monster_generator.GetComponent<monsterGenerator>().isCreate = true;
                Debug.Log("ResumeHit!");
            }
        }
    }
}