using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    //static variables are shared between game objects
    private bool isGrabbed = false;
    public Transform Target; //set target in script component in unity
    private float curr_speed;
    private float speed;
    private Transform turret;
    private Transform body;

    public void objectIsGrabbed()
    {
        isGrabbed = true;
    }

    public void objectIsReleased()
    {
        isGrabbed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        curr_speed = speed;
        turret = transform.GetChild(0).GetChild(1).transform;
        body = transform.GetChild(0).GetChild(0).transform;
    }

    private void moveTowardTarget()
    {
        // Move our position a step closer to the target.
        float step = curr_speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, Target.position) < 10.0f)
        {
            curr_speed = 0;
        }
        else speed = curr_speed;
    }
    // Update is called once per frame
    void Update()
    {
        moveTowardTarget();

        turret.LookAt(Target.position - transform.position);
        turret.Rotate(new Vector3(-90, 90, 0));
        //turret facement to target
        if (isGrabbed == false)
        {
            body.LookAt(Target.position - transform.position);
            body.Rotate(new Vector3(-90, 90, 0));
        }
    }
}
