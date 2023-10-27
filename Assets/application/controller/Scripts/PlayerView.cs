using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : BlueGravityElement
{
    public GameObject playerObject;

    private Rigidbody2D rb;
    private PlayerModel model;

    public void Start()
    {
        rb = playerObject.GetComponent<Rigidbody2D>();
        model = app.model.player;
    }

    public void Move()
    {
        rb.velocity = model.direction * model.speed;

        CheckAndUpdateDirection();
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
}
