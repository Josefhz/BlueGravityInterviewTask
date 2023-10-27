using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityView : BlueGravityElement
{
    [HideInInspector] public PlayerView player;

    public void Init()
    {
        player = GetComponent<PlayerView>();
        player.InitAppInstance(app);
    }
}
