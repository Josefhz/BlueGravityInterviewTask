using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIView : BlueGravityElement
{
    public Transform answerContainer;

    public GameObject vendorNpcGUI;
    public GameObject dialogueTab;
    public GameObject shopTab;

    public TextMeshProUGUI npcSpeechText;


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
            answer = Instantiate(app.model.gui.shopDialoguePrefab, answerContainer);
        else
            answer = Instantiate(app.model.gui.dialoguePrefab, answerContainer);

        answer.GetComponent<myDialogueScript>().dialogueText.text = pDialogue.Answer;
       
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
