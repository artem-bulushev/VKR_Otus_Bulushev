using UnityEngine;

namespace Code
{
    public class StickAttack : MonoBehaviour
    {
        [SerializeField] private float _damage = 10.0f;
        //[SerializeField] private HealthEnemy _healthEnemy;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (gameObject.GetComponentInParent<Animator>() != null)
                {
                    gameObject.GetComponentInParent<Animator>().SetTrigger("StickAttack_1");
                }
                //_healthEnemy.CanTakeDamageEnemy(_damage);
                //Debug.Log("прошла атака");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HealthEnemy healthEnemy))
            {
                Debug.Log("идет атака");
                healthEnemy.CanTakeDamageEnemy(_damage);
                Debug.Log("прошла атака");
            }
        }

        //private void OnCollisionEnter(Collision other)
        //{
        //    if (other.collider.TryGetComponent(out HealthEnemy healthEnemy))
        //    {
        //        if (healthEnemy.CanTakeDamageEnemy(_damage))
        //        {
        //            return;
        //        }
        //    }
        //}
    }
}