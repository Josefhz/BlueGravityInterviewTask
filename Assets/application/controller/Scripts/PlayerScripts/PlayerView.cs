using System.Collections;
using System.Collections.Generic;
using DamageNumbersPro;
using UnityEngine;

public class PlayerView : BlueGravityElement
{
    public GameObject playerObject;
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

        model.setPlayerRunning(model.speed == model.brain.idleSpeed ? false : true);
        model.setPlayerWalking(model.speed == model.brain.idleSpeed ? true : false);

        anim.SetBool("isRunning", model.speed == model.brain.idleSpeed ? false : true);
        anim.SetBool("isWalking", model.speed == model.brain.idleSpeed ? true : false);
    }

    public void PlayerIdle()
    {
        model.setPlayerRunning(false);
        model.setPlayerWalking(false);

        anim.SetBool("isRunning", false);
        anim.SetBool("isWalking", false);
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
