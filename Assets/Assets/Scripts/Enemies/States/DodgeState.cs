using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{

    protected D_DodgeState stateData;

    protected bool isGrounded;
    protected bool isDodgeOver;
    protected bool isPlayerInMaxAgroRange;
    protected bool performCloseRangeAction;

    public DodgeState(FinateStateMachine stateMachine, Entity entity, string animBoolName, D_DodgeState stateData) : base(stateMachine, entity, animBoolName)
    {
        this.stateData = stateData;
    }    

    public override void Enter()
    {
        base.Enter();

        isDodgeOver = false;
        entity.SetVelocity(stateData.dodgeSpeed, stateData.dodgeAngel, -entity.facingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + stateData.dodgeTime && isGrounded)
        {
            isDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = entity.CheckGround();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }
}
