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

        if (Input.GetButtonDown("fire0")) ;
    }

}
