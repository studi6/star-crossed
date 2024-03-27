using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState {
    protected Player player;
    protected PlayerStateMachine playerStateMachine;
    protected PlayerData playerData;

    protected float startTime;
    private string animationBooleanName;

    public PlayerState(
        Player player, 
        PlayerStateMachine playerStateMachine,
        PlayerData playerData,
        string animationBooleanName) {
            this.player = player;
            this.playerStateMachine = playerStateMachine;
            this.playerData = playerData;
            this.animationBooleanName = animationBooleanName;
    }

    public virtual void Enter() {
        DoChecks();
        startTime = Time.time;
        player.Animator.SetBool(animationBooleanName, true);
        Debug.Log(animationBooleanName);
    }

    public virtual void Exit() {
        player.Animator.SetBool(animationBooleanName, false);
    }

    public virtual void LogicUpdate() {

    }

    public virtual void PhysicsUpdate() {
        DoChecks();
    }

    public virtual void DoChecks() {

    }
}
