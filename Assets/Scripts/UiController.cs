using System;
using UnityEditor.TextCore.Text;
using UnityEngine;

namespace HOG
{
    public class UiController : MonoBehaviour
    {
        private enum PanelType
        {
            None,
            Menu,
            Game,
            Win
        }

        private MenuPanel _menuPanel;
        private GamePanel _gamePanel;
        private WinPanel _winPanel;
        
        private GameManager _gameManager;

        public event Action OnMenuButtonEvent;
        public event Action OnNextLevelEvent;
        
            
        private void Awake()
        {
            _menuPanel = GetComponentInChildren<MenuPanel>();
            _gamePanel = GetComponentInChildren<GamePanel>();
            _winPanel = GetComponentInChildren<WinPanel>();

            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Start()
        {
            _gameManager.OnWin += OnWin;
            _menuPanel.OnMenuButtonClick += OnMenuButtonClick;
            _winPanel.OnNextlevelButtonClick += OnNextLevelButtonClick;
            SwitchPanel(PanelType.Menu);
        }

        private void OnDestroy()
        {
            _gameManager.OnWin -= OnWin;
            _menuPanel.OnMenuButtonClick -= OnMenuButtonClick;
            _winPanel.OnNextlevelButtonClick -= OnNextLevelButtonClick;
        }

        private void OnWin()
        {
            SwitchPanel(PanelType.Win);
        }

        private void OnMenuButtonClick()
        {
            OnMenuButtonEvent?.Invoke();
            SwitchPanel(PanelType.Game);
        }

        private void OnNextLevelButtonClick()
        {
            OnNextLevelEvent?.Invoke();
            SwitchPanel(PanelType.Game);
        }

        private void SwitchPanel(PanelType panelType)
        {
            _gamePanel.gameObject.SetActive(panelType == PanelType.Game);
            _menuPanel.gameObject.SetActive(panelType == PanelType.Menu);
            _winPanel.gameObject.SetActive(panelType == PanelType.Win);
        }
    }
}