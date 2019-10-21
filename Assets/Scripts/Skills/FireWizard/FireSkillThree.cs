using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class FireSkillThree : MonoBehaviour
{
    public float attack;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>().health -= (attack / ((100 + collision.GetComponent<EnemyStats>().armor) / 100));

        }
    }
    private void Update()
    {
        transform.RotateAround(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z +25), 90 * Time.deltaTime);
    }
    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(8f);

        GetComponent<PoolObject>().Return();
    }
}
