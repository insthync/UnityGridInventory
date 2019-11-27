using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlot : MonoBehaviour
{
    public int x;
    public int y;
    public int index;
    public InventoryGrid grid;

    private void Start()
    {
        var tempTransform = transform as RectTransform;
        tempTransform.pivot = new Vector2(0, 1);
        tempTransform.anchorMin = new Vector2(0, 1);
        tempTransform.anchorMax = new Vector2(0, 1);
        tempTransform.sizeDelta = new Vector2(grid.slotSizeX, grid.slotSizeY);
        tempTransform.anchoredPosition = new Vector2(
            grid.marginX + (grid.slotSizeX * x) + (grid.spaceX * x),
            -(grid.marginY + (grid.slotSizeY * y) + (grid.spaceY * y)));
    }

    public void OnClick()
    {
        grid.OnClick(x, y);
    }
}
