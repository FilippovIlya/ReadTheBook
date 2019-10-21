using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class IceSkillTwo : MonoBehaviour
{
    private GameObject player;
    private bool yes;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Effects>().Slowthisshit();
        }
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.6f);
    }
    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);

        GetComponent<PoolObject>().Return();
    }
    
}
