using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour
{
    public Transform attackTransform;
    public PlayerView view;

    public void Init(PlayerView pView)
    {
        view = pView;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Gem") return;

        view.collectGem();
        Destroy(collision.gameObject);
    }
}
