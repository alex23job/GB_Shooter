using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    [SerializeField] private InventoryItem itemData;
    [SerializeField] private UI_Control ui_Control;
    [SerializeField] private float speedRotation = 15f; 

    public InventoryItem Item {  get { return itemData; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y += Time.deltaTime * speedRotation;
        transform.rotation = Quaternion.Euler(rot);
    }

    private void OnTriggerEnter(Collider other)
    {
        //print($"InventoryObject OnTriggerEnter name={other.name} tag={other.tag}");
        if (other.CompareTag("Player"))
        {
            if (ui_Control != null) ui_Control.ViewHint($"Нажмите 'E', чтобы взять {itemData.NameItem}");
            PlayerControl playerControl = other.gameObject.GetComponent<PlayerControl>();
            if (playerControl != null)
            {
                playerControl.SetCurrentItem(gameObject.GetComponent<InventoryObject>());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl playerControl = other.gameObject.GetComponent<PlayerControl>();
            if (playerControl != null)
            {
                playerControl.SetCurrentItem(null);
            }
        }
    }
}
