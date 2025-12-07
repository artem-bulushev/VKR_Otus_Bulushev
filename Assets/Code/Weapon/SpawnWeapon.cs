using UnityEngine;

namespace Code
{
    public class SpawnWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private Transform _spawnPoints;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            Instantiate(_weaponPrefab, _spawnPoints);
            Debug.Log("Оружие создано");
        }
    }
}
