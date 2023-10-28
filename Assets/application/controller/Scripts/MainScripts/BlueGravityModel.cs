using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityModel : BlueGravityElement
{
    [HideInInspector] public PlayerModel player;
    [HideInInspector] public NPCModel npc;

    public void Init()
    {
        player = GetComponent<PlayerModel>();
        npc = GetComponent<NPCModel>();

        player.InitAppInstance(app);
        npc.InitAppInstance(app);
    }


}
