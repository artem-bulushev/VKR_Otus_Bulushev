using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Code
{
    public class EnemyAttack : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonController _))
            {
                Attack();
                Debug.Log("Противник атакует");
            }
        }

        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.TryGetComponent(out FirstPersonController _))
        //    {
        //        Debug.Log("Противник не атакует");
        //    }
        //}

        private void Attack()
        {
            if (gameObject.GetComponent<Animator>() != null)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Attack_1");
            }
        }
    }
}