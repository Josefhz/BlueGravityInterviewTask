using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemScriptable : ScriptableObject
{ 
    public string Name;
    public Sprite[] itemGFX;
    public Sprite shopItemIcon;
    public ItemSlot.Item ItemType;
    public int price;
    public bool isPair;

}
