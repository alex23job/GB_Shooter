using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private float range = 100f; // ��������� ��������
    public LineRenderer lineRenderer; // ����� ����������� ���������� ������
    [SerializeField] private ParticleSystem impactEffect; // ������� ��� ����������� ���������

    void Update()
    {
        // ��������� ������� ����� ������ ����
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Shoot();
        //}
    }

    public void Shoot()
    {
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
                impactEffect.transform.position = hit.point;
                impactEffect.Play();

                //GameObject sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //sph.transform.localScale = new Vector3(0.1f, 0.1f, 0.01f);
                //sph.transform.position = hit.point;
                //Destroy( sph , 2f);
            }
        }

        // ������������� ������ �����
        DrawTrajectory(forward);
    }

    void DrawTrajectory(Vector3 direction)
    {
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + direction * range);
        }
    }
}
