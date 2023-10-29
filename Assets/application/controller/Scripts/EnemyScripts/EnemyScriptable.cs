using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 4)]
public class EnemyScriptable : ScriptableObject
{
    public Stats stat;
    public int coinDropChance;
    public int gemDropChance;
    public int[] possibleCoinAmount;
    public int[] respawnCooldown;
    public ParticleSystem OnHitVFX;
    public ParticleSystem OnDestroyVFX;
    public ParticleSystem gem;


}
