using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer _interactSprite;
    private bool IsWithinInteractDistance;

    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _interactSprite.gameObject.SetActive(true);
            IsWithinInteractDistance=true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsWithinInteractDistance && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interact();     
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _interactSprite.gameObject.SetActive(false);
            IsWithinInteractDistance=false;
        }
    }
}
