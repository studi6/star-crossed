using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : NPC, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueController dialogueController;
    public override void Interact()
    {
        Talk(dialogueText);
    }

    // public void EndConversation(){
    //     dialogueController.EndConversation();
    // }

    public void Talk(DialogueText dialogueText)
    {
        //start conversation
        dialogueController.DisplayNextParagraph(dialogueText);
    }
}
