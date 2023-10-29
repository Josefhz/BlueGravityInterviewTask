using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityView : BlueGravityElement
{
    [HideInInspector] public PlayerView player;
    [HideInInspector] public NPCView npc;
    [HideInInspector] public GUIView gui;
    [HideInInspector] public EnemyView enemy;


    public void Init()
    {
        player = GetComponent<PlayerView>();
        npc = GetComponent<NPCView>();
        gui = GetComponent<GUIView>();
        enemy = GetComponent<EnemyView>();

        player.InitAppInstance(app);
        npc.InitAppInstance(app);
        gui.InitAppInstance(app);
        enemy.InitAppInstance(app);
    }
}
