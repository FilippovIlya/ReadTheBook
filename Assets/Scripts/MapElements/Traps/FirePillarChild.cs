using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillarChild : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerProgress>().curLife -= 150;
        }
    }

    
}
