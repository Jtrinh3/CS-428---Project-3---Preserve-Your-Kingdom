using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleScript : MonoBehaviour
{
    public Transform Castle;
    private int max_hp, curr_hp, gold;
    private bool destroyed;
    public Transform Player;
    private GameObject CastleStats;

    //easy = 1  med = 2 hard = 3
    public int difficulty = 0;

    public void SetDifficulty(int d)
    {
        difficulty = d;
    }
    public int get_max_hp()
    {
        return max_hp;
    }
    public int get_curr_hp()
    {
        return curr_hp;
    }
    public int get_gold()
    {
        return gold;
    }

    public void gain_gold(int gainz)
    {
        gold += gainz;
    }

    public bool isDestroyed()
    {
        if (curr_hp <= 0) destroyed = true;
        return destroyed;
    }

    //damages the castle
    //enemy damage is the modifier (more difficult enemy gives more damage)
    public void TakeDamage(int enemyDamage)
    {
        curr_hp -= difficulty + enemyDamage;
        if(isDestroyed())
        {
            curr_hp = 0;
            //Destroy(gameObject);
        }
    }

    //routine for damage
    IEnumerator Damaged(int enemyDamage)
    {
        while (true)
        {
            TakeDamage(enemyDamage);
            yield return new WaitForSeconds(1f);
        }

    }

    //starts damage coroutine
    //returns routine that is started
    public Coroutine StartDamage(int enemyDamage)
    {
        return StartCoroutine(Damaged(enemyDamage));
    }


    //ends damage coroutine
    //takes routine to end
    public void EndDamage(Coroutine routine)
    {
        StopCoroutine(routine);
    }

    // Start is called before the first frame update
    void Start()
    {
        Castle = GameObject.Find("Castle").transform;
        CastleStats = GameObject.Find("Castle Stats");
        CastleStats.SetActive(false);
        destroyed = false;

        max_hp = 100;
        curr_hp = max_hp;
        gold = 0;

        //easy = 1  med = 2 hard = 3
        difficulty = 1;
    }
    // Update is called once per frame
    void Update()
    {
        CastleStats.transform.GetChild(0).GetComponent<TextMesh>().text = curr_hp.ToString();
        Transform TextHolder = gameObject.transform.GetChild(0).transform;
        
        TextHolder.LookAt(Player);
        TextHolder.Rotate(new Vector3(0f, 180f, 0f));
    }





 /*   private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            InvokeRepeating("takeDamage", 1.0f, 1.0f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine("takeDamage");
            InvokeRepeating("takeDamage", 1.0f, 1.0f);
        }
    }*/

}
