using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryCell:MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
    public event Action Ejecting;

    [SerializeField] private Text _NameField;
    [SerializeField] private Image _iconField;

     private Transform _draggingParent; //сюда передаю Canvas
     private Transform _originalParent; //сюда передаю контентеую область ScrollView
    

    public void Init(Transform draggingParent)
    {
        
        _draggingParent = draggingParent;
        _originalParent = transform.parent;
    }
    public void Render(IItem item)
    {
        _NameField.text = item.Name;
        _iconField.sprite = item.UIIcon;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent =_draggingParent;
        Debug.Log("Player's Parent: " + transform.parent.name);
    }
    public void OnDrag(PointerEventData eventData)
    {// пока тащу итем  позиция = позиции мышки
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //если позиция внутри инвентаря - кладем в ячейку, иначе выкидываем
        if (In((RectTransform)_originalParent))
            InsertInGrid();
        else Eject();
    }
    private void Eject()
    {
        Ejecting?.Invoke();
    }
    private void InsertInGrid()
    {
        int closestIndex = 0;
        for (int i = 0; i < _originalParent.transform.childCount; i++)
        {
            if (Vector3.Distance(transform.position, _originalParent.GetChild(i).position) < Vector3.Distance(transform.position, _originalParent.GetChild(closestIndex).position))
            {
                closestIndex = i;
            }
        }
        transform.SetParent(_originalParent);
        transform.SetSiblingIndex(closestIndex);
    }

    //проверяю внутри прямоугольника или нет
    private bool In(RectTransform originalParent)
    {
        //return RectTransformUtility.RectangleContainsScreenPoint(originalParent, transform.localPosition, Camera.main);
        return originalParent.rect.Contains(transform.position);

    }
    private void Update()
    {
        //Debug.Log(transform.position);
        //Debug.Log("минимум по x " +_originalParent.GetComponent<RectTransform>().rect.xMin);
        //Debug.Log("максимум по x " + _originalParent.GetComponent<RectTransform>().rect.xMax);
        //Debug.Log("минимум по y " + _originalParent.GetComponent<RectTransform>().rect.yMin);
        //Debug.Log("максимум по y " + _originalParent.GetComponent<RectTransform>().rect.yMax);
        //Debug.Log(_originalParent.GetComponent<RectTransform>().transform.position);
        if (In((RectTransform)_originalParent)) { Debug.Log("внутри"); }
    }
    
}

 