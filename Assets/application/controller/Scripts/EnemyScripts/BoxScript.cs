using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour, Interfaces.IStat
{
    private int life;
    private int gold;
    private bool hasGem;
    private ParticleSystem onHitVFX;
    private ParticleSystem onDestroyVFX;
    private ParticleSystem gem;

    public void Init(EnemyScriptable pBox)
    {
        life = pBox.stat.life;

        goldRNG(pBox.coinDropChance, pBox.possibleCoinAmount);
        gemRNG(pBox.gemDropChance);

        onHitVFX = pBox.OnHitVFX;
        onDestroyVFX = pBox.OnDestroyVFX;
        gem = pBox.gem;
    }

    public int TakeDamage(int pDamage)
    {
        life -= pDamage;

        TakeHitVFX();

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
            Instantiate(gem, transform.position, Quaternion.identity);
        }

        DieVFX();
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

    private void TakeHitVFX()
    {
        var vfx = Instantiate(onHitVFX, transform.position, Quaternion.identity);
        Destroy(vfx.gameObject, 3f);
    }

    private void DieVFX()
    {
        var vfx = Instantiate(onDestroyVFX, transform.position, Quaternion.identity);
        Destroy(vfx.gameObject, 3f);
    }

    private void gemRNG(int pDropChance)
    {
        var rng = Random.Range(0, 100);

        if (rng <= pDropChance)
            hasGem = true;
        else
            hasGem = false;
    }
}
