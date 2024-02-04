using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState {
    public PlayerGroundedState(
        Player player, 
        PlayerStateMachine playerStateMachine,
        PlayerData playerData,
        string animationBooleanName
    ) : base(player, playerStateMachine, playerData, animationBooleanName) {
        
    }
    protected Vector2 input;

    public override void LogicUpdate() {
        base.LogicUpdate();
        input = player.InputHandler.MovementInput;
    }
}
