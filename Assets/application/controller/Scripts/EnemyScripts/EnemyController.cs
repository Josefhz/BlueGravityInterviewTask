using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BlueGravityElement
{
    public void SpawnBox()
    {
        app.model.enemy.ClearBoxList();

        if (app.model.enemy.currentBoxList.Count >= app.model.enemy.TotalBoxQuantity) return;
        var amountToSpawn = app.model.enemy.TotalBoxQuantity - app.model.enemy.currentBoxList.Count;

        app.view.enemy.SpawnBox(amountToSpawn);
    }
}
