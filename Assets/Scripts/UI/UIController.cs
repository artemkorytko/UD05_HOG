using System;
using UnityEngine;

namespace HOG
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GamePanel _gamePanel;
        [SerializeField] private MenuPanel _menuPanel;
        [SerializeField] private WinPanel _winPanel;
        [SerializeField] private GameManager _gameManager;

        private void Awake()
        {
            _menuPanel.gameObject.SetActive(true);
            _gamePanel.gameObject.SetActive(false);
            _winPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _menuPanel.Play += OnGamestart;
            _winPanel.NextLevl += OnNextLevel;
            _gameManager.Win += OnWin;
        }

        private void OnDisable()
        {
            _menuPanel.Play -= OnGamestart;
            _winPanel.NextLevl -= OnNextLevel;
            _gameManager.Win -= OnWin;
        }
        
        
        private void OnWin()
        {
            _gamePanel.gameObject.SetActive(false);
            _winPanel.gameObject.SetActive(true);
        }

        private void OnNextLevel()
        {
            _gamePanel.gameObject.SetActive(true);
            _winPanel.gameObject.SetActive(false);
        }

        private void OnGamestart()
        {
            _gamePanel.gameObject.SetActive(true);
            _menuPanel.gameObject.SetActive(false);
        }

    }
}