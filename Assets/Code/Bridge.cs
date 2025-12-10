using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Code
{
    public class Bridge : MonoBehaviour
    {
        [SerializeField] private GameObject _bridgePrefab;
        private GameObject _bridgeInstance; // Ссылка на экземпляр моста  
        private bool _isBridgeRaised = false; // Флаг активации моста

        private Transform[] _spawnPoints;
        // Флаг для отслеживания состояния моста  
        private bool _isBridgeVisible = false;

        private void Start()
        {
            _spawnPoints = GetComponentsInChildren<Transform>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // Проверка, был ли мост поднят  
            if (_isBridgeRaised == false)
            {
                Debug.Log("Мост еще не поднят. Триггер неактивен.");
                return; // Выходим из метода, если мост не поднят  
            }

            if (other.TryGetComponent(out FirstPersonController _))
            {
                ShowBridge();
                Debug.Log("Мост виден");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // Проверка, был ли мост поднят  
            if (_isBridgeRaised == false)
            {
                Debug.Log("Мост еще не поднят. Триггер неактивен.");
                return; // Выходим из метода, если мост не поднят  
            }

            if (other.TryGetComponent(out FirstPersonController _))
            {
                HideBridge();
                Debug.Log("Мост не виден");
            }
        }

        private void ShowBridge()
        {
            // Если мост еще не создан, создаем его  
            if (_bridgeInstance == null)
            {
                _bridgeInstance = Instantiate(_bridgePrefab, _spawnPoints[_spawnPoints.Length]);
            }
            else
            {
                // Если мост уже создан, просто делаем его видимым  
                Debug.Log("Мост уже был создан");
            }

            // Делаем мост видимым  
            _bridgeInstance.SetActive(true);
            _isBridgeVisible = true;
        }

        private void HideBridge()
        {
            if (_bridgeInstance != null)
            {
                _bridgeInstance.SetActive(false);
                _isBridgeVisible = false;
            }
            else
            {
                Debug.Log("Мост не был создан");
            }
        }

        // Метод для активации моста через вызов извне  
        public void RaiseBridge()
        {
            _isBridgeRaised = true;
            Debug.Log("Bridge поднят: теперь триггеры будут работать");
        }

        // Дополнительный метод для полного удаления моста  
        public void DestroyBridge()
        {
            if (_bridgeInstance != null)
            {
                Destroy(_bridgeInstance);
                _bridgeInstance = null;
                _isBridgeVisible = false;
            }
            _isBridgeRaised = false; // Сбрасываем флаг активации  
        }

        //[SerializeField] private GameObject _bridgePrefab;
        //[SerializeField] private Transform _spawnPoints;
        //private GameObject _bridgeInstance; // Добавляем ссылку на экземпляр моста
        //                                    // Флаг для отслеживания состояния моста  
        //private bool _isBridgeVisible = false;

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.TryGetComponent(out FirstPersonController player))
        //    {
        //        ShowBridge();
        //        Debug.Log("Мост виден");
        //    }
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.TryGetComponent(out FirstPersonController player))
        //    {
        //        HideBridge();
        //        Debug.Log("Мост не виден");
        //    }
        //}

        //private void ShowBridge()
        //{
        //    // Если мост еще не создан, создаем его  
        //    if (_bridgeInstance == null)
        //    {
        //        _bridgeInstance = Instantiate(_bridgePrefab, _spawnPoints.position, _spawnPoints.rotation);
        //    }
        //    else
        //    {
        //        // Если мост уже создан, просто делаем его видимым  
        //        Debug.Log("Мост уже был создан");
        //    }

        //    // Делаем мост видимым  
        //    _bridgeInstance.SetActive(true);
        //    _isBridgeVisible = true;
        //}

        //private void HideBridge()
        //{
        //    if (_bridgeInstance != null)
        //    {
        //        _bridgeInstance.SetActive(false);
        //        _isBridgeVisible = false;
        //    }
        //    else
        //    {
        //        Debug.Log("Мост не был создан");
        //    }
        //}

        //// Дополнительный метод для полного удаления моста  
        //public void DestroyBridge()
        //{
        //    if (_bridgeInstance != null)
        //    {
        //        Destroy(_bridgeInstance);
        //        _bridgeInstance = null;
        //        _isBridgeVisible = false;
        //    }
        //}

        //[SerializeField] private GameObject _bridgePrefab;
        //[SerializeField] private Transform _spawnPoints;

        //private void Spawn()
        //{
        //    GameObject instance = Instantiate(_bridgePrefab, _spawnPoints);
        //    Debug.Log("Прозрачный мост создан");
        //}

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.TryGetComponent(out FirstPersonController player))
        //    {
        //        Spawn();
        //        Debug.Log("Мост виден");
        //    }
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.TryGetComponent(out FirstPersonController player))
        //    {
        //        Destroy(instance);
        //        Debug.Log("Мост не виден");
        //    }
        //}


        //private void Start()
        //{
        //    Spawn();
        //    _bridgePrefab.SetActive(false);
        //}

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.TryGetComponent(out FirstPersonController player))
        //    {
        //        _bridgePrefab.SetActive(true);
        //        Debug.Log("Мост виден");
        //    }
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.TryGetComponent(out FirstPersonController player))
        //    {
        //        _bridgePrefab.SetActive(false);
        //        Debug.Log("Мост не виден");
        //    }
        //}
    }
}