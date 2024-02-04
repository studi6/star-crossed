using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState {
    public PlayerMoveState(
        Player player,
        PlayerStateMachine playerStateMachine,
        PlayerData playerData,
        string animationBooleanName
    ) : base(player, playerStateMachine, playerData, animationBooleanName) {
        // nothing to do here...
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
        if (xInput == 0 && yInput == 0) {
            playerStateMachine.ChangeState(player.IdleState);
        } else {
            player.SetVelocityX(playerData.moveVelocity * xInput);
            player.SetVelocityY(playerData.moveVelocity * yInput);
        }
    }
}
