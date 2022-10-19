using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterMelon : ActiveItem, ITempBuff
{
    public float attackSpeedMultiplierBuff;

    shotController playerStatus;

    public override void OnUse(GameObject player)
    {
        playerStatus = player.GetComponent<shotController>();
        Adapt();
    }
    public override void OnEnd()
    {
        OffAdapt();
    }

    public void Adapt()
    {
        playerStatus.attackSpeedMultiplier -= attackSpeedMultiplierBuff;
    }

    public void OffAdapt()
    {
        playerStatus.attackSpeedMultiplier += attackSpeedMultiplierBuff;
    }
}
