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

    public string NameItem { get => itemName; } 
    public Sprite SpriteItem { get => itemSprite; }
    public int ItemEffect { get => itemEffect; }
    public string ItemType { get => itemType; }
    public int Price { get => itemPrice; }
}
