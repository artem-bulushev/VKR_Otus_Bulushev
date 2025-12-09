using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Code
{
    public class InputLevel : MonoBehaviour
    {
        private void Start()
        {
            // ѕри загрузке новой сцены, делаем курсор видимым и снимаем блокировку
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}