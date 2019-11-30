using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public GameObject spawnMe;
    public Transform transformPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void spawnCopy()
    {
        //removes old if it exist
        //if (oldCopy) Destroy(oldCopy);
        //instantiate a copy
        GameObject newGameObject = Instantiate(spawnMe, transform, true);
        newGameObject.transform.parent = null; //disconnect from the wand to prevent bullet following
        newGameObject.SetActive(true);
    }
}
