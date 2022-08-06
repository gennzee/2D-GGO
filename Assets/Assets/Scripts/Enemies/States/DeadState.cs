using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{

    protected D_DeadState stateData;

    protected bool canDisappear;

    public DeadState(FinateStateMachine stateMachine, Entity entity, string animBoolName, D_DeadState stateData) : base(stateMachine, entity, animBoolName)
    {
        this.stateData = stateData;
    }    

    public override void Enter()
    {
        base.Enter();

        canDisappear = false;
        entity.SetVelocity(0f);
        entity.rb.simulated = false;
        entity.box2d.enabled = false;
    }

    public override void Exit()
    {
        base.Exit();        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + stateData.disappearTime)
        {
            canDisappear = true;
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

    public virtual void DoDisappear()
    {
        entity.rb.simulated = true;
        entity.box2d.enabled = true;
        entity.gameObject.SetActive(false);
    }
}
