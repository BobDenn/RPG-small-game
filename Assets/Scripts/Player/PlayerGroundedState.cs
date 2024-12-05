using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        // test counter attack
        if (Input.GetKeyDown(KeyCode.Q))
            stateMachine.ChangeState(player.counterAttackState);
        
        if(Input.GetKey(KeyCode.Mouse0))
            stateMachine.ChangeState(player.PrimaryAttackState);
        
        if(!player.IsGroundDetected())
            stateMachine.ChangeState(player.airState);
        
        if(Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected() )
            stateMachine.ChangeState(player.jumpState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
