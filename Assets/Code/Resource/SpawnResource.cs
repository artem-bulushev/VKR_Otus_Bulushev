using UnityEngine;

namespace Code
{
    public class SpawnResource : MonoBehaviour
    {
        [SerializeField] private GameObject _resourcePrefab;
        [SerializeField] private Transform _spawnPoints;
        [SerializeField] private string _resourceName;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            Instantiate(_resourcePrefab, _spawnPoints);
            Debug.Log(_resourceName + " на сцене");
        }
    }
}
