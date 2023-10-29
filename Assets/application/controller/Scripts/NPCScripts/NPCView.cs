using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCView : BlueGravityElement
{
    public GameObject npcObject;
    private GameObject interactTXT;

    public Transform defaultLocation;
    public Transform swapShopLocation;

    private void Start()
    {
        defaultLocation = npcObject.transform;
        interactTXT = npcObject.GetComponent<NPCScript>().interactTXT;
    }

    public void OnPlayerNearby(bool statement)
    {
        interactTXT.SetActive(statement);
    }

    public Vector3 getNPCPosition()
    {
        return npcObject.transform.position;
    }

    public void SetupNewShopRP()
    {
        Debug.Log("starting rp");
        StartCoroutine(NewShopRP());
    }

    IEnumerator NewShopRP()
    {
        npcObject.GetComponent<Animator>().SetBool("isWalking", true);

        Vector3 swapShopPosition = swapShopLocation.transform.position;
        Vector3 defaultPosition = defaultLocation.transform.position;
        float movementSpeed = 3.0f;

        var npcScale = Mathf.Abs(npcObject.transform.localScale.x);

        npcObject.transform.localScale = new Vector3(npcScale, npcScale, npcScale);

        while (Vector3.Distance(npcObject.transform.position, swapShopPosition) > 0.01f)
        {
            Vector3 npcMovDir = (swapShopPosition - npcObject.transform.position).normalized;
            npcObject.transform.position += npcMovDir * movementSpeed * Time.deltaTime;
            yield return null; 
        }

        yield return new WaitForSeconds(2f);
        app.model.gui.setupNewShop();

        npcObject.transform.localScale = new Vector3(-npcScale, npcScale, npcScale);

        while (Vector3.Distance(npcObject.transform.position, defaultPosition) > 0.01f)
        {
            Vector3 npcMovDir = (defaultPosition - npcObject.transform.position).normalized;
            npcObject.transform.position += npcMovDir * movementSpeed * Time.deltaTime;
            yield return null; 
        }

        npcObject.GetComponent<Animator>().SetBool("isWalking", false);
    }
}
