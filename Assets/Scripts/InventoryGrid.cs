using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    public UISlot slotPrefab;
    public RectTransform slotContainer;
    public UIItem itemPrefab;
    public RectTransform itemContainer;
    public int sizeX;
    public int sizeY;
    public int spaceX;
    public int spaceY;
    public int marginX;
    public int marginY;

    private void Start()
    {
        UISlot newSlot;
        int index = 0;
        for (int y = 0; y < InventoryManager.Singleton.sizeY; ++y)
        {
            for (int x = 0; x < InventoryManager.Singleton.sizeX; ++x)
            {
                newSlot = Instantiate(slotPrefab, slotContainer);
                newSlot.x = x;
                newSlot.y = y;
                newSlot.index = index++;
                newSlot.grid = this;
            }
        }
    }

    public void OnClick(int x, int y)
    {

    }
}
