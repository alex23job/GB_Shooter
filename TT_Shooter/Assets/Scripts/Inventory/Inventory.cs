using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.FullSerializer;
//using UnityEngine;

[Serializable]
public class Inventory
{
    private List<InventoryUnit> items = new List<InventoryUnit>();

    /// <summary>
    /// Число разных предметов в инвентаре
    /// </summary>
    public int CountUnits { get { return items.Count; } }

    /// <summary>
    /// Добавить предмет(ы) в инвентарь при отсутствии
    /// или увеличить их число на число из newItem
    /// </summary>
    /// <param name="newItem">данные предмета</param>
    public void AddItem(InventoryItem newItem, int count = 1)
    {
        bool isNew = true;
        foreach (InventoryUnit item in items)
        {
            if (item.NameItem == newItem.NameItem)
            {
                item.ChangeCount(count);
                isNew = false;
                break;
            }
        }
        if (isNew) items.Add(new InventoryUnit(newItem, count));
    }

    /// <summary>
    /// Получить список предметов одного типа
    /// </summary>
    /// <param name="type">название типа</param>
    /// <returns>список InventoryUnit</returns>
    public List<InventoryUnit> GetTypeItems(string type)
    {
        List<InventoryUnit> res = new List<InventoryUnit>();
        foreach(InventoryUnit item in items)
        {
            if (item.CmpType(type)) res.Add(item);
        }
        //UnityEngine.Debug.Log($"GetTypeItems for type={type}  count={res.Count}");
        return res;
    }

    /// <summary>
    /// Получить данные предмета
    /// </summary>
    /// <param name="name">название предмета</param>
    /// <returns>null - нет такого, InventoryItem с данными предмета</returns>
    public InventoryItem GetItem(string name)
    {
        InventoryItem res = null;
        foreach(InventoryUnit item in items)
        {
            if (item.NameItem == name) return item.ItemInfo;
        }
        return res;
    }

    /// <summary>
    /// Проверить наличие предмета в инвентаре
    /// </summary>
    /// <param name="name">название предмета</param>
    /// <returns>true - есть, false - нет</returns>
    public bool CheckItem(string name)
    {
        foreach (InventoryUnit item in items)
        {
            if (item.NameItem == name) return true;
        }
        return false;
    }

    /// <summary>
    /// Уменьшить на несколько предметов
    /// </summary>
    /// <param name="name">название предмета</param>
    /// <param name="count">число предметов</param>
    /// <returns>true - уменьшили, false - мало предметов</returns>
    public bool DecrItem(string name, int count)
    {
        foreach (InventoryUnit item in items)
        {
            if (item.NameItem == name)
            {
                if (item.CheckCount(count))
                {
                    item.ChangeCount(-count);
                    return true;
                }
                else return false;
            }
        }
        return false;
    }

    /// <summary>
    /// Получить данные предмета и уменьшить их число на 1
    /// </summary>
    /// <param name="name">название предмета</param>
    /// <returns>null при отсутствии предмета, значение InventoryItem</returns>
    public InventoryItem PopItem(string name)
    {
        foreach (InventoryUnit item in items)
        {
            if (item.NameItem == name)
            {
                if (item.CheckCount(1))
                {
                    item.ChangeCount(-1);
                    return item.ItemInfo;
                }
                else return null;
            }
        }
        return null;
    }
}
