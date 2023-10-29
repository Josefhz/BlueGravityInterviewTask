using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : BlueGravityElement
{
    public Transform[] BoxSpawners;

    public void SpawnBox(int pAmountToSpawn)
    {
        for (int i = 0; i < pAmountToSpawn; i++)
        {
            var rngSpawner = Random.Range(0, BoxSpawners.Length);

            if (isSpawnerBusy(BoxSpawners[rngSpawner]))
                continue;
            else
            {
                var box = Instantiate(app.model.enemy.boxPrefab, BoxSpawners[rngSpawner]);
                box.GetComponent<BoxScript>().Init(app.model.enemy.boxScriptable);
                app.model.enemy.AddBoxToList(box);
            }
            
        }
    }

    public bool isSpawnerBusy(Transform pSpawner)
    {
        if (pSpawner.childCount > 0)
            return true;
        else
            return false;
    }
}
