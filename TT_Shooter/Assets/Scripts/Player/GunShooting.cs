using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private float range = 100f; // Дальность стрельбы
    public LineRenderer lineRenderer; // Линия трассировки траектории полета
    [SerializeField] private ParticleSystem impactEffect; // Частицы для отображения попадания

    void Update()
    {
        // Проверяем нажатие левой кнопки мыши
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Shoot();
        //}
    }

    public void Shoot()
    {
        // Получаем направление стрельбы
        Vector3 forward = transform.forward;
        Ray ray = new Ray(transform.position, forward);

        // Выполняем Raycast
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            // Отображаем точку попадания
            Debug.Log("Попадание в объект: " + hit.transform.name);

            // Показываем частицы в точке попадания
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

        // Визуализируем трассу полёта
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
