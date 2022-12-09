using System;
using Unity.VisualScripting;
using UnityEngine;

namespace HOG
{
    public class UIController : MonoBehaviour
    {
        private enum PanelType
        { 
            Menu,
            Game,
            Win
        }
        
        private GamePanel _gamePanel;
        private MenuPanel _menuPanel;
        private WinPanel _winPanel;
        private AudioManager _audioManager;
        
        private GameManager _gameManager;
        
        public event Action CreateLevel;

        private void Awake() 
        {
            _gamePanel = GetComponentInChildren<GamePanel>(true);
            _menuPanel = GetComponentInChildren<MenuPanel>(true);
            _winPanel = GetComponentInChildren<WinPanel>(true);

            _audioManager = FindObjectOfType<AudioManager>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Start()
        {
           SwitchPanel(PanelType.Menu);
        }

        private void OnEnable()
        {
            _menuPanel.Play += OnGameStart;
            _winPanel.NextLevl += OnNextLevel;
            _gameManager.OnWin += OnWin;
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
            _audioManager.PlayAudioWin();
        }

        private void OnNextLevel()
        {
            CreateLevel?.Invoke();
            SwitchPanel(PanelType.Game);
        }

        private void OnGameStart()
        {
            CreateLevel?.Invoke();
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