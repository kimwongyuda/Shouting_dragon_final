using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

    public GameObject ScoreText;

    public PlayerCtrl playerCtrl;

    public GameObject remain_fireball;

    public GameObject intro_bgm;
    public GameObject bgm;

    // Use this for initialization
    void Start () {
       
        this.ScoreText = GameObject.Find("Score");
        
        playerCtrl = GameObject.Find("player").GetComponent<PlayerCtrl>();

        this.remain_fireball = GameObject.Find("Remain_Fireball");

	}
	
	// Update is called once per frame
	void Update () {
        this.ScoreText.GetComponent<Text>().text = playerCtrl.Score.ToString();
        this.remain_fireball.GetComponent<Text>().text = playerCtrl.remain_fireball.ToString() + "/10";
	}
}
