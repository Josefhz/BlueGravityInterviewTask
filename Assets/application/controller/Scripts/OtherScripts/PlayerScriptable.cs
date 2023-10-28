using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Player", order = 0)]
public class PlayerScriptable : ScriptableObject
{
    public float idleSpeed;
    public float cautiousSpeed;
    public float combatSpeed;

    public float attackRange;
    public Stats stats;
    public string[] AttackAnimationState;
    public LayerMask enemyLayer;
}
