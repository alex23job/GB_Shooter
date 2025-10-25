using System;
using UnityEngine;

[Serializable]
public class InventoryUnit
{
    private InventoryItem item;
    private int unitCount;
    public int ItemCount { get => unitCount; }

    public string NameItem { get => item.NameItem; }
    public Sprite SpriteItem { get => item.SpriteItem; }
    public int ItemEffect { get => item.ItemEffect; }
    public string ItemType { get => item.ItemType; }
    public int Price { get => item.Price; }

    public InventoryUnit() { }
    public InventoryUnit(InventoryItem item, int count = 1)
    {
        this.item = item;
        unitCount = count;
    }

    public bool CheckCount(int count)
    {
        return unitCount >= count;
    }
    public void ChangeCount(int zn)
    {
        if (zn < 0)
        {
            if (unitCount + zn < 0)
            {
                unitCount = 0;
                return;
            }
        }
        unitCount += zn;
    }

    public bool CmpType(string type)
    {
        return item.ItemType == type;
    }

    public InventoryItem ItemInfo { get => item; }
}