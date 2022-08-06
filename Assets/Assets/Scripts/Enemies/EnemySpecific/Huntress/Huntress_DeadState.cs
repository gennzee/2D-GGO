using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huntress_DeadState : DeadState
{

    private Huntress enemy;

    public Huntress_DeadState(FinateStateMachine stateMachine, Entity entity, string animBoolName, D_DeadState stateData, Huntress enemy) : base(stateMachine, entity, animBoolName, stateData)
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

        if (canDisappear)
        {
            DoDisappear();
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

    public override void DoDisappear()
    {
        base.DoDisappear();
    }
}
