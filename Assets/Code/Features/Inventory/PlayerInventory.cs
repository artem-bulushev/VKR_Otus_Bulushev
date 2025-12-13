using UnityEngine;

namespace Code.Features.Inventory
{
  public class PlayerInventory : MonoBehaviour
  {
    private bool _isBridgeUp;
        private bool _isStickDown;

    public void SetBridge(bool value)
    {
      _isBridgeUp =  value;
    }

    public bool GetIsBridgeUp()
    {
      return _isBridgeUp;
    }
        public void SetStick(bool value)
        {
            _isStickDown = value;
        }

        public bool GetIstickUp()
        {
            return _isStickDown;
        }

    }
}