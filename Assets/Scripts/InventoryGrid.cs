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

    private readonly Dictionary<string, UIItem> uiItems = new Dictionary<string, UIItem>();

    private void Start()
    {
        UISlot newSlot;
        int index = 0;
        for (int y = 0; y < gridSizeY; ++y)
        {
            for (int x = 0; x < gridSizeX; ++x)
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
        RemoveItem(x, y);
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
        if (FindEmptySlots(item, out x, out y))
        {
            UIItem newItem = Instantiate(itemPrefab, itemContainer);
            newItem.x = x;
            newItem.y = y;
            newItem.item = item;
            newItem.grid = this;
            for (int rY = y; rY < y + item.sizeY; ++rY)
            {
                for (int rX = x; rX < x + item.sizeX; ++rX)
                {
                    uiItems[rX + "_" + rY] = newItem;
                }
            }
        }
        else
        {
            Debug.LogError("No empty slot");
        }
    }

    public bool FindEmptySlots(Item item, out int slotX, out int slotY)
    {
        slotX = -1;
        slotY = -1;
        for (int rY = 0; rY < gridSizeY; ++rY)
        {
            for (int rX = 0; rX < gridSizeX; ++rX)
            {
                if (IsEnoughSlots(item, rX, rY))
                {
                    slotX = rX;
                    slotY = rY;
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsEnoughSlots(Item item, int slotX, int slotY)
    {
        if (slotY + item.sizeY > gridSizeY ||
            slotX + item.sizeX > gridSizeX)
            return false;

        for (int rY = slotY; rY < slotY + item.sizeY; ++rY)
        {
            for (int rX = slotX; rX < slotX + item.sizeX; ++rX)
            {
                if (uiItems.ContainsKey(rX + "_" + rY))
                    return false;
            }
        }
        return true;
    }

    public bool RemoveItem(int slotX, int slotY)
    {
        if (!uiItems.ContainsKey(slotX + "_" + slotY))
            return false;
        UIItem removingItem = uiItems[slotX + "_" + slotY];
        for (int rY = removingItem.y; rY < removingItem.y + removingItem.item.sizeY; ++rY)
        {
            for (int rX = removingItem.x; rX < removingItem.x + removingItem.item.sizeX; ++rX)
            {
                uiItems.Remove(rX + "_" + rY);
            }
        }
        Destroy(removingItem.gameObject);
        return true;
    }
}
