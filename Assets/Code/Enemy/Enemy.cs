using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

namespace Code
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _damage = 1.0f;
        //public int EnemySpeed = 3;
        private Transform _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        }

        private void Update()
        {
            if (_agent.enabled == true)
            {
                _agent.SetDestination(_player.position);
            }
        }
        //public void DeactivateEnemy()
        //{
        //    _agent.speed = 0;
        //}
        //public void ActivateEnemy()
        //{
        //    _agent.speed = EnemySpeed;
        //}

        //private void OnCollisionEnter(Collision other)
        //{
        //    if (other.collider.TryGetComponent(out FirstPersonController _))
        //    {
        //        Attack();
        //        Debug.Log("Противник атакует");
        //    }
        //}
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out HP hp))
            {
                if (hp.CanTakeDamagePlayer(_damage))
                {
                    ContactPoint contact = other.contacts[0];
                    return;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonController _))
            {
                Attack();
                Debug.Log("Противник атакует");
                _agent.enabled = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonController _))
            {
                _agent.enabled = true;
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