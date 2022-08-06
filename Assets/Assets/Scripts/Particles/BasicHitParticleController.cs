using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHitParticleController : MonoBehaviour
{
    public void FinishHitParticle()
    {
        Destroy(this.gameObject);
    }
}
