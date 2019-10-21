using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class IceSkillThree : MonoBehaviour
{
    public float attack;

    public float castDamageEveryTime;
    public float currentCastTime;
    public GameObject player;
    
    
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
    private void OnEnable()
    {
        StartCoroutine(Destroy());
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 20, player.transform.position.z);
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);

        GetComponent<PoolObject>().Return();
    }
}
