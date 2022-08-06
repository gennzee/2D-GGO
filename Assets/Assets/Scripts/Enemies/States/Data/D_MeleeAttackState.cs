using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_MeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]
public class D_MeleeAttackState : ScriptableObject
{
    public string animName = "meleeAttack";
    public float attackRadius = 0.5f;
    public float damageAmount = 10f;

    public LayerMask whatIsPlayer;
}
