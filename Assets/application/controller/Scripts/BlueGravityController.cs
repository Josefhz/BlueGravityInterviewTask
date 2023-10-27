using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityController : BlueGravityElement
{
    [HideInInspector] public PlayerController player;

    public void Init()
    {
        player = GetComponent<PlayerController>();
        player.InitAppInstance(app);
    }
}
