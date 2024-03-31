using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D body;
    private Animator animator;
    private Vector2 moveInput;
    private float currentSpeed = 0;
    private float targetSpeed = 0;

    private bool isDashing = false;
    private bool canDash = true;
    private Coroutine dashCoroutine;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 6f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 0.5f;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip dashSound;
    [SerializeField] private AudioClip[] footstepSounds;
    private AudioSource audioSource;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("XInput", moveInput.x);
            animator.SetFloat("YInput", moveInput.y);
            animator.SetInteger("state", 1);
        }
    }


    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;
        animator.SetInteger("state", 2);
        body.velocity = new Vector2(moveInput.x, moveInput.y) * dashSpeed;
        audioSource.PlayOneShot(dashSound);
        yield return new WaitForSeconds(dashDuration);
        body.velocity = Vector2.zero;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void Update()
    {
        if (isDashing)
            return;
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(DashCoroutine());
        }

        if (moveInput != Vector2.zero)
        {
            targetSpeed = moveSpeed;
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.fixedDeltaTime);
            Vector2 moveVector = moveInput * currentSpeed * Time.fixedDeltaTime;
            body.MovePosition(body.position + moveVector);
            if (!audioSource.isPlaying)
            {
                PlayRandomFootstepSound();
            }
        }
        else
        {
            targetSpeed=0;
            animator.SetInteger("state", 0);
            audioSource.Stop();
        }
    }

    private void PlayRandomFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            audioSource.PlayOneShot(footstepSounds[randomIndex]);
        }
    }
}
