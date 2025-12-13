using Code.Features.Inventory;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Code
{
    public class ResourcesGame : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //if (other.TryGetComponent(out FirstPersonController player))
            //{
            //    Destroy(gameObject);
            //    Debug.Log($"{gameObject.name} поднят");
            //}

            if(other.TryGetComponent(out PlayerInventory playerInventory))
            {
                Destroy(gameObject);
                Debug.Log($"{gameObject.name} поднят");
                playerInventory.SetStick(true);
            }
        }
    }
}
