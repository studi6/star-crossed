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
    
    public int health;

    private Vector2 workspace;

    [SerializeField]
    private PlayerData playerData;
    private const int MAXHEALTH = 100;
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
        health = MAXHEALTH;
        Debug.Log("Player health initiated"); // console log check
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

    public void TakeDamage(int damage)
    {
        health -= damage; // damage amount depend on Bullet script
        Debug.Log("Player Health: " + health); // console log check

        if (health <= 0) {
            Debug.Log("Player is dead"); // console log check
        } 
    }

    public void ReplenishHealth(int heal)
    {
        if (health < MAXHEALTH) {
            health += heal; // heal amount depend on HealItem script
            Debug.Log("Player Health: " + health); // console log check
        } else {
            Debug.Log("Player at max health"); // console log check
        }
    }
}
