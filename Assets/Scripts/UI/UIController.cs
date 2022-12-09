using System;
using Unity.VisualScripting;
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
        
        private GamePanel _gamePanel;
        private MenuPanel _menuPanel;
        private WinPanel _winPanel;
        private AudioManager _audioManager;
        
        private GameManager _gameManager;
        
        public event Action CreateLevel;

        private void Awake() 
        {
            _gamePanel = GetComponentInChildren<GamePanel>();
            _menuPanel = GetComponentInChildren<MenuPanel>();
            _winPanel = GetComponentInChildren<WinPanel>();

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
            SwitchPanel(PanelType.None);
        }
        
        private void SwitchPanel(PanelType panelType)
        {
            switch (panelType)
            {
                case(PanelType.Game):
                    _winPanel.SetAlphaCanvas(false);
                  break;
                
                case(PanelType.Win):
                    _winPanel.SetAlphaCanvas(true);
                    break;
                
                case(PanelType.Menu):
                    _menuPanel.SetAlphaCanvas(true);
                    break;
                
                default:
                    _menuPanel.SetAlphaCanvas(false);
                    _winPanel.SetAlphaCanvas(false);
                    break;
            }
        }

    }
}