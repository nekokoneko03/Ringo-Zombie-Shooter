using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "ScriptableObject/New Bullet")]
public class BulletProperties : ScriptableObject
{
    public new string name;
    public string description;
    public float attackDamage;
    public float attackSpeed;
    public float bulletSpeed;
    public float bulletCount;
    public float bulletAngle;
}
