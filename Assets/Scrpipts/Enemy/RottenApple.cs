using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenApple : Enemy, IDamageable
{
    private void Update()
    {
        base.MoveToTarget();
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
