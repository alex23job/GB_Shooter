using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(TossGranade))]
public class PlayerControl : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private TossGranade tossGranade;
    private PouchGranadeControl granadeControl;
    [SerializeField] private UI_Control ui_Control;
    [SerializeField] private LevelControl levelControl;
    [SerializeField] private InventoryItem[] items;

    private InventoryObject currentItem = null;

    private Inventory inventory = null;
    private List<InventoryUnit> armUnits = null;
    private List<InventoryUnit> granadeUnits = null;
    private int currentArmNumber = 0;
    private int currentGranadeNumber = 0;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        tossGranade = GetComponent<TossGranade>();
        granadeControl = GetComponentInChildren<PouchGranadeControl>();
    }
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        inventory.AddItem(items[0]);
        inventory.AddItem(items[1]);
        armUnits = inventory.GetTypeItems("Arm");
        granadeUnits = inventory.GetTypeItems("Granade");
        ui_Control.ViewItemPanel(0, armUnits[0]);
        ui_Control.ViewItemPanel(1, granadeUnits[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            tossGranade.SetCurrentArmNumber(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inventory.CheckItem("Schmeiser"))
            {
                tossGranade.SetCurrentArmNumber(1);
                currentArmNumber = 1;
                ui_Control.ViewItemPanel(0, armUnits[currentArmNumber]);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tossGranade.SetCurrentCranade(0);
            granadeControl.ViewGranads(0, 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (inventory.CheckItem("Granade"))
            {
                tossGranade.SetCurrentCranade(1);
                granadeControl.ViewGranads(1, 2);
                ui_Control.ViewItemPanel(1, granadeUnits[currentGranadeNumber]);
            }
        }
    }

    public void ChangeHP(int value)
    {

    }

    public void OnArmNextClick(int num)
    {
        if (num == 0)
        {
            currentArmNumber++;
            currentArmNumber %= armUnits.Count;
            ui_Control.ViewItemPanel(0, armUnits[currentArmNumber]);
            tossGranade.SetCurrentArmNumber(currentArmNumber);
        }
        if (num == 1)
        {
            currentGranadeNumber++;
            currentGranadeNumber %= granadeUnits.Count;
            tossGranade.SetCurrentCranade(currentGranadeNumber);
            granadeControl.ViewGranads(currentGranadeNumber, granadeUnits[currentGranadeNumber].ItemCount);
            ui_Control.ViewItemPanel(1, granadeUnits[currentGranadeNumber]);
        }
    }

    public void SetCurrentItem(InventoryObject item)
    {
        currentItem = item;
    }

    public void TakeItem()
    {
        ui_Control.ViewHint("");
        if (currentItem != null)
        {
            inventory.AddItem(currentItem.Item);
            if ((currentItem.gameObject.name == "BonusKey") && (levelControl != null)) levelControl.TakeKey();
            if (currentItem.Item.ItemType == "Arm")
            {
                armUnits = inventory.GetTypeItems(currentItem.Item.ItemType);
                ui_Control.ViewItemPanel(0, armUnits[currentArmNumber]);
            }
            if (currentItem.Item.ItemType == "Granade")
            {
                granadeUnits = inventory.GetTypeItems(currentItem.Item.ItemType);
                ui_Control.ViewItemPanel(1, granadeUnits[currentGranadeNumber]);
            }
            Destroy(currentItem.gameObject);
        }
    }
}
