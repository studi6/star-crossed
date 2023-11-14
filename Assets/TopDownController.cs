using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownController : MonoBehaviour {
    
    private float moveSpeed = 3f;  
    private Rigidbody2D body;
    private Animator animator;
    private Vector2 moveInput;

    // Purpose: Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();  // get a reference to the rigid body component of this object
        animator = GetComponent<Animator>(); //         ''           animator controller         ''
    }

    // Purpose: OnMove is called each time a player control key is pressed (look at Assets/Player.inputactions
    // for list of all key mappings). For movement, these are the arrow and WASD keys.
    // More about Unity's "new" (it's really been around for a while now) input system here: 
    // https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/
    public void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
        // only set the animation direction if the player is trying to move
        if (moveInput != Vector2.zero) {
            animator.SetFloat("XInput", moveInput.x);
            animator.SetFloat("YInput", moveInput.y);
        }
    }

    // Purpose: Update is called once per frame
    void Update() {
        if (moveInput != Vector2.zero) {
            Vector2 moveVector = moveInput * moveSpeed * Time.fixedDeltaTime;
            body.MovePosition(body.position + moveVector);
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }
    }
}
