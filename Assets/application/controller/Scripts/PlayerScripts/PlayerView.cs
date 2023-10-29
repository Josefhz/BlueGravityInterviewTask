using System.Collections;
using System.Collections.Generic;
using DamageNumbersPro;
using UnityEngine;

public class PlayerView : BlueGravityElement
{
    public GameObject playerObject;

    public Transform playerVFXTransform;

    public DamageNumber goldPrefab;
    public DamageNumber loseGoldPrefab;
    public DamageNumber DamagePrefab;

    private Rigidbody2D rb;
    private PlayerModel model;
    private Animator anim;
    private Transform attackTransform;

    public void Start()
    {
        model = app.model.player;
        rb = playerObject.GetComponent<Rigidbody2D>();
        anim = playerObject.GetComponent<Animator>();
        attackTransform = playerObject.GetComponent<PlayerCharacterScript>().attackTransform;
        playerObject.GetComponent<PlayerCharacterScript>().Init(this);
    }

    public void Move()
    {
        rb.velocity = model.direction * model.speed;

        CheckAndUpdateDirection();
        MovementAnimationsManagement();
    }

    public void MovementAnimationsManagement()
    {
        if (model.direction == Vector2.zero)
        {
            PlayerIdle();
            return;
        }

        PlayerRun();
    }

    public void PlayerRun()
    {
        anim.SetBool("isRunning", true);
        model.setPlayerRunning(true);

    }

    public void PlayerIdle()
    {
        model.setPlayerRunning(false);

        anim.SetBool("isRunning", false);
    }

    public void CheckAndUpdateDirection()
    {
        if (model.direction.x == 0) return;
        if (model.direction.x == model.lastFacedDirectionIndex) return;

        var myScale = Mathf.Abs(playerObject.transform.localScale.x);
        myScale = model.lastFacedDirectionIndex == 1 ? -myScale : myScale;

        playerObject.transform.localScale = new Vector3(myScale, Mathf.Abs(myScale), Mathf.Abs(myScale));

        model.UpdateLastFacedDirection();
    }

    public void FrontalAttack()
    {
        if (!model.canAttack) return;

        model.UpdateAttackCooldown();

        RandomAttackAnimation();
        AOEDamage();
    }

    public void AttackCooldown()
    {
        if (model.canAttack) return;

        model.currentAttackCooldown -= Time.deltaTime;

        if (model.currentAttackCooldown <= 0)
            model.canAttack = true;
    }

    public void AOEDamage()
    {
        var enemies = Physics2D.OverlapCircleAll(attackTransform.position, model.brain.attackRange, model.brain.enemyLayer);

        if (enemies.Length == 0) return;

        foreach(Collider2D enemy in enemies)
        {
            DamagePrefab.Spawn(enemy.transform.position, app.model.player.brain.stats.damage);
            app.controller.player.EarnCoins(enemy.GetComponent<Interfaces.IStat>().TakeDamage(app.model.player.brain.stats.damage));
        }
    }

    public void RandomAttackAnimation()
    {
        var rngAttackAnim = Random.Range(0, 3); // 3 = Attack animation amount

        anim.SetTrigger(model.brain.AttackAnimationState[rngAttackAnim]);

        if (rngAttackAnim > 0)
        {
            var vfx = Instantiate(app.model.player.miniSlashAttack, playerVFXTransform);
            Destroy(vfx.gameObject, 3f);
        }
        else
        {
            var vfx = Instantiate(app.model.player.bigSlashAttack, playerVFXTransform);
            Destroy(vfx.gameObject, 3f);
        }
    }

    public void collectGem()
    {
        var gemCollectVFX = Instantiate(app.model.player.onGemCollect, playerObject.transform);
        Destroy(gemCollectVFX.gameObject, 3f);

        app.controller.player.CollectGem();
    }


    public Vector3 getPlayerPosition()
    {
        return playerObject.transform.position;
    }

    public void EarnCoinsVFX(int pAmount)
    {
        goldPrefab.Spawn(playerObject.transform.position, pAmount);
    }

    public void WasteCoinsVFX(int pAmount)
    {
        loseGoldPrefab.Spawn(playerObject.transform.position, pAmount);
    }

    
}
