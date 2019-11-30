using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Highlighting : MonoBehaviour
{
    // Start is called before the first frame update
    public Color highight;
    public Color original;
    public GameObject object_to_change;

    private bool toggleState = false;
    Renderer renderer;

    void Start()
    {
        renderer = object_to_change.GetComponent<Renderer>();
        original = object_to_change.GetComponent<Renderer>().material.GetColor("_Color");
    }

    public void highlightToggle()
    {
        toggleState = !toggleState;
        if (toggleState)
        {
            renderer.material.SetColor("_Color", highight);
        }
        else
        {
            renderer.material.SetColor("_Color", original);
        }
    }
}
