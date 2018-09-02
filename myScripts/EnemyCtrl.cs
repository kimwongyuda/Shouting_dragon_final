using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour {

    public int HP = 50;

    public float MoveSpeed = 5.0f;

    public int damage = 10;

    private PlayerCtrl playerscript;

    public GameObject Player;

    private float DistanceToPlayer;

    IEnumerator MoveDelay()
    {
        float tmpSpeed = MoveSpeed;

        MoveSpeed = 0;

        yield return new WaitForSeconds(1.0f);

        MoveSpeed = tmpSpeed;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.0f);

        Destroy(gameObject);

        playerscript.DecreseHp(damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag==("Fireball")||collision.gameObject.tag==("FW1"))
        {
            Destroy(collision.gameObject);
            Debug.Log("HIt");
            HP -= 10;
            StartCoroutine(MoveDelay());
            Debug.Log(HP);
            if(HP<=0)
            {
                Destroy(gameObject);
                playerscript.Score += 100;
            }
        }
        if(collision.gameObject.tag == ("Fireball2")||collision.gameObject.tag==("FW2"))
        {
            Destroy(collision.gameObject);
            HP -= 20;
            Debug.Log("Hit");
            StartCoroutine(MoveDelay());
            Debug.Log(HP);
            if (HP <= 0)
            {
                Destroy(gameObject);
                playerscript.Score += 100;
            }
        }
    }
    // Use this for initialization
    void Start () {
        playerscript = GameObject.Find("player").GetComponent<PlayerCtrl>();
        Player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        DistanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if(DistanceToPlayer>2.5f)
        {
            Move();
        }

        else
        {
            StartCoroutine(Attack());
        }
	}

    void Move()
    {
        transform.LookAt(Player.transform.position);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
}
