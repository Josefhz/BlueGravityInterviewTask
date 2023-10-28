using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIView : BlueGravityElement
{
    public GameObject vendorNpcGUI;
    public GameObject dialogueTab;
    public GameObject shopTab;


    public bool getShopTabActive()
    {
        return vendorNpcGUI.activeInHierarchy;
    }

    public void resetNpcGUI()
    {
        // prob reset dialogue tab dialogue too

        dialogueTab.SetActive(true);
        shopTab.SetActive(false);
        vendorNpcGUI.SetActive(false);
    }

    public void openNpcGUI()
    {
        vendorNpcGUI.SetActive(true);
    }

}
