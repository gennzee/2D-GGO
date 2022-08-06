using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_LookForPlayerStateData", menuName = "Data/State Data/Look For Player State")]
public class D_LookForPlayerState : ScriptableObject
{
    public string animName = "lookForPlayer";
    public int amountOfTurns = 2;
    public float timeBetweenTurns = 0.7f;
}
