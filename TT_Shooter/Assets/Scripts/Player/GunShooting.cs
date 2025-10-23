using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private float range = 100f; // ��������� ��������
    [SerializeField] private ParticleSystem impactEffect; // ������� ��� ����������� ���������

    private bool isMultiShoot = false;
    private float timer = 0.25f;

    void Update()
    {
        // ��������� ������� ����� ������ ����
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Shoot();
        //}
        if (isMultiShoot)
        {
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                timer = 0.25f;
                Shoot(true);
            }
        }
    }

    public void Shoot(bool isMulti = false)
    {
        if (isMulti) isMultiShoot = true;

        // �������� ����������� ��������
        Vector3 forward = transform.forward;
        Ray ray = new Ray(transform.position, forward);

        // ��������� Raycast
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            // ���������� ����� ���������
            Debug.Log("��������� � ������: " + hit.transform.name);

            // ���������� ������� � ����� ���������
            if (impactEffect != null)
            {
                ParticleSystem effect = Instantiate(impactEffect);
                effect.transform.position = hit.point;
                effect.Play();
                Destroy(effect.gameObject, 1f);

                //GameObject sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //sph.transform.localScale = new Vector3(0.1f, 0.1f, 0.01f);
                //sph.transform.position = hit.point;
                //Destroy( sph , 2f);
            }
        }
    }

    public void StopMultiShoot()
    {
        isMultiShoot = false;
    }
}
