using System;
using UnityEngine;

namespace HOG
{
    public class UIController : MonoBehaviour
    {
        private enum PanelType
        {
            None,
            Menu,
            Game,
            Win
        }

        private MenuPanel _menuPanel;
        private WinPanel _winPanel;
        private GameManager _gameManager;
        private GamePanel _gamePanel;

        public event Action CreateLevel;

        private void Awake()
        {
            _menuPanel = GetComponentInChildren<MenuPanel>();
            _winPanel = GetComponentInChildren<WinPanel>();
            _gamePanel = GetComponentInChildren<GamePanel>();
            
            _gameManager = FindObjectOfType<GameManager>();

        }

        private void OnEnable()
        {
            _menuPanel.Play += OnGameStart;
            _winPanel.NextLevl += OnNextLevel;
            _gameManager.OnWin += OnWin;
        }

        private void Start()
        {
            SwitchPanel(PanelType.Menu);
        }

        private void OnDisable()
        {
            _menuPanel.Play -= OnGameStart;
            _winPanel.NextLevl -= OnNextLevel;
            _gameManager.OnWin -= OnWin;
        }

        private void OnWin()
        {

            SwitchPanel(PanelType.Win);
        }

        private void OnNextLevel()
        {
            CreateLevel?.Invoke();
            SwitchPanel(PanelType.Game);
        }

        private void OnGameStart()
        {
            CreateLevel?.Invoke();
            SwitchPanel(PanelType.None);
        }

        private void SwitchPanel(PanelType panelType)
        {
            switch (panelType)
            {
                case (PanelType.Game):
                    _winPanel.Hide();
                    _gamePanel.Show();
                    break;

                case (PanelType.Win):
                    _gamePanel.Hide();
                    _winPanel.Show();
                    break;

                case (PanelType.Menu):
                    _winPanel.Hide();
                    _gamePanel.Hide();
                    _menuPanel.Show();
                    break;
                
                case (PanelType.None):
                    _menuPanel.Hide();
                    _gamePanel.Show();
                    break;
            }
        }
    }
}