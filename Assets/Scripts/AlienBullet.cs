using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    public Transform Target;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            GameObject c = GameObject.Find("Castle");
            c.GetComponent<CastleScript>().TakeDamage(0); //change inner number for additional damage
            StartCoroutine(destruction());
        }
    }

    private IEnumerator destruction()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        Target = GameObject.Find("Tracking Cube").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float step = 10 * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
        transform.LookAt(Target);

    }
}
