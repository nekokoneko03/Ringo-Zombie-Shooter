using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "ScriptableObject/New Bullet")]
public class BulletProperties : ScriptableObject
{
    public float damage;
    public float shotDelay;
    public float bulletSpeed;
}
