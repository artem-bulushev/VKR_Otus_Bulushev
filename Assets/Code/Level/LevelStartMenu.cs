using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code
{
    public class LevelStartMenu : MonoBehaviour
    {
        [SerializeField] private Button _startMenu;

        private void OnEnable()
        {
            _startMenu.onClick.AddListener(StartMenu);
        }

        private void OnDisable()
        {
            _startMenu.onClick.RemoveListener(StartMenu);
        }

        private void StartMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}