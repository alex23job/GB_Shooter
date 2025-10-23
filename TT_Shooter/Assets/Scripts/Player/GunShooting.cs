using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private float range = 100f; // Дальность стрельбы
    [SerializeField] private ParticleSystem impactEffect; // Частицы для отображения попадания

    private bool isMultiShoot = false;
    private float timer = 0.25f;

    void Update()
    {
        // Проверяем нажатие левой кнопки мыши
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
