using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : BlueGravityElement
{
    [Header("Scriptables")]
    public EnemyScriptable boxScriptable;

    public int TotalBoxQuantity;
    public int CurrentBoxQuantity;

    public List<GameObject> currentBoxList;

    public GameObject boxPrefab;

    public void ClearBoxList()
    {
        currentBoxList.RemoveAll(go => go == null);
        UpdateCurrentBoxQuantity();
    }

    public void AddBoxToList(GameObject pBox)
    {
        currentBoxList.Add(pBox);
        UpdateCurrentBoxQuantity();
    }

    public int getCurrentBoxQuantity()
    {
        return CurrentBoxQuantity;
    }

    public void UpdateCurrentBoxQuantity()
    {
        CurrentBoxQuantity = currentBoxList.Count;
    }
}
