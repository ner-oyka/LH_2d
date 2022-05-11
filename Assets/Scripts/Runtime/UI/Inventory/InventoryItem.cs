using Game.Common.UI;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public uint widthCells;
    public uint heightCells;


    public int uniqueId;

    public Sprite sprite;

    public BaseInventoryCanvas inventoryController;

    private RectTransform rectTransform;

    private Transform saveGridTransform;
    private Vector2 saveOriginalPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void GenerateItem(float cellSize)
    {
        rectTransform.sizeDelta = new Vector2 (widthCells * cellSize, heightCells * cellSize);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        saveGridTransform = rectTransform.parent;
        saveOriginalPos = rectTransform.anchoredPosition;

        inventoryController.FillItem(saveOriginalPos, widthCells, heightCells);

        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;
        rectTransform.SetParent(rectTransform.parent.parent);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(saveGridTransform);
        Vector2 newPos;
        bool result = inventoryController.FindRectUnlocked(rectTransform.anchoredPosition, widthCells, heightCells, out newPos);
        if (result)
        {
            rectTransform.anchoredPosition = newPos;
            inventoryController.FillItem(saveOriginalPos, widthCells, heightCells, newPos);
        }
        else
        {
            rectTransform.anchoredPosition = saveOriginalPos;
            inventoryController.FillItem(saveOriginalPos, widthCells, heightCells, saveOriginalPos);
        }
    }
}
