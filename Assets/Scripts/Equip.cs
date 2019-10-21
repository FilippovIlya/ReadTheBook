using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equip : MonoBehaviour
{  
    //здоровье от вещей
   [HideInInspector] public float health;
    //армор от вещей
    [HideInInspector] public float armor;
    //мана от вещей
    [HideInInspector] public float mana;
    //скорость  от вещей
    [HideInInspector] public float speed;
    //реген маны с амулета
    [HideInInspector] public float manaregenFromAmulet;
    //реген маны с брони
    [HideInInspector] public float manaregenfromArmor;
    //тип оружия - влияет на основную атаку
    [HideInInspector] public int weaponType;
    //кулдаун основной атаки
    [HideInInspector] public float cooldownattack;
    //ссылка на инвентарь
    private BackPack backPack;
    //влияет на способность дополнительного оружия ! пока не проработано
    [HideInInspector] public int skillType;
    private void Start()
    {
        //по смене оружия апдейтим инфу в инвентаре
        backPack = GameObject.FindGameObjectWithTag("GameController").GetComponent<BackPack>();
        backPack.itemChanged.AddListener(ChangeWeapon);
        backPack.itemChanged.AddListener(ChangeHelp);
        backPack.itemChanged.AddListener(ChangeBoots);
        backPack.itemChanged.AddListener(ChangeArmor);
        backPack.itemChanged.AddListener(ChangeAmulet);
    }
    //контролируем оружие
    public void ChangeWeapon()
    {
        if(backPack.items[0].id == 3)
        {
            weaponType = 1;
            cooldownattack = 0.5f;
            //attack = 50;
        } else if (backPack.items[0].id == 4)
        {
            weaponType = 2;
            cooldownattack = 0.4f;
            //attack = 75;
        } else if (backPack.items[0].id == 9)
        {
            weaponType = 3;
            cooldownattack = 0.4f;
            //attack = 100;
        }
        

    }
    //контролируем доп оружие ! не проработано
    public void ChangeHelp()
    {
        if (backPack.items[4].id == 8)
        {
            skillType = 1;
        }
        else if (backPack.items[4].id == 16)
        {
            skillType = 2;
        }
        

    }
    //контролируем броню
    public void ChangeArmor()
    {
        if (backPack.items[1].id == 5)
        {
            health = 500;
            armor = 5;
        }
        else if (backPack.items[1].id == 10)
        {
            health = 1000;
            armor = 10;
        }
        else if (backPack.items[1].id == 11)
        {
            health = 1500;
            armor = 8;
            manaregenfromArmor = 10;
        } else if(backPack.items[1].id == 0) { health = 0;
            armor = 0;
            manaregenfromArmor = 0;
        }

    }
    //контролируем амулет
    public void ChangeAmulet()
    {
        if (backPack.items[2].id == 6)
        {
            mana = 500;
        }
        else if (backPack.items[2].id == 12)
        {
            mana = 800;
            manaregenFromAmulet = 10;
        }
        else if (backPack.items[2].id == 13)
        {
            mana = 1000;
            manaregenFromAmulet = 20;
        }

    }
    //контролируем сапоги
    public void ChangeBoots()
    {
        if (backPack.items[3].id == 7)
        {
            speed = 10;
        }
        else if (backPack.items[3].id == 14)
        {
            speed = 20;
        }
        else if (backPack.items[3].id == 15)
        {
            speed = 30;
        }

    }
}
