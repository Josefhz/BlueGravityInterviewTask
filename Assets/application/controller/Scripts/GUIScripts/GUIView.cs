using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIView : BlueGravityElement
{
    public Transform answerContainer;

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

    public void OnDialogueAnswerClick()
    {
        app.controller.gui.nextDialogueTab();
    }
    public void OnShopAnswerClick()
    {
        OpenShop();
    }

    public void OpenShop()
    {
        dialogueTab.SetActive(false);
        shopTab.SetActive(true);
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
