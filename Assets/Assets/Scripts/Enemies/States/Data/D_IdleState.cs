using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_IdleStateData", menuName = "Data/State Data/Idle State")]
public class D_IdleState : ScriptableObject
{
    public string animName = "idle";
    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;
}
