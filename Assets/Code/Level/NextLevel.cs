using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code
{
    public class NextLevel : MonoBehaviour
    {
        [SerializeField] private Button _next;
        [SerializeField] private Button _previous;

        

        private void OnEnable()
        {
            _next.onClick.AddListener(Next);
            _previous.onClick.AddListener(Previous);
        }

        private void OnDisable()
        {
            _next.onClick.RemoveListener(Next);
            _previous.onClick.RemoveListener(Previous);
        }

        private void Next()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void Previous()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}