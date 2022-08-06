using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : State
{

    protected D_LookForPlayerState stateData;

    protected bool isPlayerInMinAgroRange;

    protected bool turnImmediately;
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;
    protected float lastTurnTime;
    protected int amountOfTurnsDone;

    public LookForPlayerState(FinateStateMachine stateMachine, Entity entity, string animBoolName, D_LookForPlayerState stateData) : base(stateMachine, entity, animBoolName)
    {
        this.stateData = stateData;
    }    

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;
        lastTurnTime = startTime;
        amountOfTurnsDone = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (turnImmediately)
        {
            turnImmediately = false;
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }
        else if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && !isAllTurnsDone)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }

        if (amountOfTurnsDone >= stateData.amountOfTurns)
        {
            isAllTurnsDone = true;
        }

        if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnsDone)
        {
            isAllTurnsTimeDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMaxAgroRange();
    }

    public void SetTurnImmediately(bool flip)
    {
        turnImmediately = flip;
    }
}
