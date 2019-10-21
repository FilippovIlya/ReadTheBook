using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    //список существующих вещей
    public List<Item> items = new List<Item>();

}
[System.Serializable]
public class Item
{
    //номер
    public int id;
    //имя
    public string name;
    //картинка
    public Sprite img;
    //тэг
    public string tag;
    public string info;
}