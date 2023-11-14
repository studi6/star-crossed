using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownController : MonoBehaviour {
    
    public float moveSpeed = 1f;

    private Rigidbody2D body;
    private Animator animator;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();  // get a reference to the rigid body component of this object
        animator = GetComponent<Animator>(); // get a reference to the animator controller of this object
    }
    
    public void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
        // only set the animation direction if the player is trying to move
        if (moveInput != Vector2.zero) {
            animator.SetFloat("XInput", moveInput.x);
            animator.SetFloat("YInput", moveInput.y);
        }
    }

    // Update is called once per frame
    void Update() {
        Vector2 moveVector = moveInput * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + moveVector);
    }
}
