using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : BlueGravityElement
{
    public void CheckForPlayerDistance()
    {
        if (Vector3.Distance(app.view.player.getPlayerPosition(),
            app.view.npc.getNPCPosition()) < app.model.npc.getNPCInteractRange())
        {
            app.view.npc.OnPlayerNearby(true);
            return;
        }

        app.view.npc.OnPlayerNearby(false);
    }
}
