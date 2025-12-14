using System;
using UnityEngine;

namespace Code
{
  public class StickTriggerObserver : MonoBehaviour
  {
    public event Action<Collider> OnTriggerEnterEvent;
    [SerializeField] private CapsuleCollider _collider;

    private void Awake()
    {
      _collider.enabled = false;   
    }

    private void OnTriggerEnter(Collider other)
    {
      OnTriggerEnterEvent?.Invoke(other);   
    }
    
    public void SetActiveCollider(bool value)
    {
      _collider.enabled = value;   
    }
  }
}