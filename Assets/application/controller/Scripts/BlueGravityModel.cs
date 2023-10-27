using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityModel : BlueGravityElement
{
    [HideInInspector] public PlayerModel player;

    public void Init()
    {
        player = GetComponent<PlayerModel>();
        player.InitAppInstance(app);
    }
}
