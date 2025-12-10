using UnityEngine;

namespace Code.Features.Inventory
{
  public class PlayerInventory : MonoBehaviour
  {
    private bool _isBridgeUp;

    public void SetBridge(bool value)
    {
      _isBridgeUp =  value;
    }

    public bool GetIsBridgeUp()
    {
      return _isBridgeUp;
    }
  }
}