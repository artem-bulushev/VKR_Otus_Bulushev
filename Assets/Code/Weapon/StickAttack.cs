using System;
using UnityEngine;

namespace Code
{
  public class StickAttack : MonoBehaviour
  {
    [SerializeField] private float _damage = 10.0f;
    [SerializeField] private Animator _animator;

    [Header("Melee Settings")]
    [SerializeField] private float _attackRange = 1.5f;   // как далеко от себя
    [SerializeField] private float _attackRadius = 0.7f;  // радиус удара
    [SerializeField] private LayerMask _enemyLayer;       // слой врагов

    private void Update()
    {
      if (Input.GetButtonDown("Fire1"))
      {
        _animator.SetTrigger("StickAttack_1");
      }
    }

    /// Этот метод вызывается ивентом из анимации удара
    private void StickAttackAnim()
    {
      // Точка центра «виртуального» коллайдера перед персонажем
      Vector3 center = transform.position + transform.forward * _attackRange;

      // Находим все коллайдеры врагов в радиусе
      Collider[] hits = Physics.OverlapSphere(center, _attackRadius, _enemyLayer);

      for (int i = 0; i < hits.Length; i++)
      {
        Collider hit = hits[i];

        // Пытаемся найти компонент здоровья
        if (hit.TryGetComponent(out HealthEnemy health))
        {
          health.CanTakeDamageEnemy(_damage);
        }
      }
    }

    // Не обязательно, но удобно для отладки — видеть зону удара в редакторе
    private void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
      Vector3 center = transform.position + transform.forward * _attackRange;
      Gizmos.DrawWireSphere(center, _attackRadius);
    }
  }
}