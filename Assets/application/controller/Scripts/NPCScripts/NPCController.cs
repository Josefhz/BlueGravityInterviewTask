using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : BlueGravityElement
{
    public void CheckForPlayerDistance()
    {
        var playerDistance = Vector3.Distance(app.view.player.getPlayerPosition(),
            app.view.npc.getNPCPosition());

        if (playerDistance < app.model.npc.getNPCInteractRange()
            && app.model.player.isInteracting == false)
        {
            setPlayerNearby(true);
            return;
        }

        if (playerDistance > app.model.npc.getNPCInteractRange() && app.model.player.isInteracting)
            app.controller.gui.CloseVendorTab();

          setPlayerNearby(false);

    }

    public void setPlayerNearby(bool statement)
    {
        app.view.npc.OnPlayerNearby(statement);
        app.model.player.setPlayerCanInteract(statement);
    }

}
