using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject door;
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
        if (other.CompareTag("Player"))
        {
            if (levelControl != null)
            {
                if (levelControl.IsKey)
                {
                    if (door != null)
                    {
                        door.GetComponent<ExitLevel>().DoorOpen();
                    }
                }
                else
                {
                    levelControl.ViewHintPanel($"Найдите ключ чтобы открыть дверь !");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (levelControl != null)
            {
                levelControl.ViewHintPanel("");
            }
        }
    }
}
