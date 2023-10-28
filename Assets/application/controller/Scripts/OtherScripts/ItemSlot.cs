using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemSlot
{
    public enum Item { Helmet, Chest, Boots, Gloves, Leggins, Shoulders }
    public Item SlotItem;
    public SpriteRenderer[] slots;
}
