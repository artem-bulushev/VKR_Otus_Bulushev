using System;
using Code.Features.Inventory;
using UnityEngine;

namespace Code.Features.Bridge
{
  public class BridgeCreator : MonoBehaviour
  {
    [SerializeField] private GameObject _bridge;

    private void OnTriggerEnter(Collider other)
    {
      if (other.tag == "Player")
      {
        if(other.TryGetComponent(out PlayerInventory inventory))
        {
          if (inventory.GetIsBridgeUp() == true)
          {
            _bridge.SetActive(true);
          }
        }
      }
    }
  }
}