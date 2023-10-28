using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityView : BlueGravityElement
{
    [HideInInspector] public PlayerView player;
    [HideInInspector] public NPCView npc;
    [HideInInspector] public GUIView gui;


    public void Init()
    {
        player = GetComponent<PlayerView>();
        npc = GetComponent<NPCView>();
        gui = GetComponent<GUIView>();

        player.InitAppInstance(app);
        npc.InitAppInstance(app);
        gui.InitAppInstance(app);
    }
}
