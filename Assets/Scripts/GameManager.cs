using System;
using UnityEngine;

namespace HOG
{
    public class GameManager : MonoBehaviour
    {
        private const string SAVE_KEY = "level_index";
        
        [SerializeField] private Level[] _allLevels;
        [SerializeField] private UIController _uiController;
        
        private GamePanel _gamePanel;
        private Level _currentLevel;
        private int _currentLevelIndex;
        
        //public int LevelIndex => _currentLevelIndex + 1;

        public int LevelIndex
        {
            get => _currentLevelIndex;
            set
            {
                _currentLevelIndex = value;
                OnNextLevelIndex?.Invoke(LevelIndex);
            }
        }
        public event Action OnWin;
        public event Action<int> OnNextLevelIndex;

        private void Awake()
        {
            _gamePanel = _uiController.GetComponentInChildren<GamePanel>(true);
        }

        private void Start()
        {
            LoadData();
            _uiController.CreateLevel += StartNextGame;
        }

        private void OnDestroy()
        {
            _uiController.CreateLevel -= StartNextGame;
        }

        private void SaveData()  // система сохранения (установить)
        {
            PlayerPrefs.SetInt(SAVE_KEY, _currentLevelIndex); 
        }

        private void LoadData() // система сохранения (записать)
        {
            _currentLevelIndex = PlayerPrefs.GetInt(SAVE_KEY, 0);
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

            if (index >= _allLevels.Length)
            {
                index = index % _allLevels.Length;
            }
            
            Level level = Instantiate(_allLevels[index], transform);
            return level;
        }

        public void StartGame()
        {
            _currentLevel.OnComplited += StopGame;
            _currentLevel.OnItemFind += OnItemFind;
        }

        private void OnItemFind(string id)
        {
            _gamePanel.OnItemFind(id);
        }

        public void StopGame()
        {
            _currentLevel.OnComplited -= StopGame;
            _currentLevel.OnItemFind -= OnItemFind;
            LevelIndex++;
            
            SaveData();
            
            OnWin?.Invoke();
        }

        public void StartNextGame()
        {
            CreateLevel();
            StartGame();
        }
    }
}