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

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, Target.position) < 3f || destroyed)
        {
            curr_speed = 0.2f;
        }
        else curr_speed = speed;


        Physics.IgnoreLayerCollision(9, 9, false);
        Physics.IgnoreLayerCollision(9, 0, false);

    }
    // Update is called once per frame


    private void destroyEnemy()
    {
        GameObject.Find("Round Tracker").GetComponent<RoundScript>().enemiesLeft--;
        Destroy(gameObject);

    }

    public IEnumerator breakEnemy()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = Target.GetComponent<Renderer>().material; ;
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().material = Target.GetComponent<Renderer>().material; ;

        yield return new WaitForSeconds(3f);
        GameObject.Find("Round Tracker").GetComponent<RoundScript>().enemiesLeft--;
        Destroy(gameObject);
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


    //if colliding with castle begin damage routine
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            GameObject c = GameObject.Find("Castle");
            damageRoutine = c.GetComponent<CastleScript>().StartDamage(1); //change inner number for additional damage
            isCollided = true;
        }
    }

    //at end of collission end damage
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Castle")
        {
            GameObject c = GameObject.Find("Castle");
            c.GetComponent<CastleScript>().EndDamage(damageRoutine);
            isCollided = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 8.0f;
        curr_speed = speed;
        turret = transform.GetChild(0).GetChild(0).GetChild(0).transform;
        body = transform.GetChild(0).GetChild(0).transform;
        Target = GameObject.Find("Tracking Cube").transform;

        dist = Vector3.Distance(body.position, Target.position);
    }

    void Update()
    {
        moveTowardTarget();

        checkVelocity();
        float curr_dist = Vector3.Distance(body.position, Target.position);
        if (dist < curr_dist && !wasGrabbed)
        {
            StartCoroutine(resetVelocity());
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

        turret.LookAt(Target);
        turret.Rotate(new Vector3(-90, 90, 0));
        //turret facement to target
        if (isGrabbed == false)
        {
            body.LookAt(Target.position - transform.position);
            body.Rotate(new Vector3(-90, 60, 0));
        }



    }

}
