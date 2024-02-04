using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState {
    public PlayerIdleState(
        Player player,
        PlayerStateMachine playerStateMachine,
        PlayerData playerData,
        string animationBooleanName
    ) : base(player, playerStateMachine, playerData, animationBooleanName) {
        
    }

    public override void Enter() {
        base.Enter();
        player.SetVelocityX(0, false);
        player.SetVelocityY(0, false);
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
        if (xInput != 0 || yInput != 0) {
            playerStateMachine.ChangeState(player.MoveState);
        }
    }
}
