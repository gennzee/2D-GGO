using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{

    protected D_ChargeState stateData;

    protected bool isPlayerInMinArgoRange;
    protected bool isPlayerInMaxArgoRange;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool performCloseRangeAction;

    protected bool isChargeTimeOver;

    public ChargeState(FinateStateMachine stateMachine, Entity entity, string animBoolName, D_ChargeState stateData) : base(stateMachine, entity, animBoolName)
    {
        this.stateData = stateData;
    }    

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.chargeSpeed);        
        isChargeTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingWall = entity.CheckWall();
        isDetectingLedge = entity.CheckLedge();
        isPlayerInMinArgoRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxArgoRange = entity.CheckPlayerInMaxAgroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
}
}
