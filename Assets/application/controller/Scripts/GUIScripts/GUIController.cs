using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : BlueGravityElement
{
    public GUIView view;

    public void Start()
    {
        view = app.view.gui;
    }

    public void InteractWithVendorTab()
    {
        view.openNpcGUI();
        app.model.player.setPlayerIsInteracting(true);
    }

    public void CloseVendorTab()
    {
        if (view.getShopTabActive())
        {
            view.resetNpcGUI();
            app.model.player.setPlayerIsInteracting(false);
        }
    }
}
