using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

namespace Code
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        public int EnemySpeed = 3;
        private Transform _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        }

        private void Update()
        {
            _agent.SetDestination(_player.position);
        }
        public void DeactivateEnemy()
        {
            _agent.speed = 0;
        }
        public void ActivateEnemy()
        {
            _agent.speed = EnemySpeed;
        }

        //private void OnCollisionEnter(Collision other)
        //{
        //    if (other.collider.TryGetComponent(out FirstPersonController _))
        //    {
        //        Attack();
        //        Debug.Log("Противник атакует");
        //    }
        //}

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