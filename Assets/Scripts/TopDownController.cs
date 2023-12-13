using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownController : MonoBehaviour {
    
    private float moveSpeed = 3f;  
    private float currentSpeed = 0;
    private float targetSpeed = 0;
    private Rigidbody2D body;
    private Animator animator;
    private Vector2 moveInput;
    private ProjectileAttack ra;
    private string enemyTag = "Enemy";

    [SerializeField] private GameObject projectile;

    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 6f;
    [SerializeField] float dashDuration = 0.2f;
    [SerializeField] float dashCooldown = 0.5f;

    [SerializeField] float attackCooldown = 0.5f;
    bool isDashing;
    bool canDash;
    bool canAttack;

    // Purpose: Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();  // get a reference to the rigid body component of this object
        animator = GetComponent<Animator>(); //         ''           animator controller         ''
        ra = GetComponent<ProjectileAttack>();
        canDash = true;
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
        if (isDashing)
        {
            return;
        }
        if (Input.GetKey("space") && canDash)
        {
            StartCoroutine(Dash());
        }
        if (Input.GetKey("mouse 0") && canAttack  && isDashing == false)
        {
            StartCoroutine(Attack());
        }
        if (moveInput != Vector2.zero) {
            targetSpeed = moveSpeed;
            animator.SetBool("isWalking", true);
            // The following line performs some basic smoothening on our values to create more
            // fluid animations - they are still janky but we'll optimize them later
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.fixedDeltaTime);
            Vector2 moveVector = moveInput * currentSpeed * Time.fixedDeltaTime;
            body.MovePosition(body.position + moveVector);
        } else {
            targetSpeed = 0;
            animator.SetBool("isWalking", false);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        animator.SetBool("isDashing", true);
        isDashing = true;
        body.velocity = new Vector2(animator.GetFloat("XInput"),animator.GetFloat("YInput")) * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        body.velocity = Vector2.zero;
        animator.SetBool("isDashing", false);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private IEnumerator Attack()
    {
        canAttack = false;
        ra.RangedAttack(projectile, transform, Camera.main.ScreenToWorldPoint(Input.mousePosition), 10f, enemyTag);
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
