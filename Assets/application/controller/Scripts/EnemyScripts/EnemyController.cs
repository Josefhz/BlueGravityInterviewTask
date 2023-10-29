using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BlueGravityElement
{
    public void SpawnBox()
    {
        app.model.enemy.ClearBoxList();

        if (app.model.enemy.CurrentBoxQuantity >= app.model.enemy.TotalBoxQuantity) return;

        app.view.enemy.SpawnBox();
    }
}
