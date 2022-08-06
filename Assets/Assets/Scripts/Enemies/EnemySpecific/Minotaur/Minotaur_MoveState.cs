using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_MoveState : MoveState
{

    private Minotaur enemy;

    public Minotaur_MoveState(FinateStateMachine stateMachine, Entity entity, string animBoolName, D_MoveState stateData, Minotaur enemy) : base(stateMachine, entity, animBoolName, stateData)
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

        if ((isDetectingWall || !isDetectingLedge) || isMoveTimeOver)
        {
            enemy.idleState.SetFlipAfterIdle(true);   
            stateMachine.ChangeState(enemy.idleState);
        }
        if (isPlayerInMinAgroRange)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}