using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_UI : MonoBehaviour
{
    public GameObject MenuContainer;
    private bool menuIsOpened = false;
    public void ToggleMenu()
    {
        menuIsOpened = !menuIsOpened;
        MenuContainer.SetActive(menuIsOpened);
    }
}
