using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Fireball"))
        {
            if (this.gameObject.tag == ("Quit Button"))
            {
                QuitGame();
            }
        }
    }
}
