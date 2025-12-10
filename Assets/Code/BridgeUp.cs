using Code.Features.Inventory;
using UnityEngine;

namespace Code
{
    public class BridgeUp : MonoBehaviour
    {
        public Bridge _bridge;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerInventory playerInventory))
            {
                Destroy(gameObject);
                Debug.Log($"{gameObject.name} поднят");
                playerInventory.SetBridge(true);
                _bridge.RaiseBridge();
            }
        }
    }
}
