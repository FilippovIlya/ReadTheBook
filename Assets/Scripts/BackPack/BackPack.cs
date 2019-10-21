using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BackPack : MonoBehaviour
{
    public GameObject btnDestroy;
    //событие смены оружия
    public UnityEvent itemChanged;
    //список вещей в инвентаре
    public List<ItemInventory> items = new List<ItemInventory>();
    //префаб итема
    public GameObject gameObjShow;
    //сам инвентарь
    public GameObject InventoryMainObj;
    //количество предметов в инвентаре
    public int maxCount;
    //камера
    public Camera cam;
    //система ивентов
    public EventSystem es;
    //текущий айди шмотки для перемещения
    public int currentID;
    //текущая переносимая шмотка
    public ItemInventory currentItem;
    //рект переносимой шмотки
    public RectTransform movingObj;
    //отступ
    public Vector3 offset;
    //бэк инвентаря
    public GameObject Background;
    //сюда суем объект на которой висит скрипт DataBase
    public DataBase data;
    //текст с инфой
    public GameObject itemInfoPanel;
    
    private void Start()
    {
        
        if (itemChanged == null)
            itemChanged = new UnityEvent();
        if (items.Count==0)
        {
            AddGraphics();
        }
        //for (int i = 0; i < maxCount; i++) //тест заполнение рандомные ячейки
        //{
        //    AddItem(i, data.items[Random.Range(1, data.items.Count)], Random.Range(1, 128));
        //}
        UpdateInventory();
        itemChanged.Invoke();
    }
    public void Update()
    {
        if(currentID!=-1)
        {
            MoveObject();
        }
        
    }

    public void AddItem(int id, Item item, int count)
    {
        items[id].id = item.id;
        items[id].count = count;
        items[id].itemGameObj.GetComponent<Image>().sprite = item.img;
        items[id].tag = item.tag;
        items[id].info = item.info;
        if (count > 1 && item.id != 0 && item.tag != "Weapon" && item.tag != "Armor" && item.tag != "Help" && item.tag != "Boots" && item.tag != "Amulet")
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();
        } else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }
    public void AddGraphics()
    {
        for(int i=0 ; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObj.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory ii = new ItemInventory();
            ii.itemGameObj = newItem;
            
            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempbutton = newItem.GetComponent<Button>();
            
            tempbutton.onClick.AddListener(delegate { SelectObj(); });
            tempbutton.onClick.AddListener(delegate { ShowItemInfo(); });

            items.Add(ii);
        }
    }
    public void AddInventoryItem(int id, ItemInventory invItem)
    {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].itemGameObj.GetComponent<Image>().sprite = data.items[invItem.id].img;
        items[id].tag = invItem.tag;
        items[id].info = invItem.info;
        if (invItem.count > 1 && invItem.id != 0 && invItem.tag != "Weapon" && invItem.tag != "Armor" && invItem.tag != "Help" && invItem.tag != "Boots" && invItem.tag != "Amulet")
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = invItem.count.ToString();
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }
    public void UpdateInventory()
    {
        for(int i = 0; i < maxCount; i++)
        {
            if(items[i].id != 0 && items[i].tag != "Weapon" && items[i].tag != "Armor" && items[i].tag != "Help" && items[i].tag != "Boots" && items[i].tag != "Amulet" && items[i].count >1)
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = "";
                
            }
            
            items[i].itemGameObj.GetComponentInChildren<Image>().sprite = data.items[items[i].id].img;
        }
    }
    public void SelectObj()
    {
        if (currentID == -1 )
        {
            
            currentID = int.Parse(es.currentSelectedGameObject.name);
            
            currentItem = CopyInventoryItem(items[currentID]);
            if (currentItem.id == 0)
            {
                currentID = -1;
                currentItem = null;
                return; }
            movingObj.gameObject.SetActive(true);
            
            movingObj.GetComponent<Image>().sprite = data.items[currentItem.id].img;

            AddItem(currentID, data.items[0], 0);
        }
                else
        {

            ItemInventory II = items[int.Parse(es.currentSelectedGameObject.name)];
            if (currentItem.tag == "Weapon" && II.itemGameObj.name == "0")
            {
                AddInventoryItem(currentID, II);
                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
                itemChanged.Invoke();
            } else if (currentItem.tag != "Weapon" && II.itemGameObj.name == "0")
            {
                return;
            }
            else if (currentItem.tag == "Armor" && II.itemGameObj.name == "1")
            {
                AddInventoryItem(currentID, II);
                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
                itemChanged.Invoke();
            }
            else if (currentItem.tag != "Armor" && II.itemGameObj.name == "1")
            {
                return;
            }
            else if (currentItem.tag == "Amulet" && II.itemGameObj.name == "2")
            {
                AddInventoryItem(currentID, II);
                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
                itemChanged.Invoke();
            }
            else if (currentItem.tag != "Amulet" && II.itemGameObj.name == "2")
            {
                return;
            }
            else if (currentItem.tag == "Boots" && II.itemGameObj.name == "3")
            {
                AddInventoryItem(currentID, II);
                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
                itemChanged.Invoke();
            }
            else if (currentItem.tag != "Boots" && II.itemGameObj.name == "3")
            {
                return;
            }
            else if (currentItem.tag == "Help" && II.itemGameObj.name == "4")
            {
                AddInventoryItem(currentID, II);
                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
                itemChanged.Invoke();
            }
            else if (currentItem.tag != "Help" && II.itemGameObj.name == "4")
            {
                return;
            }
            else if (currentItem.id !=II.id||(currentItem.tag == "Help" || currentItem.tag == "Weapon" || currentItem.tag == "Armor" || currentItem.tag == "Amulet" || currentItem.tag == "Boots"))
            {
                 AddInventoryItem(currentID, II);
                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
            }
            else
            {
                if(II.count+currentItem.count <= 128)
                {
                    II.count += currentItem.count;
                } else
                {
                    AddItem(currentID, data.items[II.id], II.count + currentItem.count-128);
                    II.count = 128;
                }

                if(II.id!=0 && II.id != 3 && II.id != 4) II.itemGameObj.GetComponentInChildren<Text>().text = II.count.ToString();
            }
            currentID = -1;

            movingObj.gameObject.SetActive(false);
        }
        
       


    }
    public void ShowItemInfo()
    {
        
         if (currentItem!=null)
        itemInfoPanel.GetComponent<Text>().text = currentItem.info; 
        
    }
    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObj.GetComponent<RectTransform>().position.z;
        movingObj.position = cam.ScreenToWorldPoint(pos);
    }
    public ItemInventory CopyInventoryItem(ItemInventory old)
    {
        ItemInventory New = new ItemInventory();
        New.id = old.id;
        New.itemGameObj = old.itemGameObj;
        New.count = old.count;
        New.tag = old.tag;
        New.info = old.info;

        return New;
    }
    public void InventoryBTN()
    {

        if (Background.activeSelf == true)
        {
            btnDestroy.SetActive(false);
            Background.SetActive(false);
            itemInfoPanel.SetActive(false);
            
        } else
        {
            btnDestroy.SetActive(true);
            Background.SetActive(true);
            itemInfoPanel.SetActive(true);
            UpdateInventory();
        }

    }
    public void DestroyItem()
    {
        currentItem=null;
        currentID = -1;
        movingObj.gameObject.SetActive(false);
        
    }
}
//класс для переносимой в данный момент шмотки
[System.Serializable]
public class ItemInventory
{  
    //id
    public int id;
    //сама шмотка
    public GameObject itemGameObj;
    //количество
    public int count;
    //тэг
    public string tag;
    //че по шмотке
    public string info;
}
