using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCView : BlueGravityElement
{
    public GameObject npcObject;
    private GameObject interactTXT;

    private void Start()
    {
        interactTXT = npcObject.GetComponent<NPCScript>().interactTXT;
    }

    public void OnPlayerNearby(bool statement)
    {
        interactTXT.SetActive(statement);
    }

    public Vector3 getNPCPosition()
    {
        return npcObject.transform.position;
    }
}
