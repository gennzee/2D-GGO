using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_ChargeStateData", menuName = "Data/State Data/Charge State")]
public class D_ChargeState : ScriptableObject
{
    public string animName = "charge";
    public float chargeSpeed = 10f;
    public float chargeTime = 0.5f;
}
