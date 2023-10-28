using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityModel : BlueGravityElement
{
    [HideInInspector] public PlayerModel player;
    [HideInInspector] public NPCModel npc;
    [HideInInspector] public GUIModel gui;

    public void Init()
    {
        player = GetComponent<PlayerModel>();
        npc = GetComponent<NPCModel>();
        gui = GetComponent<GUIModel>();

        player.InitAppInstance(app);
        npc.InitAppInstance(app);
        gui.InitAppInstance(app);

    }


}
