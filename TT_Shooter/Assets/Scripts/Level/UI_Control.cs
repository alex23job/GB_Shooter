using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPanels;
    [SerializeField] private GameObject hintPanel;
    [SerializeField] private GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        hintPanel.SetActive(false);
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ViewItemPanel(int num, InventoryUnit unit)
    {
        if (num >= 0 && num < itemPanels.Length)
        {
            Image imgItem = itemPanels[num].transform.GetChild(0).GetComponent<Image>();
            Text txtCount = itemPanels[num].transform.GetChild(1).GetComponent<Text>();
            Text txtName = itemPanels[num].transform.GetChild(2).GetComponent<Text>();

            imgItem.sprite = unit.SpriteItem;
            txtCount.text = unit.ItemCount.ToString();
            txtName.text = unit.NameItem;
        }
    }

    public void ViewHint(string hint)
    {
        if (hint == "") hintPanel.SetActive(false);
        else
        {
            Text txtHint = hintPanel.transform.GetChild(0).GetComponent<Text>();
            if (txtHint != null) txtHint.text = hint;
            hintPanel.SetActive(true);
        }
    }

    public void ViewEndPanel()
    {
        endPanel.SetActive(true);
    }
}
