using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCModel : BlueGravityElement
{
    [Header("NPC Scriptable")]
    public NPCScriptableObject brain;

    public float getNPCInteractRange()
    {
        return brain.interactRange;
    }


}
