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
    public int gridSizeX = 8;
    public int gridSizeY = 4;
    public int slotSizeX = 40;
    public int slotSizeY = 40;
    public int spaceX = 2;
    public int spaceY = 2;
    public int marginX = 2;
    public int marginY = 2;

    [Header("Test tools")]
    public Item addingItem;
    public bool addItem;

    private void Start()
    {
        UISlot newSlot;
        int index = 0;
        for (int y = 0; y < gridSizeX; ++y)
        {
            for (int x = 0; x < gridSizeY; ++x)
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

    private void Update()
    {
        if (addItem)
        {
            addItem = false;
            AddItem(addingItem);
        }
    }

    public void AddItem(Item item)
    {
        int x = 0;
        int y = 0;
        if (FindEmptySlot(item, out x, out y))
        {
            UIItem newItem = Instantiate(itemPrefab, itemContainer);
            newItem.x = x;
            newItem.y = y;
            newItem.item = item;
            newItem.grid = this;
        }
        else
        {
            Debug.LogError("No empty slot");
        }
    }

    public bool FindEmptySlot(Item item, out int x, out int y)
    {
        x = -1;
        y = -1;
        return false;
    }
}
