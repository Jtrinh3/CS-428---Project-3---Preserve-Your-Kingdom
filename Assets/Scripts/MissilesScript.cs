using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilesScript: MonoBehaviour
{
    //static variables are shared between game objects
    private bool isGrabbed = false;
    private bool wasGrabbed = false;
    private bool destroyed = false;
    private bool isCollided = false;
    private bool soundPlayed = false;
    public Transform Target; //set target in script component in unity
    private float dist;
    private float curr_speed;
    private float speed;
    private Transform turret;
    private Transform body;
    private Coroutine damageRoutine, velocityReset;
    private int counter = 0;

    public void objectIsGrabbed()
    {
        isGrabbed = true;
        wasGrabbed = true;
    }

    public void objectIsReleased()
    {
        isGrabbed = false;
        StartCoroutine(resetVelocity());
    }

    private IEnumerator resetVelocity()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }


    private void moveTowardTarget()
    {
        // Move our position a step closer to the target.
        float step = curr_speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);

        curr_speed = speed;


        Physics.IgnoreLayerCollision(9, 9, false);
        Physics.IgnoreLayerCollision(9, 0, false);

    }


    private void destroyEnemy()
    {
        GameObject.Find("Round Tracker").GetComponent<RoundScript>().enemiesLeft--;
        Destroy(gameObject);

    }

    public IEnumerator breakEnemy()
    {
        soundPlayed = true;
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(body.gameObject);
        yield return new WaitForSeconds(1f);
        destroyEnemy();
    }

    void checkVelocity()
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


    //if colliding with castle damage it
    private void OnCollisionEnter(Collision collision)
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


    private void OnCollisionExit(Collision collision)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 15.0f;
        curr_speed = speed;
        body = transform.GetChild(0).GetChild(0).transform;
        Target = GameObject.Find("Tracking Cube").transform;

        dist = Vector3.Distance(body.position, Target.position);
    }

    void Update()
    {
        moveTowardTarget();
        if (!destroyed)
        {
            float curr_dist = Vector3.Distance(body.position, Target.position);
            if (dist < curr_dist && !wasGrabbed)
            {
                StartCoroutine(resetVelocity());
            }
        }

        //destroys object if they fall through the ground or get too far from the castle
        if (gameObject.transform.position.y < -100f)
        {
            destroyEnemy();
        }
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
