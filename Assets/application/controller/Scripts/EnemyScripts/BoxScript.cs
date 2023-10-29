using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour, Interfaces.IStat
{
    private int life;
    private int gold;
    private bool hasGem;

    public void Init(EnemyScriptable pBox)
    {
        life = pBox.stat.life;

        goldRNG(pBox.coinDropChance, pBox.possibleCoinAmount);
    }

    public int TakeDamage(int pDamage)
    {
        life -= pDamage;

        if (life <= 0)
        {
            Die();
            return gold;
        }

        return gold;
    }

    private void Die()
    {
        if (hasGem)
        {
            //drop gem
        }

        // effects.Play
        Destroy(this.gameObject);
    }

    private void goldRNG(int pGoldDropChance, int[] pPossibleGoldAmount)
    {
        var rng = Random.Range(0, 100);

        if (rng <= pGoldDropChance)
            gold = Random.Range(pPossibleGoldAmount[0], pPossibleGoldAmount[1]);
        else
            gold = 0;
    }

    private void gemRNG()
    {

    }
}
