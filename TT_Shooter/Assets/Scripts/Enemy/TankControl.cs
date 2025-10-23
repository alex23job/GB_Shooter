using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour, IFireBarel
{
    [SerializeField] private ParticleSystem oilFire;
    [SerializeField] private GameObject cabine;
    [SerializeField] private float cabineSpeed = 5f;
    
    private Rigidbody cabineRb;

    private void Awake()
    {
        cabineRb = cabine.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        oilFire.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFire(Vector3 granatePosition)
    {
        Vector3 direction = cabine.transform.position - granatePosition;
        if (direction.magnitude < 3)
        {
            oilFire.Play();
            print("oilFire.Play ? (OnFire)");
        }
    }

    public void CabineMove(Vector3 granatePosition)
    {
        Vector3 direction = cabine.transform.position - granatePosition;
        if (direction.magnitude < 2)
        {
            cabineRb.isKinematic = false;
            cabineRb.AddForce(direction * cabineSpeed, ForceMode.Impulse);
        }
    }

    public void FireBarel()
    {
        print("oilFire.Play ? (FireBarel)");
        oilFire.Play();
    }
}
