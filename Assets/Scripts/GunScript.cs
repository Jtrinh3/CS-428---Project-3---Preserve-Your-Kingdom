using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GunScript : MonoBehaviour
{
    public float velocity;
    public int firerate;
    public GameObject Bullet;
    public GameObject ExitBarrel;

    private bool isGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void gotGrabbed()
    {
        isGrabbed = true;
    }
    void gotUngrabbed()
    {
        isGrabbed = false;
    }

    void repeatShot()
    {
        InvokeRepeating("shoot", 0f, .33f);
    }

    public void shoot()
    {
        GameObject bulletCopy = Instantiate(Bullet, transform);
        bulletCopy.transform.parent = null; //disconnect from the wand to prevent bullet following
        bulletCopy.SetActive(true);
        bulletCopy.GetComponent<Rigidbody>().velocity = transform.forward * velocity; //make go vroom vroom
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
