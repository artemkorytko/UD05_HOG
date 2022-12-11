using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace HOG
{
    public class GameManager : MonoBehaviour
    {
        private const string SAVE_KEY = "level_index";
        
        [SerializeField] private Level[] allLevels;

        private Level _currentLevel;
        private int _currentLevelIndex;
        private UiController _uiController;

        private GamePanel _gamePanel;

        private int LevelIndex
        {
            get => _currentLevelIndex;
            set
            {
                _currentLevelIndex = value;
                OnLevelChanged?.Invoke(LevelIndex + 1);
            }
        }

        public event Action<int> OnLevelChanged;

        public event Action OnWin;

        private void Awake()
        {
            _uiController = FindObjectOfType<UiController>();
            _gamePanel = _uiController.GetComponentInChildren<GamePanel>();
        }

        private void Start()
        {
            LoadData();
            SubscribeUi();
        }

        private void OnDestroy()
        {
            UnsubscribeUi();
        }

        private void SubscribeUi()
        {
            _uiController.OnMenuButtonEvent += StartNextGame;
            _uiController.OnNextLevelEvent += StartNextGame;
        }
        
        private void UnsubscribeUi()
        {
            _uiController.OnMenuButtonEvent -= StartNextGame;
            _uiController.OnNextLevelEvent -= StartNextGame;
        }

        private void SaveData()
        {
            PlayerPrefs.SetInt(SAVE_KEY, _currentLevelIndex);
        }

        private void LoadData()
        {
            LevelIndex = PlayerPrefs.GetInt(SAVE_KEY, 0);
        }

        private void CreateLevel()
        {
            _currentLevel = InstantiateLevel(_currentLevelIndex);
            _currentLevel.Initialize();
            _gamePanel.GenerateList(_currentLevel.GetItemDictionary());
            
        }

        private Level InstantiateLevel(int index)
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel.gameObject);
            }

            if (index >= allLevels.Length)
            {
                index = index % allLevels.Length;
            }
            
            Level level = Instantiate(allLevels[index], transform);
            return level;
        }

        private void StartGame()
        {
            _currentLevel.OnCompleted += StopGame;
            _currentLevel.OnItemFind += OnItemFind;
        }

        private void StopGame()
        {
            _currentLevel.OnCompleted -= StopGame;
            LevelIndex++;
            SaveData();
            OnWin?.Invoke();
        }
        
        private void OnItemFind(string id)
        {
            _gamePanel.OnItemFind(id);
        }

        private void StartNextGame()
        {
            CreateLevel();
            StartGame();
            Debug.Log("Create New Level");
        }
    }
}