using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FinateStateMachine stateMachine;
    protected Entity entity;

    public float startTime { get; protected set; }

    protected string animBoolName;

    public State(FinateStateMachine stateMachine, Entity entity, string animBoolName)
    {
        this.stateMachine = stateMachine;
        this.entity = entity;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        //Debug.Log("State: " + stateMachine.currentState);
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        DoChecks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
