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
    /// ����� ������ ��������� � ���������
    /// </summary>
    public int CountUnits { get { return items.Count; } }

    /// <summary>
    /// �������� �������(�) � ��������� ��� ����������
    /// ��� ��������� �� ����� �� ����� �� newItem
    /// </summary>
    /// <param name="newItem">������ ��������</param>
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
    /// �������� ������ ��������� ������ ����
    /// </summary>
    /// <param name="type">�������� ����</param>
    /// <returns>������ InventoryUnit</returns>
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
    /// �������� ������ ��������
    /// </summary>
    /// <param name="name">�������� ��������</param>
    /// <returns>null - ��� ������, InventoryItem � ������� ��������</returns>
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
    /// ��������� ������� �������� � ���������
    /// </summary>
    /// <param name="name">�������� ��������</param>
    /// <returns>true - ����, false - ���</returns>
    public bool CheckItem(string name)
    {
        foreach (InventoryUnit item in items)
        {
            if (item.NameItem == name) return true;
        }
        return false;
    }

    /// <summary>
    /// ��������� �� ��������� ���������
    /// </summary>
    /// <param name="name">�������� ��������</param>
    /// <param name="count">����� ���������</param>
    /// <returns>true - ���������, false - ���� ���������</returns>
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
    /// �������� ������ �������� � ��������� �� ����� �� 1
    /// </summary>
    /// <param name="name">�������� ��������</param>
    /// <returns>null ��� ���������� ��������, �������� InventoryItem</returns>
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
