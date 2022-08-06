using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huntress : Entity
{

    public Huntress_IdleState idleState { get; private set; }
    public Huntress_MoveState moveState { get; private set; }
    public Huntress_PlayerDetectedState playerDetectedState { get; private set; }
    public Huntress_LookForPlayerState lookForPlayerState { get; private set; }
    public Huntress_DodgeState dodgeState { get; private set; }
    public Huntress_RangeAttackState rangeAttackState { get; private set; }
    public Huntress_StunState stunState { get; private set; }
    public Huntress_DeadState deadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    public D_DodgeState dodgeStateData;
    [SerializeField]
    private D_RangeAttackState rangeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private Transform rangeAttackPosition;

    public override void Start()
    {
        base.Start();
        idleState = new Huntress_IdleState(stateMachine, this, idleStateData.animName, idleStateData, this);
        moveState = new Huntress_MoveState(stateMachine, this, moveStateData.animName, moveStateData, this);
        playerDetectedState = new Huntress_PlayerDetectedState(stateMachine, this, playerDetectedStateData.animName, playerDetectedStateData, this);
        lookForPlayerState = new Huntress_LookForPlayerState(stateMachine, this, lookForPlayerStateData.animName, lookForPlayerStateData, this);
        dodgeState = new Huntress_DodgeState(stateMachine, this, dodgeStateData.animName, dodgeStateData, this);
        rangeAttackState = new Huntress_RangeAttackState(stateMachine, this, rangeAttackStateData.animName, rangeAttackPosition, rangeAttackStateData, this);
        stunState = new Huntress_StunState(stateMachine, this, stunStateData.animName, stunStateData, this);
        deadState = new Huntress_DeadState(stateMachine, this, deadStateData.animName, deadStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(this.deadState);
        }
        else if (isStunned && stateMachine.currentState != this.stunState)
        {
            stateMachine.ChangeState(this.stunState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}
