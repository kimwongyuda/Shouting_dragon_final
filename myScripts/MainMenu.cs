using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    
    public GameObject Mainmenu;
    public GameObject CurDesMenu;
    public GameObject DesMenu1;
    public GameObject DesMenu2;
    public GameObject DesMenu3;
    public GameObject DesMenu4;
    static public int Menucount;

    void Start()
    {
        if (this.gameObject.tag == ("Play Button")|| this.gameObject.tag == ("Description Button") || this.gameObject.tag == ("Quit Button") )
        {
            DesMenu1.SetActive(false);
            DesMenu2.SetActive(false);
            DesMenu3.SetActive(false);
            DesMenu4.SetActive(false);
        }
    }

    public void PlayGame()
    {

        SceneManager.LoadScene("Scene");
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
            Debug.Log(this.gameObject.tag);
            if (this.gameObject.tag == ("Play Button"))
            {
                PlayGame();
                Mainmenu.SetActive(false);
                DesMenu1.SetActive(false);
                DesMenu2.SetActive(false);
                DesMenu3.SetActive(false);
                DesMenu4.SetActive(false);
            }
            else if (this.gameObject.tag == ("Description Button"))
            {
                Debug.Log("DES!");
                Mainmenu.SetActive(false);
                DesMenu1.SetActive(true);
                Debug.Log(DesMenu1.activeSelf);
                Menucount = 1;
                Debug.Log(Menucount);
                CurDesMenu = DesMenu1;
            }
            else if(this.gameObject.tag==("Quit Button"))
            {
                QuitGame();
            }
            else if(this.gameObject.tag==("Right"))
            {
                Debug.Log(Menucount);
                if(Menucount ==1)
                {
                    DesMenu1.SetActive(false);
                    DesMenu2.SetActive(true);
                    Debug.Log("@@@@");
                    CurDesMenu = DesMenu2;
                    Menucount = 2;
                    Debug.Log(Menucount);
                }
                else if(Menucount == 2)
                {
                    DesMenu2.SetActive(false);
                    DesMenu3.SetActive(true);
                    CurDesMenu = DesMenu3;
                    Menucount = 3;
                }
                else if (Menucount == 3)
                {
                    DesMenu3.SetActive(false);
                    DesMenu4.SetActive(true);
                    CurDesMenu = DesMenu4;
                    Menucount = 4;
                }
                else if (Menucount == 4)
                {
                    DesMenu4.SetActive(false);
                    DesMenu1.SetActive(true);
                    CurDesMenu = DesMenu1;
                    Menucount = 1;
                }
            }
            else if(this.gameObject.tag==("Left"))
            {
                Debug.Log(Menucount);
                if (Menucount == 1)
                {
                    DesMenu1.SetActive(false);
                    DesMenu4.SetActive(true);
                    CurDesMenu = DesMenu4;
                    Menucount = 4;
                }
                else if (Menucount == 2)
                {
                    DesMenu2.SetActive(false);
                    DesMenu1.SetActive(true);
                    CurDesMenu = DesMenu1;
                    Menucount = 1;
                }
                else if (Menucount == 3)
                {
                    DesMenu3.SetActive(false);
                    DesMenu2.SetActive(true);
                    CurDesMenu = DesMenu2;
                    Menucount = 2;
                }
                else if (Menucount == 4)
                {
                    DesMenu4.SetActive(false);
                    DesMenu3.SetActive(true);
                    CurDesMenu = DesMenu3;
                    Menucount = 3;
                }
            }
            else if(this.gameObject.tag==("X"))
            {
                if (Menucount == 1)
                {
                    DesMenu1.SetActive(false);
                    Mainmenu.SetActive(true);
                    Menucount = 0;
                }
                else if (Menucount == 2)
                {
                    DesMenu2.SetActive(false);
                    Mainmenu.SetActive(true);
                    Menucount = 0;
                }
                else if (Menucount == 3)
                {
                    DesMenu3.SetActive(false);
                    Mainmenu.SetActive(true);
                    Menucount = 0;
                }
                else if (Menucount == 4)
                {
                    DesMenu4.SetActive(false);
                    Mainmenu.SetActive(true);
                    Menucount = 0;
                }
                CurDesMenu = null;
            }
        }
        Destroy(collision.gameObject);
    }
}
