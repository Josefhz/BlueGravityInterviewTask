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
        var npcBrain = app.model.npc.brain;

        if (npcBrain.currentDialogueIndex < npcBrain.possibleDialogues.Length)
        {
            npcBrain.currentDialogueIndex++;

            setupDialogueTab();
        }
    }

    public void setupDialogueTab()
    {
        view.setupDialogueTab(app.model.npc.brain.possibleDialogues[app.model.npc.brain.currentDialogueIndex]);

        if (app.model.npc.brain.currentDialogueIndex == app.model.npc.brain.possibleDialogues.Length - 1)
            setupLastDialogueTab();
    }

    public void setupLastDialogueTab()
    {
        view.setupDialogueTab(app.model.npc.brain.possibleDialogues[app.model.npc.brain.currentDialogueIndex]);
        view.spawnLastAnswers(app.model.npc.brain.sellItemsAnswer, app.model.npc.brain.commandAnwer);
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
