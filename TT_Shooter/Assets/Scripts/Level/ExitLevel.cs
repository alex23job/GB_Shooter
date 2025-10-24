using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] private LevelControl levelControl;
    [SerializeField] private bool isDoorBody = false;
    [SerializeField] private float speedUP = 10f;

    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen && isDoorBody)
        {
            Vector3 pos = transform.position;
            pos.y += speedUP * Time.deltaTime;
            transform.position = pos;
            if (pos.y > 4.9f) isOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (levelControl != null)
        {
            if ((levelControl.IsKey) && (other.CompareTag("Player"))) levelControl.ViewEndPanel(); 
        }
    }

    public void DoorOpen()
    {
        isOpen = true;
    }
}
