using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCModel : BlueGravityElement
{
    [Header("NPC Scriptable")]
    public NPCScriptableObject brain;

    public int gemPrice;
    public int tipPrice;

    private void Start()
    {
        brain.currentDialogueIndex = 0;
    }

    public float getNPCInteractRange()
    {
        return brain.interactRange;
    }


}
