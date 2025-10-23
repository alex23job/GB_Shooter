using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New ItemData", menuName = "Item Data", order = 51)]
public class InventoryItem : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private string itemType;
    [SerializeField]
    private Sprite itemSprite;
    [SerializeField]
    private int itemEffect;
    [SerializeField]
    private int itemPrice;

    private int itemCount = 0;
    public int ItemCount { get; }

    public bool CheckCount(int count)
    {
        return itemCount >= count;
    }

    public string NameItem { get => itemName; } 
    public Sprite SpriteItem { get => itemSprite; }

    public void ChangeCount(int zn)
    {
        if (zn < 0)
        {
            if (itemCount + zn < 0)
            {
                itemCount = 0;
                return;
            }
        }
        itemCount += zn;
    }
}
