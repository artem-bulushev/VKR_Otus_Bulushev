using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Code
{
    public class EnemySpawnBoss : MonoBehaviour
    {
        [SerializeField] private GameObject _bossPrefab;
        [SerializeField] private GameObject _finish;
        [SerializeField] private Transform _spawnPoints;
        [SerializeField] private string _bossName;
        private GameObject _enemyBossInstance;

        private void Update()
        {
            DeathBoss();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonController player))
            {
                ColliderOff();
                Spawn();
            }
        }

        private void Spawn()
        {
            _enemyBossInstance=Instantiate(_bossPrefab, _spawnPoints);
            Debug.Log(_bossName + " на сцене");
        }

        private void ColliderOff()
        {
            GetComponent<BoxCollider>().enabled = false;
        }

        private void DeathBoss()
        {
            if (_enemyBossInstance == null)
            {
                _finish.SetActive(true);
            }
            else
            {
                _finish.SetActive(false);
            }
        }
    }
}