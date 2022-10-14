using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Status")]
    public EnemyStatus status;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected void MoveToTarget()
    {
        this.transform.position = 
            Vector2.MoveTowards(this.transform.position, target.position, status.moveSpeed * Time.deltaTime);
    }
}
