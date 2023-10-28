using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIModel : BlueGravityElement
{
    [Header("Shop Scriptable")]
    public ShopScriptable brain;

    [Header("Shop Prefabs")]
    public GameObject dialoguePrefab;
    public GameObject shopDialoguePrefab;
    public GameObject itemPrefab;

    public Button ShopBackButton;

    public List<ItemScriptable> shopItems;
    public List<GameObject> currentShopItems;

    private void Start()
    {
        setupNewShop();
    }

    public void setupNewShop()
    {
        shopItems = new List<ItemScriptable>();

        for (int i = 0; i < brain.shopItemsAmount; i++)
        {
            shopItems.Add(brain.possibleShopItems[Random.Range(0, brain.possibleShopItems.Count)]);
        }
    }

}
