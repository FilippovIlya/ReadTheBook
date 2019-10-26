using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //пробный вариант спаунера для тестов
    //массив врагов
    public GameObject[] enemies;
    //время спавна
    public float spawnTime;
    private int enemiesAmount;
    private bool onlyone;
    public int enemiesCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(CreateEnemy());
            onlyone = true;
        }
    }
    
    
    
    //непосредственно спавн
    IEnumerator CreateEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
        enemiesAmount++;
        yield return new WaitForSeconds(spawnTime);
        if(enemiesAmount<= enemiesCount) StartCoroutine(CreateEnemy());
    }
}
