using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class SkillThree : MonoBehaviour
{
    public float attack;
    
    public float castDamageEveryTime;
    public float currentCastTime;
    public GameObject player;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y , player.transform.position.z-0.3f);
    }

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
        yield return new WaitForSeconds(5f);

        GetComponent<PoolObject>().Return();
    }
}
