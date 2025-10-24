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

    private InventoryObject currentItem = null;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        tossGranade = GetComponent<TossGranade>();
        granadeControl = GetComponentInChildren<PouchGranadeControl>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
            tossGranade.SetCurrentArmNumber(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tossGranade.SetCurrentCranade(0);
            granadeControl.ViewGranads(0, 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            tossGranade.SetCurrentCranade(1);
            granadeControl.ViewGranads(1, 2);
        }
    }

    public void ChangeHP(int value)
    {

    }

    public void OnArmNextClick(int num)
    {

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
            if ((currentItem.gameObject.name == "BonusKey") && (levelControl != null)) levelControl.TakeKey();
            Destroy(currentItem.gameObject);
        }
    }
}
