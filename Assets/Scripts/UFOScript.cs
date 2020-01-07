using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOScript : EnemyScript
{
    //static variables are shared between game objects
    protected bool notFalling = true;
    protected Transform Tracking;
    protected float dist;
    protected Coroutine velocityReset;
    protected int counter = 0;
    protected static int UFONumber = 0;

    public override void objectIsReleased()
    {
        //isGrabbed = false;
        StartCoroutine(resetVelocity());
    }

    protected IEnumerator resetVelocity()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1f);
            if (i == 0)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                GetComponent<Rigidbody>().angularVelocity.Set(0, 0, 0);

                body.LookAt(Target);
            }
            else if (i == 1)
            {
                isGrabbed = false;
            }
        }
        if (curr_speed < speed) 
            moveTowardTarget();
    }


    protected void moveTowardTarget()
    {
        if (notFalling)
        {
            // Move our position a step closer to the target.
            float step = curr_speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, Target.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, Target.position) < 5.1f || destroyed)
            {
                curr_speed = 0.2f;
            }
            else curr_speed = speed;
        }

        Physics.IgnoreLayerCollision(9, 9, false);
        Physics.IgnoreLayerCollision(9, 0, false);

    }


    protected override void destroyEnemy()
    {
        UFONumber--;
        base.destroyEnemy();

    }

    public override IEnumerator breakEnemy()
    {
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
        float deathVelocity = 20;
        if ((velocity.x > deathVelocity || velocity.y > deathVelocity || velocity.z > deathVelocity) && wasGrabbed)
        //if(avgVelocity >= 4f && wasGrabbed)
        {
            StartCoroutine(breakEnemy());
        }
    }

    public void allowFall()
    {
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
                damageRoutine = c.GetComponent<CastleScript>().StartDamage(2); //change inner number for additional damage
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

        Tracking = transform;
        body = transform.GetChild(0).GetChild(0).transform;
        body.LookAt(Target);
        Target = GameObject.Find("Tracking Cube").transform;

        dist = Vector3.Distance(body.position, Target.position);
        UFONumber++;

        if (UFONumber <= 3)
        {
            body.GetComponent<AudioSource>().Play();
        }

    }

    void Update()
    {
        base.Update();


        float curr_dist = Vector3.Distance(body.position, Target.position);
        if (dist < curr_dist && !wasGrabbed && notFalling)
        {
            StartCoroutine(resetVelocity());
        }

        //destroys object if they fall through the ground or get too far from the castle
        if (dist > 150)
        {
            destroyEnemy();
        }

        //spins the UFO
        if (isGrabbed == false)
        {
            body.Rotate(0, 45 * Time.deltaTime, 0);
        }



    }

}
