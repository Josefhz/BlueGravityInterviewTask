using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlueGravityController : BlueGravityElement
{
    [HideInInspector] public PlayerController player;
    [HideInInspector] public NPCController npc;
    [HideInInspector] public GUIController gui;
    [HideInInspector] public EnemyController enemy;

    bool isInitialized;

    public void Init()
    {
        player = GetComponent<PlayerController>();
        npc = GetComponent<NPCController>();
        gui = GetComponent<GUIController>();
        enemy = GetComponent<EnemyController>();

        player.InitAppInstance(app);
        npc.InitAppInstance(app);
        gui.InitAppInstance(app);
        enemy.InitAppInstance(app);

        isInitialized = true;
    }

    private void Update()
    {
        if (!isInitialized) return;

        PlayerManagement();
        VendorNPCManagement();
        BoxSpawnRepeat();
    }

    void PlayerManagement()
    {
        player.MovementInput();
        player.Move();

        player.InteractInput();

        if (EventSystem.current.IsPointerOverGameObject()) return;

        player.AttackInput();

    }

    void VendorNPCManagement()
    {
        npc.CheckForPlayerDistance();
    }

    void BoxSpawnRepeat()
    {
        enemy.SpawnBox();
    }

}
