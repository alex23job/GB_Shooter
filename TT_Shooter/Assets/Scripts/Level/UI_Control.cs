using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPanels;
    [SerializeField] private GameObject hintPanel;

    // Start is called before the first frame update
    void Start()
    {
        hintPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ViewItemPanel(int num, InventoryItem item)
    {
        if (num >= 0 && num < itemPanels.Length)
        {
            Image imgItem = itemPanels[num].transform.GetChild(0).GetComponent<Image>();
            Text txtCount = itemPanels[num].transform.GetChild(1).GetComponent<Text>();
            Text txtName = itemPanels[num].transform.GetChild(2).GetComponent<Text>();

            imgItem.sprite = item.SpriteItem;
            txtCount.text = item.ItemCount.ToString();
            txtName.text = item.NameItem;
        }
    }

    public void ViewHint(string hint)
    {
        Text txtHint = hintPanel.transform.GetChild(0).GetComponent<Text>();
        if (txtHint != null) txtHint.text = hint;
        hintPanel.SetActive(true);
    }
}
