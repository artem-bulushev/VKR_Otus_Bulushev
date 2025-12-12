using Code;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StickSwitching : MonoBehaviour
{
    [SerializeField] private GameObject _bow;
    [SerializeField] private GameObject _sword;
    [SerializeField] private WeaponController _weaponController;
    public float _castRadius = 1f;
    public float _castDistance = 10f;
    public LayerMask _whatToHit; // Слой для проверки

    //void Update()
    //{
    //    RaycastHit[] hits;
    //    // Выпускаем сферу
    //    hits = Physics.SphereCastAll(transform.position, _castRadius, transform.forward, _castDistance, _whatToHit);

    //    if (hits.Length > 0)
    //    {
    //        foreach (RaycastHit hit in hits)
    //        {
    //            Debug.Log("Сфера попала в: " + hit.collider.name + " на расстоянии " + hit.distance);
    //            // Здесь можно обработать, что сфера столкнулась с объектом
    //            _sword.SetActive(true);
    //            _bow.SetActive(false);
    //            _weaponController.IsActive = false;
    //            //return;
    //        }
    //    }
    //    _sword.SetActive(false);
    //    _bow.SetActive(true);
    //    _weaponController.IsActive = true;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy _))
        {
            _sword.SetActive(true);
            _bow.SetActive(false);
            _weaponController.IsActive = false;
            Debug.Log("Меч активен");

            //if (other.CompareTag("Player"))
            //{
            //    // Получаем компонент PlayerHealth и вызываем метод TakeDamage
            //    HP hp = other.GetComponent<HP>();
            //    if (hp != null)
            //    {
            //        hp.CanTakeDamagePlayer(_damage);
            //    }
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy _))
        {
            _sword.SetActive(false);
            _bow.SetActive(true);
            _weaponController.IsActive = true;
            Debug.Log("Лук активен");
        }
    }
}
