using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_RangeAttackStateData", menuName = "Data/State Data/Range Attack State")]
public class D_RangeAttackState : ScriptableObject
{
    public string animName = "rangeAttack";

    public GameObject projectile;
    public float projectileSpeed = 20f;
    public float projectileTravelDistance = 10f;
    public float damageAmount = 10f;

}
