using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class PlayerAttack : MonoBehaviour
{
    //создать в дальнейшем массив для пуль и выгружать их оттуда
    //префаб пули №1
    public GameObject bulletPrefabWeap1;
    //префаб пули №2
    public GameObject bulletPrefabWeap2;
    //префаб пули №3
    public GameObject bulletPrefabWeap3;
    //ссылка на аниматор
    private Animator animator;
    //кулдаун атаки
    [HideInInspector] public float attackCooldown;
    //время когда была сделана атака
    private float attackTime;
    //ссылка на экип
    private Equip equip;
    private void Start()
    {
        equip = gameObject.GetComponent<Equip>();
        animator = gameObject.GetComponent<Animator>();
    }
    public void btnAttack()
    {
        Attack();
    }
    public void Attack()
    {
        //атака для каждого из типов оружия
        //в дальнейшем убрать все в отдельные функции?? найти лучшее решение
        attackCooldown = equip.cooldownattack;
        if (equip.weaponType == 1)
        {
            
            if (attackCooldown <= Time.time - attackTime)
            {
                if (GameObject.FindGameObjectWithTag("Enemy") != null)
                {
                attackTime = Time.time;
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", false);
                    PoolObject bullet = PoolManager.Get(1);
                    bullet.transform.position = transform.position;
                }
            }
        }
        else if(equip.weaponType == 2)
        {
            if (attackCooldown <= Time.time - attackTime)
            {
                
                    attackTime = Time.time;
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isIdle", false);
                PoolObject bullet2 = PoolManager.Get(2);
                bullet2.transform.position = transform.position;
            }
        }
        else if (equip.weaponType == 3)
        {
            if (attackCooldown <= Time.time - attackTime)
            {
                
                    attackTime = Time.time;
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isIdle", false);
                PoolObject bullet2 = PoolManager.Get(2);
                bullet2.transform.position = transform.position;
            }
        }
    }
    
}
