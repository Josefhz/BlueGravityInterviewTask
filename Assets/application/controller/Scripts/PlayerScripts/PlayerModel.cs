using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel : BlueGravityElement
{
    [Header("Scriptable Object")]
    public PlayerScriptable brain;

    [Header("Last faced direction")]
    public float lastFacedDirectionIndex;

    [Header("Properties")]
    public Vector2 direction;

    public float speed;
    public float currentAttackCooldown;
    public bool canAttack;

    [Header("Booleans")]
    public bool canInteract;
    public bool isInteracting;
    public bool isWalking;
    public bool isRunning;

    [Header("Player equipment")]
    public List<ItemSlot> PlayerEquipment;

    [Header("Player Money")]
    public int coins;

    private void Awake()
    {
        speed = brain.idleSpeed;
        lastFacedDirectionIndex = 1;
        currentAttackCooldown = 0;
        coins = 100;
        canAttack = true;
    }

    public void UpdateLastFacedDirection()
    {
        lastFacedDirectionIndex = direction.x;
    }

    public void UpdateAttackCooldown()
    {
        canAttack = false;
        currentAttackCooldown = brain.stats.attackCooldown;
    }

    public void setPlayerRunning(bool statement)
    {
        isRunning = statement;
    }

    public void setPlayerWalking(bool statement)
    {
        isWalking = statement;
    }

    public void setPlayerCanInteract(bool statement)
    {
        canInteract = statement;
    }

    public void setPlayerIsInteracting(bool statement)
    {
        isInteracting = statement;
    }

    public void EquipItem(ItemScriptable pItem)
    {
        foreach(ItemSlot slot in PlayerEquipment)
        {
            if (pItem.ItemType == slot.SlotItem)
            {
                for (int i = 0; i < slot.slots.Length; i++)
                {
                    slot.slots[i].sprite = pItem.itemGFX[i];
                }
            }
        }

    }

    public void EarnCoins(int pAmount)
    {
        coins += pAmount;

    }

    public void WasteCoins(int pAmount)
    {
        coins -= pAmount;
    }
    


}
