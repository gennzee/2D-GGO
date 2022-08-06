using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_StunStateData", menuName = "Data/State Data/Stun State")]
public class D_StunState : ScriptableObject
{
    public string animName = "stun";

    public float stunTime = 3f;
    public float stunKnockbackTime = 0.3f;
    public float stunKnockbackSpeed = 10f;
    public Vector2 stunKnockbackAngel = new Vector2(1f, 2f);

}
