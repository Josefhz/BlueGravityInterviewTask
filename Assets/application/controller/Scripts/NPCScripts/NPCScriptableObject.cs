using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NPC", order = 1)]
public class NPCScriptableObject : ScriptableObject
{
    public float interactRange;

    public NPCDialogue[] possibleDialogues;
    public int currentDialogueIndex;

    public string sellItemsAnswer;
    public string commandAnwer;
}
