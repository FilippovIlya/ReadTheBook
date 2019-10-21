using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class IceSkillOne : MonoBehaviour
{
    private CircleCollider2D coll;
    public float attack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>().health -= (attack / ((100 + collision.GetComponent<EnemyStats>().armor) / 100));

            StartCoroutine(Destroy());
        }
    }
    private void OnEnable()
    {
        coll = gameObject.GetComponent<CircleCollider2D>();
        StartCoroutine(Destroy());
        StartCoroutine(ChangeColliderSize());
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);

        GetComponent<PoolObject>().Return();
    }
    
    IEnumerator ChangeColliderSize()
    {
        coll.radius += 0.045f;
        if (coll.radius >= 4f)
        {
            coll.radius = 0.5f;
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(ChangeColliderSize());
    }
}
