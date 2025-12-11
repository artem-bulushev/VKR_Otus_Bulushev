using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace Code
{
    public class HP : MonoBehaviour
    {
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private Canvas _canvasHp;
        [SerializeField] private Canvas _canvasDeath;
        [SerializeField] private bool _pauseOnOpen = true;
        [SerializeField] private FirstPersonController _firstPersonController;
        [SerializeField] private WeaponController _weaponController;
        public Scrollbar _healthScrollbar;
        private float _maxHp = 100f;
        private float _minHp = 0f;
        public float _currentHp;
        private bool _isAlive = true;

        public static event Action OnPlayerDied;

        public void Start()
        {
            _currentHp = _maxHp;
            _canvasHp.gameObject.SetActive(true);
        }

        public void UpdateHealthBar()
        {
            _healthScrollbar.size = _currentHp / _maxHp;
            _currentHp = Mathf.Clamp(_currentHp, _minHp, _maxHp);
        }

        private void OnCompleteUpdateProgress()
        {
            _countText.text = $"{(int)_currentHp}/{_maxHp}";
        }

        private void OnValidate()
        {
            EditorApplication.delayCall += () =>
            {
                if (_healthScrollbar != null)
                {
                    UpdateHealthBar();
                    OnCompleteUpdateProgress();
                }
            };
        }
        public bool CanTakeDamagePlayer(float damage)
        {
            if (_isAlive == false)
            {
                return false;
            }

            _currentHp -= damage;


            if (_currentHp <= 0)
            {
                Animator animator = GetComponent<Animator>();
                if (animator != null)
                {
                    animator.enabled = false;
                }
                Death();
                _isAlive = false;
                return false;
            }

            return true;
        }
        public void Death()
        {
            OnPlayerDied?.Invoke();
            VisibilityCanvas();
        }

        private void VisibilityCanvas()
        {
            if (_canvasDeath == null) return;

            bool isOpen = _canvasDeath.gameObject.activeSelf;
            _canvasDeath.gameObject.SetActive(!isOpen);

            if (_pauseOnOpen)
            {
                Time.timeScale = isOpen ? 1f : 0f;
                _firstPersonController.enabled = isOpen;
                _weaponController.IsActive = isOpen;
            }
        }
    }
}