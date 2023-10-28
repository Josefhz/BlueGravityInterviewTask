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

    [Header("States")]
    public PlayerState State;
    public enum PlayerState { Idle, Cautious,  Combat }

    [Header("Booleans")]
    public bool canInteract;
    public bool isInteracting;
    public bool isWalking;
    public bool isRunning;

    [Header("Player equipment")]
    public List<ItemSlot> PlayerEquipment;


    private void Awake()
    {
        State = PlayerState.Idle;
        speed = brain.idleSpeed;
        lastFacedDirectionIndex = 1;
        currentAttackCooldown = 0;
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

    public void EnterIdleState()
    {
        State = PlayerState.Idle;
        speed = brain.idleSpeed;
    }

    public void EnterCautiousState()
    {
        State = PlayerState.Cautious;
        speed = brain.cautiousSpeed;
    }

    public void EnterCombatMode()
    {
        State = PlayerState.Combat;
        speed = brain.combatSpeed;
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
    


}
