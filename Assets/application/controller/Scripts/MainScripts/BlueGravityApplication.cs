using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGravityApplication : MonoBehaviour
{
    public BlueGravityModel model;
    public BlueGravityView view;
    public BlueGravityController controller;

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        model.InitAppInstance(this);
        view.InitAppInstance(this);
        controller.InitAppInstance(this);

        model.Init();
        view.Init();
        controller.Init();
    }


}
