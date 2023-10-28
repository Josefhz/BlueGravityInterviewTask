using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityView : BlueGravityElement
{
    [HideInInspector] public PlayerView player;
    [HideInInspector] public NPCView npc;


    public void Init()
    {
        player = GetComponent<PlayerView>();
        npc = GetComponent<NPCView>();

        player.InitAppInstance(app);
        npc.InitAppInstance(app);
    }
}
