using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : BlueGravityElement
{
    [HideInInspector] public GUIView view;

    public void Start()
    {
        view = app.view.gui;
    }

    public void InteractWithVendorTab()
    {
        view.openNpcGUI();
        app.model.player.setPlayerIsInteracting(true);

        setupDialogueTab();
    }

    public void nextDialogueTab()
    {
        if (app.model.npc.brain.currentDialogueIndex < app.model.npc.brain.possibleDialogues.Length)
            app.model.npc.brain.currentDialogueIndex++;

        setupDialogueTab();
    }

    public void setupDialogueTab()
    {
        view.setupDialogueTab(app.model.npc.brain.possibleDialogues[app.model.npc.brain.currentDialogueIndex]);
    }

    public void CloseVendorTab()
    {
        if (view.getShopTabActive())
        {
            view.resetNpcGUI();
            app.model.player.setPlayerIsInteracting(false);
        }
    }
}
