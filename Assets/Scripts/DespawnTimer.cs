using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destruction());
    }

    IEnumerator destruction()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}