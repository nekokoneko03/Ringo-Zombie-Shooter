using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMelon : ActiveItem
{
    shotController playerStatus;
    float originShotDelay;

    public override void OnUse(GameObject player)
    {
        playerStatus = player.GetComponent<shotController>();
        originShotDelay = playerStatus.shotDelay;
        playerStatus.shotDelay = 0.2f;
    }

    public override void OnEnd()
    {
        playerStatus.shotDelay = originShotDelay;
    }
}
