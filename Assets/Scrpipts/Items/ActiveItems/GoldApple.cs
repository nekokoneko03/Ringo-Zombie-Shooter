using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldApple : ActiveItem, ITempBuff
{
    public override void OnUse(GameObject player)
    {
        Adapt();
    }

    public override void OnEnd()
    {
        OffAdapt();
    }

    public void Adapt()
    {
        
    }

    public void OffAdapt()
    {
        
    }
}
