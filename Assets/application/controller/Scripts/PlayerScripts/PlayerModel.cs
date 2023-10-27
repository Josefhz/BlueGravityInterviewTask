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

    private void Awake()
    {
        speed = brain.speed;
        lastFacedDirectionIndex = 1;
        currentAttackCooldown = 0;
    }

    public void UpdateLastFacedDirection()
    {
        lastFacedDirectionIndex = direction.x;
    }

    public void UpdateAttackCooldown()
    {
        currentAttackCooldown = brain.stats.attackCooldown;
    }
    


}
