using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuffable
{
    public void Buff(StatusType statusType, float amount);
    public void EndBuff(StatusType statusType, float amount);
}
