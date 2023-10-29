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
        UpdateShopItemsButtons(app.model.player.coins);
        app.view.gui.UpdatePlayerCoins(app.model.player.coins);
    }

    public void setupNewShop()
    {
        shopItems = new List<ItemScriptable>();

        for (int i = 0; i < brain.shopItemsAmount; i++)
        {
            shopItems.Add(brain.possibleShopItems[Random.Range(0, brain.possibleShopItems.Count)]);
        }
    }

    public void UpdateShopItemsButtons(int playerCoins)
    {
        foreach(GameObject item in currentShopItems)
        {
            var itemScript = item.GetComponent<ItemScript>();

            if (itemScript.item.price <= playerCoins)
            {
                itemScript.btnBuy.interactable = true;
            }
            else
                itemScript.btnBuy.interactable = false;
        }
    }

}
