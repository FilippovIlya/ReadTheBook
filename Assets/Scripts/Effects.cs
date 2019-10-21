using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    //запуск корутины замедления
    public void Slowthisshit()
    {
        StartCoroutine(SlowEnemy());
    }
    //замедление моба на 2 секунды
    IEnumerator SlowEnemy()
    {
        float y = gameObject.GetComponent<EnemyStats>().duration;
        gameObject.GetComponent<EnemyStats>().duration = 50;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<EnemyStats>().duration = y;
    }
}
