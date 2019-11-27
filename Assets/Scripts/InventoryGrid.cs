using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    public UISlot slotPrefab;
    public RectTransform container;
    public int sizeX;
    public int sizeY;
    public int spaceX;
    public int spaceY;
    public int marginX;
    public int marginY;

    private void Start()
    {
        UISlot newSlot;
        RectTransform tempTransform;
        int index = 0;
        for (int y = 0; y < InventoryManager.Singleton.sizeY; ++y)
        {
            for (int x = 0; x < InventoryManager.Singleton.sizeX; ++x)
            {
                newSlot = Instantiate(slotPrefab, container);
                newSlot.x = x;
                newSlot.y = y;
                newSlot.index = index++;
                tempTransform = newSlot.transform as RectTransform;
                tempTransform.pivot = new Vector2(0, 1);
                tempTransform.anchorMin = new Vector2(0, 1);
                tempTransform.anchorMax = new Vector2(0, 1);
                tempTransform.sizeDelta = new Vector2(sizeX, sizeY);
                tempTransform.anchoredPosition = new Vector2(
                    marginX + (sizeX * x) + (spaceX * x),
                    -(marginY + (sizeY * y) + (spaceY * y)));
            }
        }
    }
}
