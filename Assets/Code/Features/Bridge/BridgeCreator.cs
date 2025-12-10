using System;
using Code.Features.Inventory;
using UnityEngine;

namespace Code.Features.Bridge
{
    public class BridgeCreator : MonoBehaviour
    {
        [SerializeField] private GameObject _bridgePrefab;
        [SerializeField] private Transform _spawnPoints;
        private GameObject _bridgeInstance;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.TryGetComponent(out PlayerInventory inventory))
                {
                    if (inventory.GetIsBridgeUp() == true)
                    {
                        //_bridge.SetActive(true);
                        if (_bridgeInstance == null)
                        {
                            _bridgeInstance = Instantiate(_bridgePrefab, _spawnPoints);
                        }
                        _bridgeInstance.SetActive(true);
                    }
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (_bridgeInstance != null)
                {
                    _bridgeInstance.SetActive(false);
                    Destroy(_bridgeInstance);
                    _bridgeInstance = null;
                }
            }
        }
    }
}