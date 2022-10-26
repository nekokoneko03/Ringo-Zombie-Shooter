using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItem : Item
{
    public ActiveItemProperties activeItemProperties;

    public currentState currentState = currentState.Ready;

    private GameObject target;
    private float targetStatus;
    private float amount;

    private void Start()
    {
        switch (activeItemProperties.targetType)
        {
            case TargetType.Player:
                target = GameObject.FindGameObjectWithTag("Player");
                break;
            case TargetType.Enemy: // TODO: Create method to find closest enemy.
                target = null;
                break;
            default:
                target = null;
                break;
        }

        switch (activeItemProperties.effectType)
        {
            case EffectType.Buff:
                amount = activeItemProperties.amount;
                break;
            case EffectType.DeBuff:
                amount = -(activeItemProperties.amount);
                break;
            default:
                amount = 0f;
                break;
        }
    }

    public void OnUse(GameObject test)
    {
        target.GetComponent<IBuffable>().Buff(activeItemProperties.statusType, amount);
    }

    public void OnEnd()
    {
        target.GetComponent<IBuffable>().EndBuff(activeItemProperties.statusType, amount);
    }
}