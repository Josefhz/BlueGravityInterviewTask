using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public ItemScriptable item;
    public GUIView view;
    public Image itemIcon;
    public Text itemName;
    public Text itemPrice;
    public Button btnBuy;

    public void setup(ItemScriptable pItem, GUIView pView)
    {
        view = pView;
        item = pItem;
        itemIcon.sprite = pItem.shopItemIcon;
        itemName.text = pItem.Name;
        itemPrice.text = pItem.price.ToString();
    }

    public void BuyItem()
    {
        // return if no money etc

        view.BuyItemFromShop(this.gameObject);
    }
}
