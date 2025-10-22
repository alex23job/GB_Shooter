using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeControl : MonoBehaviour
{
    [SerializeField] private ParticleSystem effectBuff;
    [SerializeField] private bool isPlayerGranade = false;

    private Animator anim;
    private Rigidbody rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetParams(Vector3 direction, float speed = 7f)
    {
        //Quaternion rotation = Quaternion.Euler(0, 45f, 0);
        //Vector3 rotatedVector = rotation * direction;
        //print($"rotatedVector={rotatedVector}");
        rb.isKinematic = false;
        rb.AddForce(direction * speed, ForceMode.Impulse);
        //rb.AddForce(rotatedVector * speed, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        int mask = 1 << LayerMask.NameToLayer("Player");
        mask |= 1 << LayerMask.NameToLayer("Granade");
        //print($"mask={mask} other={other.name} other.gameObject.layer={other.gameObject.layer}  &&={(1 << other.gameObject.layer) & mask}");
        if ((((1 << other.gameObject.layer) & mask) == 0) && (false == isPlayerGranade))
        {
            ParticleSystem effect = Instantiate(effectBuff, transform.position, Quaternion.Euler(new Vector3(-90f, 0, 0)));
            effect.Play();
            Destroy(effect.gameObject, 2f);
            if (false == isPlayerGranade) Destroy(gameObject, 0.1f);
        }
    }
}
