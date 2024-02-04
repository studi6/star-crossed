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

    public override void LogicUpdate() {
        base.LogicUpdate();
        if (input.x != 0) {
            playerStateMachine.ChangeState(player.MoveState);
        }
    }
}
