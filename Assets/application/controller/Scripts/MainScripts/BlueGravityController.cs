using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityController : BlueGravityElement
{
    [HideInInspector] public PlayerController player;
    [HideInInspector] public NPCController npc;

    bool isInitialized;

    public void Init()
    {
        player = GetComponent<PlayerController>();
        npc = GetComponent<NPCController>();

        player.InitAppInstance(app);
        npc.InitAppInstance(app);

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
    }

    void VendorNPCManagement()
    {
        npc.CheckForPlayerDistance();
    }

}
