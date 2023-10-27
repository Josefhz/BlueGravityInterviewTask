using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Player", order = 0)]
public class PlayerScriptable : ScriptableObject
{
    public float speed;
    public float sprintSpeed;
    public float attackRange;
    public Stats stats;
    public string[] AttackAnimationState;
    public LayerMask enemyLayer;
}
