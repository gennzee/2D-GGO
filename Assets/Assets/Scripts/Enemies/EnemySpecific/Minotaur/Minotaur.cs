using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Entity
{
    public Minotaur_IdleState idleState { get; private set; }
    public Minotaur_MoveState moveState { get; private set; }
    public Minotaur_PlayerDetectedState playerDetectedState { get; private set; }
    public Minotaur_ChargeState chargeState { get; private set; }
    public Minotaur_LookForPlayerState lookForPlayerState { get; private set; }
    public Minotaur_MeleeAttackState meleeAttackState { get; private set; }
    public Minotaur_StunState stunState { get; private set; }
    public Minotaur_DeadState deadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedStateData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttackState meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();
        idleState = new Minotaur_IdleState(stateMachine, this, idleStateData.animName, idleStateData, this);
        moveState = new Minotaur_MoveState(stateMachine, this, moveStateData.animName, moveStateData, this);
        playerDetectedState = new Minotaur_PlayerDetectedState(stateMachine, this, playerDetectedStateData.animName, playerDetectedStateData, this);
        chargeState = new Minotaur_ChargeState(stateMachine, this, chargeStateData.animName, chargeStateData, this);
        lookForPlayerState = new Minotaur_LookForPlayerState(stateMachine, this, lookForPlayerStateData.animName, lookForPlayerStateData, this);
        meleeAttackState = new Minotaur_MeleeAttackState(stateMachine, this, meleeAttackStateData.animName, meleeAttackPosition, meleeAttackStateData, this);
        stunState = new Minotaur_StunState(stateMachine, this, stunStateData.animName, stunStateData, this);
        deadState = new Minotaur_DeadState(stateMachine, this, deadStateData.animName, deadStateData, this);

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

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }    
}
