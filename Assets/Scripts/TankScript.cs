using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : EnemyScript
{
    //static variables are shared between game objects
    protected Transform turret;


    public override IEnumerator breakEnemy()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = Target.GetComponent<Renderer>().material; ;
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().material = Target.GetComponent<Renderer>().material; ;
        body.gameObject.GetComponent<AudioSource>().Stop();

        yield return new WaitForSeconds(3f);
        GameObject.Find("Round Tracker").GetComponent<RoundScript>().enemiesLeft--;
        Destroy(gameObject);
    }

    protected override void checkVelocity()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 velocity = rb.velocity;

        float deathVelocity = 10;
        if ((velocity.x > deathVelocity || velocity.y > deathVelocity || velocity.z > deathVelocity) && wasGrabbed)
        //if(avgVelocity >= 4f && wasGrabbed)
        {
            destroyed = true;
            StartCoroutine(breakEnemy());
        }
    }


    // Start is called before the first frame update
    protected override void Start()
    {
        speed = 5.0f;
        curr_speed = speed;
        turret = transform.GetChild(0).GetChild(0).GetChild(0).transform;
        body = transform.GetChild(0).GetChild(0).transform;
        Target = GameObject.Find("Tracking Cube").transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


        //turret facement to target
        turret.LookAt(Target);
        turret.Rotate(new Vector3(-90, 90, 0));
        if (isGrabbed == false)
        {
            body.LookAt(Target.position - transform.position);
            body.Rotate(new Vector3(-90, 90, 0));
        }
    }


}
