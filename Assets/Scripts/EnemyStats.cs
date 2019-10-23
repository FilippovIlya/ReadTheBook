using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //атака моба
    public float attack;
    //здоровье моба
    public float health;
    //армор моба
    public float armor;
    //время когда монстр атаковал
    private float attackTime;
    //кулдаун атаки монстра
    public float attackCooldown;
    //количество опыта за монстра
    public float expForPlayer;
    //ссылка на игрока
    private GameObject player;
    //скорость моба
    public float duration;
    //ригидбади чтобы работали OnTriggerStay когда моб стоит
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //будим если стоит
        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }
        //когда здоровье моба меньше 0 даем игроку экспу и убиваем
        if (health <= 0)
        {
            player.GetComponent<PlayerProgress>().curExp += expForPlayer;
            Destroy(gameObject);
        }
        //двигаем если игрок дальше чем 5 метров
        if (player != null && Vector3.Distance(player.transform.position, rb.position) >= 3)
        {
            rb.position = Vector3.Lerp(transform.position, player.transform.position, 1 / (duration * (Vector3.Distance(transform.position, player.transform.position))));
        }
        //если игрок ближе 5 метров атакуем
        else if (player != null && Vector3.Distance(player.transform.position, rb.position) < 3)
        {
            Attack();
        }
    }

    //атака
    public void Attack()
    {
        if(attackCooldown <= Time.time - attackTime) { 
        attackTime = Time.time;
            player.GetComponent<PlayerProgress>().curLife -= (attack / ((100 + player.GetComponent<PlayerProgress>().armor) / 100));
        }
    }
}
