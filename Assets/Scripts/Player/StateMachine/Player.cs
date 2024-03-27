using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;

    [SerializeField]
    private PlayerData playerData;
    private void Awake() {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "isIdle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "isMove");
    }

    private void Start() {
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Rigidbody = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
    }

    private void Update() {
        CurrentVelocity = Rigidbody.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate() {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity, bool updateDirection = true) {
        workspace.Set(velocity, CurrentVelocity.y);
        if (updateDirection) {
            Animator.SetFloat("XInput", velocity);
        }
        Rigidbody.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity, bool updateDirection = true) {
        workspace.Set(CurrentVelocity.x, velocity);
        if (updateDirection) {
            Animator.SetFloat("YInput", velocity);
        }
        Rigidbody.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "Interaction" && Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Player interacted");
        }
    }
}
