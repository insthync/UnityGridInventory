using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public int x;
    public int y;
    public Item item;
    public Image icon;
    public InventoryGrid grid;

    private void Start()
    {
        var tempTransform = transform as RectTransform;
        tempTransform.pivot = new Vector2(0, 1);
        tempTransform.anchorMin = new Vector2(0, 1);
        tempTransform.anchorMax = new Vector2(0, 1);
        tempTransform.sizeDelta = new Vector2(
            (grid.slotSizeX * item.sizeX) + ((grid.spaceX - 1) * item.sizeX), 
            (grid.slotSizeY * item.sizeY) + ((grid.spaceY - 1) * item.sizeY));
        tempTransform.anchoredPosition = new Vector2(
            grid.marginX + (grid.slotSizeX * x) + (grid.spaceX * x),
            -(grid.marginY + (grid.slotSizeY * y) + (grid.spaceY * y)));
        icon.color = item.color;
    }
}
