﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class Bullet : MonoBehaviour
{
    //урон пули
    public float attack;
    // искомый враг
    private GameObject enemy;
    //скорость полета
    public float duration;
    //бьем только по одной цели
    private bool onlyoneTarget;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")&&!onlyoneTarget)
        {
            collision.GetComponent<EnemyStats>().health -= (attack / ((100 + collision.GetComponent<EnemyStats>().armor) / 100));
            GetComponent<PoolObject>().Return();
            onlyoneTarget = true;
        }
    }
    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        
    }
    private void Update()
    {
        if (enemy != null)
        {
            transform.position = Vector3.Lerp(transform.position, enemy.transform.position, 1 / (duration * (Vector3.Distance(transform.position, enemy.transform.position))));
          
        } else { GetComponent<PoolObject>().Return(); }
    }
    
}
