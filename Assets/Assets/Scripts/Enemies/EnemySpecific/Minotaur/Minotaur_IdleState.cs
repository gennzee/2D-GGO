using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_IdleState : IdleState
{

    private Minotaur enemy;

    public Minotaur_IdleState(FinateStateMachine stateMachine, Entity entity, string animBoolName, D_IdleState stateData, Minotaur enemy) : base(stateMachine, entity, animBoolName, stateData)
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

        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
