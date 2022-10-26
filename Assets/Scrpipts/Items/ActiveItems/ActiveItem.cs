using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveItem : Item
{
    public ActiveItemProperties activeItemProperties;
    public ActiveItemProperties test;

    public currentState currentState = currentState.Ready;

    public bool canGetNewItem = false;

    private GameObject target;
    private float targetStatus;
    private float amount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetActiveItem(test);
        }
    }

    public void OnUse(GameObject test)
    {
        switch (activeItemProperties.targetType)
        {
            case TargetType.Player:
                target = GameObject.FindGameObjectWithTag("Player");
                break;
            case TargetType.Enemy: // TODO: Create method to find closest enemy.
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
        }

        if (activeItemProperties.effectType == EffectType.ChangeSomething)
        {
            switch (activeItemProperties.statusType)
            {
                case StatusType.ChangeBullet:
                    target.GetComponent<shotController>().ChangeBullet(activeItemProperties.bulletPrefab);
                    break;
                case StatusType.ChangeOnHitEffect:
                    target.GetComponent<shotController>().ChangeBulletEffect(activeItemProperties.onHitEffect);
                    break;
            }
        }

        target.GetComponent<IBuffable>().Buff(activeItemProperties.statusType, amount);
    }

    public void OnEnd()
    {
        if (activeItemProperties.effectType == EffectType.ChangeSomething)
        {
            switch (activeItemProperties.statusType)
            {
                case StatusType.ChangeBullet:
                    target.GetComponent<shotController>().RevertBullet();
                    break;
                case StatusType.ChangeOnHitEffect:
                    target.GetComponent<shotController>().RevertBulletEffect();
                    break;
            }
        }

        target.GetComponent<IBuffable>().EndBuff(activeItemProperties.statusType, amount);
        activeItemProperties = null;
        canGetNewItem = true;
    }

    public void GetActiveItem(ActiveItemProperties newItem)
    {
        if (canGetNewItem != true) return;
        activeItemProperties = newItem;
        currentState = currentState.Ready;
        GetComponent<PlayerActiveItem>().Init();
        UiManager.instance.ChangeActiveItemIcon(newItem.icon);
    }
}