using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTankScript : EnemyScript
{
    //static variables are shared between game objects
    protected bool notFalling = true;
    protected float dist;
    protected Transform turret;
    protected Coroutine velocityReset;
    protected int counter = 0;

    public void objectIsGrabbed()
    {
        isGrabbed = true;
        wasGrabbed = true;

    }

    public override void objectIsReleased()
    {
        isGrabbed = false;
        allowFall();
    }

    protected IEnumerator resetVelocity()
    {
        checkVelocity();
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }


    protected override void moveTowardTarget()
    {
        if (notFalling)
        {
            base.moveTowardTarget();
        }

        Physics.IgnoreLayerCollision(9, 9, false);
        Physics.IgnoreLayerCollision(9, 0, false);

    }

    public override IEnumerator breakEnemy()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = Target.GetComponent<Renderer>().material; ;
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().material = Target.GetComponent<Renderer>().material; ;

        yield return new WaitForSeconds(3f);
        if (!destroyed) 
            destroyEnemy();
    }

    protected override void checkVelocity()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 velocity = rb.velocity;

        float avgVelocity = (velocity.x + velocity.y + velocity.z) / 3;
        float deathVelocity = 70;
        if ((velocity.x > deathVelocity || velocity.y > deathVelocity || velocity.z > deathVelocity) && wasGrabbed)
        //if(avgVelocity >= 4f && wasGrabbed)
        {
            destroyed = true;
            StartCoroutine(breakEnemy());
        }
    }

    public void allowFall()
    {
        if (notFalling)
        {
            body.gameObject.GetComponent<AudioSource>().Play();
            transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
        if (!GameObject.Find("Round Tracker").GetComponent<RoundScript>().space)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            notFalling = false;
        }
    }

    //if colliding with castle begin damage routine
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            if (damageRoutine == null)
            {
                GameObject c = GameObject.Find("Castle");
                damageRoutine = c.GetComponent<CastleScript>().StartDamage(1); //change inner number for additional damage
                isCollided = true;
            }
        }
        if (collision.gameObject.tag == "Floor")
        {

            Physics.IgnoreCollision(collision.collider, gameObject.GetComponentInChildren<Collider>());

        }
    }


    // Start is called before the first frame update
    protected override void Start()
    {
        speed = 8.0f;
        curr_speed = speed;
        body = transform.GetChild(0).GetChild(0).transform;
        Target = GameObject.Find("Tracking Cube").transform;

        turret = transform.GetChild(0).GetChild(0).GetChild(0).transform;
        dist = Vector3.Distance(body.position, Target.position);
    }

    protected override void Update()
    {
        base.Update();

        //destroys object if they fall through the ground or get too far from the castle
        if (dist > 150)
        {
            destroyEnemy();
        }

        //turret facement to target
        turret.LookAt(Target);
        turret.Rotate(new Vector3(-90, 90, 0));
        if (wasGrabbed == false)
        {
            body.LookAt(Target.position - transform.position);
            body.Rotate(new Vector3(-90, 60, 0));
        }



    }

}
