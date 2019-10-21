using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class SkillsOne : MonoBehaviour
{
    public float attack;
    private GameObject enemy;
    public float duration;

    private void OnEnable()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    

    private void Update()
    {
        if (enemy != null)
        {
            transform.position = Vector3.Lerp(transform.position, enemy.transform.position, 1 / (duration * (Vector3.Distance(transform.position, enemy.transform.position))));
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") )
        {
            collision.GetComponent<EnemyStats>().health -= (attack / ((100 + collision.GetComponent<EnemyStats>().armor) / 100));
            
            StartCoroutine(Destroy());
        }
    }
    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        
        GetComponent<PoolObject>().Return();
    }
}
