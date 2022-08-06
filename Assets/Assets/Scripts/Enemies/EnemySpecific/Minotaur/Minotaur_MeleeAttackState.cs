using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_MeleeAttackState : MeleeAttackState
{

    protected Minotaur enemy;

    public Minotaur_MeleeAttackState(FinateStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, Minotaur enemy) : base(stateMachine, entity, animBoolName, attackPosition, stateData)
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

        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
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

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
