using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class STTCtrl2 : MonoBehaviour
{

    public string[] keywords = new string[] { "shot", "shotshot", "shot shot", "shotshotshot", "shot shot shot", "main", "pause" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public Text result;
    public Image target;

    protected PhraseRecognizer recognizer;
    public string word;
    public int count;

    public int flag;

    public GameObject Player;
    public GameObject Startplayer;
    // Use this for initialization
    void Start()
    {
        //Player = GameObject.Find("player");
        Startplayer = GameObject.Find("startplayer");
        count = 0;
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            //print(word);
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        //result.text = "You Said: <b>" + word + "</b>";
    }

    // Update is called once per frame
    void Update()
    {
        switch (word)
        {
            case "shot":
                //Player.GetComponent<PlayerCtrl>().Fire();
                Debug.Log("ㄴㅁㄴㅇ");
                Startplayer.GetComponent<startplayerCtrl>().Fire();
                count = 1;
                flag = 1;
                break;
            case "shotshot":
                count = 2;
                flag = 1;
                break;
            case "shot shot":
                count = 2;
                flag = 1;
                break;
            case "shotshotshot":
                count = 3;
                flag = 1;
                break;
            case "shot shot shot":
                count = 3;
                flag = 1;
                break;
            case "main":
                count = 0;
                flag = 2;
                break;
            case "pause":
                count = 0;
                flag = 3;
                break;
        }
        word = "";

    }
}
