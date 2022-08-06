using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huntress_LookForPlayerState : LookForPlayerState
{

    private Huntress enemy;

    public Huntress_LookForPlayerState(FinateStateMachine stateMachine, Entity entity, string animBoolName, D_LookForPlayerState stateData, Huntress enemy) : base(stateMachine, entity, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
        else if (isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
