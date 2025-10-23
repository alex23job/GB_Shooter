using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossGranade : MonoBehaviour
{
    [SerializeField] private GameObject prefabGranade1;
    [SerializeField] private GameObject prefabGranade2b;

    [SerializeField] private GameObject[] armLeft;
    [SerializeField] private GameObject[] armRight;

    private int currentArmNumber = 0;
    private bool isArmRight = true;
    private int currentGranadeNumber = 0;
    private Vector3 direction = Vector3.up;

    public int CurrentArmNumber {  get => currentArmNumber; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentArm(int number)
    {
        currentArmNumber = number;
    }

    public void SetCurrentCranade(int number)
    {
        currentGranadeNumber = number;
    }

    public void OnFire()
    {
        if (armRight[currentArmNumber].activeSelf)
        {
            armRight[currentArmNumber].GetComponent<ArmFire>().Fire();
        }
    }

    public void OnFireStop()
    {
        if (armRight[currentArmNumber].activeSelf)
        {
            armRight[currentArmNumber].GetComponent<ArmFire>().StopFire();
        }

    }

    public void OnToss()
    {
        direction = transform.forward;
        armLeft[currentArmNumber].SetActive(true);
        armRight[currentArmNumber].SetActive(false);
        Invoke("BeginToss", 0.16f);
    }

    private void BeginToss()
    {
        armRight[2 + currentGranadeNumber].SetActive(true);
        Invoke("EndToss", 1.6f);
    }

    private void EndToss()
    {
        armRight[2 + currentGranadeNumber].SetActive(false);
        GameObject granade = null;
        if (currentGranadeNumber == 0) granade = Instantiate(prefabGranade1);
        if (currentGranadeNumber == 1) granade = Instantiate(prefabGranade2b);
        if (granade != null)
        {
            granade.transform.position = armRight[2 + currentGranadeNumber].transform.position;
            //Vector3 direction = transform.forward;
            direction.y = 1;
            //print($"forward={transform.forward}  dir={direction}");
            granade.GetComponent<GranadeControl>().SetParams(direction);
        }
        Invoke("ArmToRight", 1f);
    }

    private void ArmToRight()
    {
        armLeft[currentArmNumber].SetActive(false);
        armRight[currentArmNumber].SetActive(true);
    }

    public void SetCurrentArmNumber(int zn)
    {
        if ((zn >= 0) && (zn < armLeft.Length))
        {
            if (isArmRight)
            {
                armRight[currentArmNumber].SetActive(false);
                currentArmNumber = zn;
                armRight[currentArmNumber].SetActive(true);
            }
            else
            {
                armLeft[currentArmNumber].SetActive(false);
                currentArmNumber = zn;
                armLeft[currentArmNumber].SetActive(true);
            }
        }
    }
}
