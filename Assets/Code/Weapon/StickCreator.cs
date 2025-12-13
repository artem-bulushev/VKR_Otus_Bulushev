using Code.Features.Inventory;
using UnityEngine;

namespace Code
{
    public class StickCreator : MonoBehaviour
    {
        //[SerializeField] private GameObject _stick;
        [SerializeField] private WeaponController _weaponController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                if (other.TryGetComponent(out PlayerInventory inventory))
                {
                    if (inventory.GetIstickUp() == true)
                    {
                        Debug.Log("Палка поднята");
                        //_stick.SetActive(true);
                        _weaponController.IsActive = true;
                    }
                }
            }
        }
    }
}