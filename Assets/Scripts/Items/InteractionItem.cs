using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    [SerializeField]
    private Sprite brick_normal;

    [SerializeField]
    private Sprite brick_selected;
    [SerializeField]
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render.sprite = brick_normal;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            render.sprite = brick_selected;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            render.sprite = brick_normal;
        }
    }
}
