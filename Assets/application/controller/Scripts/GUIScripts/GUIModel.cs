using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIModel : BlueGravityElement
{
    public GameObject dialoguePrefab;
    public GameObject shopDialoguePrefab;
    public GameObject itemPrefab;

    public Button ShopBackButton;

    public List<ItemScriptable> shopItems; // initialized in inspector
    public List<GameObject> currentShopItems;

}
