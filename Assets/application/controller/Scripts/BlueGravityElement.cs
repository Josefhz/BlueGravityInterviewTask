using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityElement : MonoBehaviour
{
    #region Singleton Setup
    [HideInInspector] public BlueGravityApplication app;

    public void InitAppInstance(BlueGravityApplication pApp)
    {
        app = pApp;

        if (app)
            Debug.Log(this.name + " initialized");
    }
    #endregion
}
