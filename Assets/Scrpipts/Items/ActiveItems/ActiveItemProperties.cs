using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Active Item", menuName = "ScriptableObject/New Active Item")]
public class ActiveItemProperties : ScriptableObject
{
    public Image icon;
    public new string name;
    public string description;
    public TargetType targetType;
    public EffectType effectType;
    public StatusType statusType;
    public float amount;
    public float activeTime;
    public float coolDownTime;
    [Header("Change one item below this when EffectType is 'ChangeSomthing'.")]
    public Bullet bulletPrefab;
    public OnHitEffect onHitEffect;
}

public enum TargetType
{
    Player,
    Enemy
}

public enum EffectType
{
    Buff,
    DeBuff,
    ChangeSomething
}

public enum StatusType
{
    Hp,
    AttackDamage,
    AttackSpeed,
    BulletCount,
    BulletSpeed,
    BulletPenetration,
    MovementSpeed,
    Immune,
    ChangeBullet,
    ChangeOnHitEffect
}
public enum currentState
{
    Ready,
    Active,
    Cooldown,
}
