using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Active Item", menuName = "ScriptableObject/New Active Item")]
public class ActiveItemProperties : ItemProperties
{
    public float activeTime;
    public float coolDownTime;
}
