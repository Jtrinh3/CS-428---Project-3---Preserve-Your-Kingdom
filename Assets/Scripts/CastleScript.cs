using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleScript : MonoBehaviour
{
    public Transform Castle;
    private int max_hp, curr_hp, gold, damage;
    private bool destroyed;

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
        curr_hp -= damage + enemyDamage;
        isDestroyed();
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
        destroyed = false;
        max_hp = 100;
        curr_hp = max_hp;
        gold = 0;

        //when difficulty is implemented damage will change accordingly
        damage = 1;
    }
    // Update is called once per frame
    void Update()
    {
       gameObject.GetComponentInChildren<TextMesh>().text = curr_hp.ToString();
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
