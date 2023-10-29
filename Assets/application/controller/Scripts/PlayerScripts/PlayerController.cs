using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BlueGravityElement
{
    public void MovementInput()
    {
        if (!app) return;

        app.model.player.direction = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
    }

    public void Move()
    {
        if (!app) return;

        app.view.player.Move();
    }

    public void AttackInput()
    {
        if (!app) return;

        app.view.player.AttackCooldown();

        if (Input.GetButton("Fire1"))
        {
            app.view.player.FrontalAttack();
        }
    }

    public void InteractInput()
    {
        if (!app) return;
        if (!app.model.player.canInteract) return;
        if (app.model.player.isInteracting) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            app.controller.gui.InteractWithVendorTab();
        }
    }

    public void EarnCoins(int pAmount)
    {
        if (pAmount == 0) return;

        app.model.player.EarnCoins(pAmount);
        app.view.player.EarnCoinsVFX(pAmount);

        app.model.gui.UpdateShopItemsButtons(app.model.player.coins);
        app.view.gui.UpdatePlayerCoins(app.model.player.coins);
    }

    public void LoseCoins(int pAmount)
    {
        app.model.player.WasteCoins(pAmount);
        app.view.player.WasteCoinsVFX(pAmount);

        app.model.gui.UpdateShopItemsButtons(app.model.player.coins);
        app.view.gui.UpdatePlayerCoins(app.model.player.coins);
    }

}
