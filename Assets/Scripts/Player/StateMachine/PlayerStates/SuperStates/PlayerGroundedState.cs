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
    protected int xInput;
    protected int yInput;

    public override void LogicUpdate() {
        base.LogicUpdate();
        xInput = player.InputHandler.NormalInputX;
        yInput = player.InputHandler.NormalInputY;
    }
}
