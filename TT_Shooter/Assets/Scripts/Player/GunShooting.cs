using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] private float range = 100f; // Дальность стрельбы
    [SerializeField] private ParticleSystem impactEffect; // Частицы для отображения попадания
    [SerializeField] private Material blackMat;

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
        bool isMetka = true;

        // Получаем направление стрельбы
        Vector3 forward = transform.forward;
        Ray ray = new Ray(transform.position, forward);

        // Выполняем Raycast
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            // Отображаем точку попадания
            //Debug.Log("Попадание в объект: " + hit.transform.name);

            if (hit.transform.CompareTag("Barel"))
            {
                IFireBarel fireBarel = hit.transform.gameObject.GetComponent<IFireBarel>();
                if (fireBarel == null && hit.transform.parent != null) fireBarel = hit.transform.parent.gameObject.GetComponent<IFireBarel>();
                if (fireBarel != null) fireBarel.FireBarel();
            }
            if (hit.transform.CompareTag("Destroytible"))
            {
                HullControl hull = hit.transform.gameObject.GetComponent<HullControl>();
                if (hull != null) hull.ViewInnerObject();
                isMetka = false;
            }

            // Показываем частицы в точке попадания
            if (impactEffect != null)
            {
                ParticleSystem effect = Instantiate(impactEffect);
                effect.transform.position = hit.point;
                effect.Play();
                Destroy(effect.gameObject, 1f);

                if (hit.transform.name != "Cylinder" && isMetka)
                {
                    GameObject sph = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    sph.transform.localScale = new Vector3(0.1f, 0.001f, 0.1f);
                    sph.transform.GetComponent<MeshRenderer>().materials = new Material[1] { blackMat };
                    sph.transform.position = hit.point;
                    sph.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
                    Destroy(sph, 10f);
                }
            }
        }
    }

    public void StopMultiShoot()
    {
        isMultiShoot = false;
    }
}
