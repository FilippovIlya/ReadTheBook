using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    SpriteRenderer sprite;
    //картинка
    public Sprite img;
    private BackPack backPack;
    //id
    public int id;
    //количество
    public int count;
    //тэг
    public string itemtag;
    //инфа
    public string info;
    //список итемов
    private DataBase data;
    public bool yes;
    public bool no;
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("GameController").GetComponent<DataBase>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = img;
        backPack = GameObject.FindGameObjectWithTag("GameController").GetComponent<BackPack>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (itemtag == "Loot")
            {
                if (!yes)
                {
                    for (int i = 5; i < backPack.items.Count; i++)
                    {
                        if (backPack.items[i].id == id && backPack.items[i].count!=128)
                        {
                            if (backPack.items[i].count + count <= 128)
                            {
                                backPack.items[i].count += count;
                                backPack.UpdateInventory();
                                no = true;
                                Destroy(gameObject);
                              
                            }
                            else if(backPack.items[i].count + count > 128)
                            {

                                count = backPack.items[i].count + count - 128;
                                backPack.items[i].count = 128;
                                yes = true;
                                backPack.UpdateInventory();
                                break;
                            } 
                            
                        } 
                        

                    }
                    yes = true;

                }
                if(yes&&!no){
                    for (int i = 5; i < backPack.items.Count; i++)
                    {
                        if (backPack.items[i].id == 0)
                        {
                            backPack.AddItem(data.items[i].id, data.items[id], count);
                            Destroy(gameObject);
                            break;
                        }

                    }
                }
                
            } 
            else
            {
                for (int i = 5; i < backPack.items.Count; i++)
                {
                    if (backPack.items[i].id == 0)
                    {
                        backPack.AddItem(data.items[i].id, data.items[id], 1);
                        Destroy(gameObject);
                        break;
                    }

                }
            }
            
            
        }
    }
    
    
}
