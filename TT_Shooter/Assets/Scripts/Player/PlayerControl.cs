using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(TossGranade))]
public class PlayerControl : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private TossGranade tossGranade;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        tossGranade = GetComponent<TossGranade>();
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
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            tossGranade.SetCurrentCranade(1);
        }
    }

    public void ChangeHP(int value)
    {

    }
}
