using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Code
{
    public class EnemySpawnBoss : MonoBehaviour
    {
        [SerializeField] private GameObject _bossPrefab;
        [SerializeField] private Transform _spawnPoints;
        [SerializeField] private string _bossName;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonController player))
            {
                Destroy(gameObject);
                Spawn();
            }
        }

        private void Spawn()
        {
            Instantiate(_bossPrefab, _spawnPoints);
            Debug.Log(_bossName + " на сцене");
        }
    }
}