using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityApplication : MonoBehaviour
{
    #region Singleton
    public static BlueGravityApplication app;

    private void Awake()
    {
        if (app)
            Destroy(app);

        app = this;
    }
    #endregion

    public BlueGravityController controller;
    public BlueGravityView view;
    public BlueGravityModel model;
}
