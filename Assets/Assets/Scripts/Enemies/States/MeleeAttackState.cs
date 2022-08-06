using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{

    protected D_MeleeAttackState stateData;
    protected AttackDetails attackDetails;

    public MeleeAttackState(FinateStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData) : base(stateMachine, entity, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        attackDetails.damageAmount = stateData.damageAmount;
        attackDetails.position = entity.aliveGO.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);
        foreach (Collider2D collider in detectedObjects)
        {
            Debug.Log(collider.gameObject.name);
            //TODO: do damage to player
            //collider.transform.SendMessage("Damage", attackDetails);
        }
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
