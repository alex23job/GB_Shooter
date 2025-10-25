using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmFire : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private Transform firePoint;
    [SerializeField] private ParticleSystem firePrefab;

    [SerializeField] private bool isFireMulti = false;
    private ParticleSystem firePS = null;

    // Start is called before the first frame update
    void Start()
    {
        //firePS = Instantiate(firePrefab);
        firePS = firePrefab;
        firePS.transform.position = firePoint.position;
        StopFire();
    }

    public void SetModeFire(bool fire)
    {
        isFireMulti = fire;
    }
    
    public void Fire()
    {
        if (firePS != null) firePS.Play();
        if (m_AudioSource != null) m_AudioSource.Play();
        if (!isFireMulti) Invoke("StopFire", 0.3f);
        //print($"arm={transform.name} is fire multi={isFireMulti}");
    }

    public void StopFire()
    {
        if (firePS != null) firePS.Stop();
        if (m_AudioSource != null) m_AudioSource.Stop();
    }

    public void FirePause()
    {
        firePS.Pause();
    }
}
