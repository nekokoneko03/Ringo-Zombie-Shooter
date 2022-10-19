using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : Enemy
{
    private void Update()
    {
        MoveToTarget();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Death()
    {
        base.Death();
    }
}
