using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //static variables are shared between game objects
    protected bool isGrabbed = false;
    protected bool wasGrabbed = false;
    protected bool destroyed = false;
    protected bool isCollided = false;
    public Transform Target; //set target in script component in unity
    protected float curr_speed;
    protected float speed;
    protected Transform body;
    protected Coroutine damageRoutine = null;

    public virtual void objectIsGrabbed()
    {
        isGrabbed = true;
        wasGrabbed = true;
    }

    public virtual void objectIsReleased()
    {
        isGrabbed = false;
    }

    protected virtual void moveTowardTarget()
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


    protected virtual void destroyEnemy()
    {
        destroyed = true;
        GameObject.Find("Round Tracker").GetComponent<RoundScript>().enemiesLeft--;
        Destroy(gameObject);

    }

    public virtual IEnumerator breakEnemy()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("Round Tracker").GetComponent<RoundScript>().enemiesLeft--;
        Destroy(gameObject);
    }

    protected virtual void checkVelocity()
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


    //if colliding with castle begin damage routine
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            if (damageRoutine == null)
            {
                GameObject c = GameObject.Find("Castle");
                damageRoutine = c.GetComponent<CastleScript>().StartDamage(0); //change inner number for additional damage
                isCollided = true;
            }
        }
    }

    //at end of collission end damage
    protected virtual void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Castle")
        {
            GameObject c = GameObject.Find("Castle");
            c.GetComponent<CastleScript>().EndDamage(damageRoutine);
            damageRoutine = null;
            isCollided = false;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        speed = 5.0f;
        curr_speed = speed;
        body = transform.GetChild(0).GetChild(0).transform;
        Target = GameObject.Find("Tracking Cube").transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        moveTowardTarget();

        checkVelocity();

        if (gameObject.transform.position.y < -100f)
        {
            destroyEnemy();
        }

        if (GameObject.Find("Round Tracker").GetComponent<RoundScript>().roundchange)
        {
            Destroy(gameObject);
        }
    }


}
