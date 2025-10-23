using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouchGranadeControl : MonoBehaviour
{
    [SerializeField] private GameObject[] granads;

    // Start is called before the first frame update
    void Start()
    {
        ViewGranads(-1, 0);
    }

    public void ViewGranads(int typeGranade, int countCranads)
    {
        for(int i = 0; i < granads.Length; i++)
        {
            granads[i].gameObject.SetActive(false);
        }
        if (typeGranade == 0)
        {
            if (countCranads == 1) granads[0].gameObject.SetActive(true);
            if (countCranads == 2)
            {
                granads[0].gameObject.SetActive(true);
                granads[1].gameObject.SetActive(true);
            }
        }
        if (typeGranade == 1)
        {
            if (countCranads == 1) granads[2].gameObject.SetActive(true);
            if (countCranads == 2)
            {
                granads[2].gameObject.SetActive(true);
                granads[3].gameObject.SetActive(true);
            }
        }
    }
}
