using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveItem : Item, IUseableItem
{
    public float activeTime;
    public float coolDown;

    public currentState currentState = currentState.Ready;

    public abstract void OnUse(GameObject player);

    public abstract void OnEnd();
}