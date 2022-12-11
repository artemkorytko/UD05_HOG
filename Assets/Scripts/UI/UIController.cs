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
        private AudioManager _audioManager;
        private GameManager _gameManager;
        private GamePanel _gamePanel;
        private AnimationButton _animationButton;
        private AnimationButton _menuAnimationButton;
        
        public event Action CreateLevel;

        private void Awake() 
        {
            _menuPanel = GetComponentInChildren<MenuPanel>();
            _winPanel = GetComponentInChildren<WinPanel>();
            _gamePanel = GetComponentInChildren<GamePanel>();
            
            _animationButton = GetComponentInChildren<WinPanel>().GetComponentInChildren<AnimationButton>();
            _menuAnimationButton = GetComponentInChildren<MenuPanel>().GetComponentInChildren<AnimationButton>();
            
            _audioManager = FindObjectOfType<AudioManager>();
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
            _menuAnimationButton.ActiveAnimationButton();
            
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
            _animationButton.ActiveAnimationButton();

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
            _gamePanel.Initialize();
            
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