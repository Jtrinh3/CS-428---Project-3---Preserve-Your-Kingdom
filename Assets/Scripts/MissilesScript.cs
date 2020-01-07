using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilesScript: EnemyScript
{
    //static variables are shared between game objects
    protected bool soundPlayed = false;
    protected float dist;
    protected Transform body;
    protected Coroutine velocityReset;
    protected int counter = 0;

    protected override void moveTowardTarget()
    {
        // Move our position a step closer to the target.
        float step = curr_speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);

        curr_speed = speed;


        Physics.IgnoreLayerCollision(9, 9, false);
        Physics.IgnoreLayerCollision(9, 0, false);

    }

    public override IEnumerator breakEnemy()
    {
        soundPlayed = true;
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(body.gameObject);
        yield return new WaitForSeconds(1f);
        destroyEnemy();
    }

    protected override void checkVelocity()
    {

    }


    //if colliding with castle damage it
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            GameObject c = GameObject.Find("Castle");
            c.GetComponent<CastleScript>().TakeDamage(4); //change inner number for additional damage
        }

        //comment out to disable impact destruction
        destroyed = true;
        if (!soundPlayed)    StartCoroutine(breakEnemy());
    }


    protected override void OnCollisionExit(Collision collision)
    {
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        speed = 15.0f;
        curr_speed = speed;
        body = transform.GetChild(0).GetChild(0).transform;
        Target = GameObject.Find("Tracking Cube").transform;

        dist = Vector3.Distance(body.position, Target.position);
    }

    protected override void Update()
    {
        base.Update();

        if (dist > 300)
        {
            destroyEnemy();
        }

        //turret facement to target
        if (wasGrabbed == false)
        {
            transform.LookAt(Target.position - transform.position);
           // transform.Rotate(new Vector3(-90, 0, 0));
        }



    }

}
