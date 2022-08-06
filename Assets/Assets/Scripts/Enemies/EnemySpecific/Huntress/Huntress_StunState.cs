using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huntress_StunState : StunState
{

    private Huntress enemy;

    public Huntress_StunState(FinateStateMachine stateMachine, Entity entity, string animBoolName, D_StunState stateData, Huntress enemy) : base(stateMachine, entity, animBoolName, stateData)
    {
        this.enemy = enemy;
    }    

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isStunTimeOver)
        {
            if (performCloseRangeAction)
            {
                if (Time.time >= enemy.dodgeState.startTime + enemy.dodgeStateData.dodgeCooldown)
                {
                    stateMachine.ChangeState(enemy.dodgeState);
                }
                else
                {
                    stateMachine.ChangeState(enemy.rangeAttackState);
                }
            }
            else
            {
                enemy.lookForPlayerState.SetTurnImmediately(true);
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
}
