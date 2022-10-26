using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugOnHit : OnHitEffect
{
    public override void Effect()
    {
        Debug.Log("TEST!");
    }
}
