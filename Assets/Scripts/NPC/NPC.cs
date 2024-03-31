using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer _interactSprite;
    private bool IsWithinInteractDistance = false;

    public abstract void Interact();

    private void Update(){
        if (IsWithinInteractDistance&& SystemManager.instance.GameState==0 && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("interacted with npc");
            Interact();     
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && SystemManager.instance.GameState==0)
        {
            Debug.Log("within interact distance");
            _interactSprite.gameObject.SetActive(true);
            IsWithinInteractDistance=true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("not within interact distance");
            _interactSprite.gameObject.SetActive(false);
            IsWithinInteractDistance=false;
            // EndConversation();
        }
    }
}
