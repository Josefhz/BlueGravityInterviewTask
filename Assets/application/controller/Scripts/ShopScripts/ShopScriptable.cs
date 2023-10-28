using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Shop", order = 3)]
public class ShopScriptable : ScriptableObject
{
    public int shopItemsAmount;
    public List<ItemScriptable> possibleShopItems;
}
