using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityController : BlueGravityElement
{
    [HideInInspector] public PlayerController player;
    [HideInInspector] public NPCController npc;
    [HideInInspector] public GUIController gui;

    bool isInitialized;

    public void Init()
    {
        player = GetComponent<PlayerController>();
        npc = GetComponent<NPCController>();
        gui = GetComponent<GUIController>();

        player.InitAppInstance(app);
        npc.InitAppInstance(app);
        gui.InitAppInstance(app);

        isInitialized = true;
    }

    private void Update()
    {
        if (!isInitialized) return;

        PlayerManagement();
        VendorNPCManagement();

    }

    void PlayerManagement()
    {
        player.MovementInput();
        player.Move();

        player.AttackInput();

        player.InteractInput();
    }

    void VendorNPCManagement()
    {
        npc.CheckForPlayerDistance();
    }

}
