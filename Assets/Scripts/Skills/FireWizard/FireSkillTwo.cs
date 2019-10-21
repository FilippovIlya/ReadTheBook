using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class FireSkillTwo : MonoBehaviour
{
    public float attack;

    public float castDamageEveryTime;
    private float currentCastTime;
    
    private void OnEnable()
    {
       
        StartCoroutine(Destroy());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            if (castDamageEveryTime <= Time.time - currentCastTime)
            {
                currentCastTime = Time.time;
                collision.GetComponent<EnemyStats>().health -= (attack / ((100 + collision.GetComponent<EnemyStats>().armor) / 100));
            }
        }
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(7f);

        GetComponent<PoolObject>().Return();
    }
}
