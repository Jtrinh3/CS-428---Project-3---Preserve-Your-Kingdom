using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleScript : MonoBehaviour
{
    public Transform Castle;
    private int max_hp, curr_hp, gold;
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

    public void takeDamage(int damage)
    {
        curr_hp -= damage;
        isDestroyed();
    }

    // Start is called before the first frame update
    void Start()
    {
        Castle = GameObject.Find("Castle").transform;
        destroyed = false;
        max_hp = 100;
        curr_hp = max_hp;
        gold = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
