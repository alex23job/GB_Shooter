using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] private LevelControl levelControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (levelControl != null)
        {
            if ((levelControl.IsKey) && (other.CompareTag("Player"))) levelControl.ViewEndPanel(); 
        }
    }
}
