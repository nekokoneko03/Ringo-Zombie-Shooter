using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMelon : ActiveItem
{
    shotController playerStatus;
    float originShotDelay;

    public override void OnUse(GameObject player)
    {
        Debug.Log(player.transform.name);
        playerStatus = player.GetComponent<shotController>();
        originShotDelay = playerStatus.shotDelay;
        playerStatus.shotDelay = 0.2f;
        StartCoroutine(OnEnd());
    }

    IEnumerator OnEnd()
    {
        yield return new WaitForSeconds(activeTime);
        playerStatus.shotDelay = originShotDelay;
    }
}
