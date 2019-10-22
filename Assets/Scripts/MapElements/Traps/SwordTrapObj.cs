using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrapObj : MonoBehaviour
{
    public GameObject bloodSprayPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(SprayBlood(3f, collision.gameObject.transform.position, collision.gameObject));
            collision.gameObject.GetComponent<PlayerProgress>().curLife = 0;
        }
    }
    
    private IEnumerator SprayBlood(float delay, Vector2 position, GameObject player)
    {
        var bloodSpray = (GameObject)Instantiate(bloodSprayPrefab, position, Quaternion.identity);
        Destroy(bloodSpray, 3f);

        yield return new WaitForSeconds(delay);
    }

}
