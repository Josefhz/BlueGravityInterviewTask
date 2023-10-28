using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIView : BlueGravityElement
{
    public Transform answerContainer;
    public Transform shopItemContainer;

    public GameObject vendorNpcGUI;
    public GameObject dialogueTab;
    public GameObject shopTab;

    public TextMeshProUGUI npcSpeechText;

    private void Start()
    {
        app.model.gui.ShopBackButton.onClick.AddListener(OpenDialogueTab);
    }

    public bool getShopTabActive()
    {
        return vendorNpcGUI.activeInHierarchy;
    }

    public void resetNpcGUI()
    {
        // prob reset dialogue tab dialogue too

        dialogueTab.SetActive(true);
        shopTab.SetActive(false);
        vendorNpcGUI.SetActive(false);
    }

    public void openNpcGUI()
    {
        vendorNpcGUI.SetActive(true);
    }

    public void setupDialogueTab(NPCDialogue pDialogue)
    {
        GameObject answer = null;

        clearAnswerContainer();
        npcSpeechText.text = pDialogue.speech;

        if (pDialogue.isShop)
        {
            answer = Instantiate(app.model.gui.shopDialoguePrefab, answerContainer);
            answer.GetComponent<Button>().onClick.AddListener(OnShopAnswerClick);
        }
        else
        {
            answer = Instantiate(app.model.gui.dialoguePrefab, answerContainer);
            answer.GetComponent<Button>().onClick.AddListener(OnDialogueAnswerClick);
        }

        answer.GetComponent<myDialogueScript>().dialogueText.text = pDialogue.Answer;
    }

    public void spawnLastAnswers(string pSellAnswer, string pCommandAnswer)
    {
        var sellAnswer = Instantiate(app.model.gui.shopDialoguePrefab, answerContainer);
        sellAnswer.GetComponent<Button>().onClick.AddListener(OnSellItemsClick);
        sellAnswer.GetComponent<myDialogueScript>().dialogueText.text = pSellAnswer;

        var commandAnswer = Instantiate(app.model.gui.shopDialoguePrefab, answerContainer);
        commandAnswer.GetComponent<Button>().onClick.AddListener(OnCommandClick);
        commandAnswer.GetComponent<myDialogueScript>().dialogueText.text = pCommandAnswer;
    }

    public void OnDialogueAnswerClick()
    {
        app.controller.gui.nextDialogueTab();
    }
    public void OnShopAnswerClick()
    {
        OpenShop();
    }

    public void OnSellItemsClick()
    {
        // sell gems
    }

    public void OnCommandClick()
    {
        // make npc RP and shit
        app.model.gui.setupNewShop();
    }

    public void OpenShop()
    {
        dialogueTab.SetActive(false);
        shopTab.SetActive(true);

        CreateShop();
    }

    public void CreateShop()
    {
        ClearShop();
        InstantiateNewShopItems();
    }

    public void InstantiateNewShopItems()
    {
        app.model.gui.currentShopItems = new List<GameObject>();

        var AllItems = app.model.gui.shopItems;

        foreach (ItemScriptable item in AllItems)
        {
            var instanceItem = Instantiate(app.model.gui.itemPrefab, shopItemContainer);
            instanceItem.GetComponent<ItemScript>().setup(item, this);
            app.model.gui.currentShopItems.Add(instanceItem);
        }
    }

    public void BuyItemFromShop(GameObject item)
    {
        app.model.player.EquipItem(item.GetComponent<ItemScript>().item);

        app.model.gui.currentShopItems.Remove(item);
        app.model.gui.shopItems.Remove(item.GetComponent<ItemScript>().item);
        Destroy(item);

    }


    public void ClearShop()
    {
        foreach (Transform t in shopItemContainer)
            Destroy(t.gameObject);
    }

    public void OpenDialogueTab()
    {
        dialogueTab.SetActive(true);
        shopTab.SetActive(false);
    }

    public void clearAnswerContainer()
    {
        npcSpeechText.text = "";

        foreach(Transform t in answerContainer)
        {
            Destroy(t.gameObject);
        }
    }


}
