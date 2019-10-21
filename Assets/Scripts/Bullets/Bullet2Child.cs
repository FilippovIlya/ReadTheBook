using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Child : MonoBehaviour
{
    //атака
    public float attack;
    //скорость полета
    public float duration;
    //куда летим?
    public bool top;
    public bool bottom;
    public bool right;
    public bool left;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>().health -= (attack / ((100 + collision.GetComponent<EnemyStats>().armor) / 100));
            
            
        }
    }
    
    private void Update()
    {
        
            if (top) transform.position += Vector3.up*duration*Time.deltaTime;
            if (bottom) transform.position += Vector3.down * duration * Time.deltaTime;
            if (left) transform.position += Vector3.left * duration * Time.deltaTime;
            if (right) transform.position += Vector3.right * duration * Time.deltaTime;

        
    }
    

}
