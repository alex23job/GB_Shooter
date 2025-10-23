using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBarel : MonoBehaviour, IFireBarel
{
    [SerializeField] private ParticleSystem oilFire;

    // Start is called before the first frame update
    void Start()
    {
        oilFire.Stop();        
    }

    public void FireBarel()
    {
        oilFire.Play();
    }

    public void OnFire(Vector3 granatePosition)
    {
        Vector3 direction = transform.position - granatePosition;
        if (direction.magnitude < 3)
        {
            oilFire.Play();
        }
    }
}

public interface IFireBarel
{
    public void OnFire(Vector3 position);
    public void FireBarel();
}
