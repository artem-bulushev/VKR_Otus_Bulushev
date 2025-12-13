using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

namespace Code
{
    public class Finish : MonoBehaviour
    {
        //private bool _finishActive = false;
        //[SerializeField] private GameObject _enemyBossPrefab; 
        //private GameObject _enemyBossInstance;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonController _))
            {
                FinishLavel();
                Debug.Log("Уровень пройден");
            }
        }
        private void FinishLavel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //private void ColliderOn()
        //{
        //    GetComponent<BoxCollider>().enabled = true;
        //}

        //public void FinishActive()
        //{
        //    _finishActive = true;
        //}
    }
}