using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_MoveStateData", menuName = "Data/State Data/Move State")]
public class D_MoveState : ScriptableObject
{
    public string animName = "move";
    public float moveSpeed = 5f;
    public float minMoveTime = 1f;
    public float maxMoveTime = 2f;
}
