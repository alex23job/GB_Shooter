using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullControl : MonoBehaviour
{
    [SerializeField] private GameObject innerObject;
    // Start is called before the first frame update
    void Start()
    {
        innerObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ViewInnerObject()
    {
        innerObject.SetActive(true);
        Destroy(gameObject);
    }
}
