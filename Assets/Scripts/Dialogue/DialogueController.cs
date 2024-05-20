using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private Image NPCPortraitImage;
    [SerializeField] private float typeSpeed = 10;

    private Queue<string> paragraphs = new Queue<string>();
    private Queue<string> names = new Queue<string>();
    private Queue<Sprite> images = new Queue<Sprite>();

    private bool conversationEnded;

    private string p;
    private string n;
    private Sprite i;


    private Coroutine typeDialogueCoroutine;
    private bool isTyping;

    private const float MAX_TYPE_TIME = 0.1f;

    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        //if nothing in queue
        if (paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                //start convo
                StartConversation(dialogueText);
            }
            else if (conversationEnded && !isTyping)
            {
                //end convo
                EndConversation(dialogueText);
                return;
            }
        }

        //if something in queue
        if (!isTyping)
        {
            p = paragraphs.Dequeue();
            n = names.Dequeue();
            i = images.Dequeue();

            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p, n, i));
        }
        else
        {
            FinishParagraphEarly();
        }

        //update conversationEnded bool
        if (images.Count == 0)
        {
            conversationEnded = true;
        }
    }

    private void StartConversation(DialogueText dialogueText)
    {
        //activate gameObject
        if (!gameObject.activeSelf)
        {
            SystemManager.instance.ChangeGameState(2);
            gameObject.SetActive(true);
        }

        //add dialogue text to the queue
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            names.Enqueue(dialogueText.speakerNames[i]);
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
            images.Enqueue(dialogueText.portraitImages[i]);
        }
    }

    private void EndConversation(DialogueText dialogueText)
    {
        //clear queue

        //return bool to false
        conversationEnded = false;

        //deactivate gameObject
        if (gameObject.activeSelf)
        {
            if (dialogueText.whenFinishBeginCombat)
                SystemManager.instance.ChangeGameState(1);
            else
                SystemManager.instance.ChangeGameState(0);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator TypeDialogueText(string p, string n, Sprite i)
    {
        isTyping = true;

        NPCNameText.text = n;
        NPCPortraitImage.sprite = i;

        int maxVisibleChars = 0;

        NPCDialogueText.text = p;
        NPCDialogueText.maxVisibleCharacters = maxVisibleChars;

        foreach (char c in p.ToCharArray())
        {

            maxVisibleChars++;
            NPCDialogueText.maxVisibleCharacters = maxVisibleChars;

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }

        isTyping = false;
    }

    private void FinishParagraphEarly()
    {
        //stop coroutine
        StopCoroutine(typeDialogueCoroutine);
        NPCDialogueText.maxVisibleCharacters = p.ToCharArray().Length;

        //finish displaying text
        NPCDialogueText.text = p;

        //update isTyping bool
        isTyping = false;
    }

    public void SkipAllDialogue(DialogueText dialogueText)
    {
        // Stop the current dialogue typing coroutine
        if (typeDialogueCoroutine != null)
        {
            StopCoroutine(typeDialogueCoroutine);
            typeDialogueCoroutine = null;
        }

        // Clear all the queues
        paragraphs.Clear();
        names.Clear();
        images.Clear();

        // Set isTyping to false
        isTyping = false;

        EndConversation(dialogueText);
    }
}
