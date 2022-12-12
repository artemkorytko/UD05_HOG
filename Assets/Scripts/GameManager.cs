using System;
using UnityEngine;

namespace HOG
{
    public class GameManager : MonoBehaviour
    {
         private const string SAVE_KEY = "level_index";

        [SerializeField] private LevelController[] allLevels;

        private LevelController _currentLevel;
        private int _currentLevelIndex;
        private UIController _uiController;

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
            _uiController = FindObjectOfType<UIController>();
            _gamePanel = _uiController.GetComponentInChildren<GamePanel>();
        }

        private void Start()
        {
            LoadData();
            SubscribeUI();
        }

        private void SubscribeUI()
        {
            _uiController.OnMenuButtonEvent += StartNextGame;
            _uiController.OnNextLevelButtonEvent += StartNextGame;
        }

        private void OnDestroy()
        {
            UnSubscribeUI();
        }

        private void UnSubscribeUI()
        {
            _uiController.OnMenuButtonEvent -= StartNextGame;
            _uiController.OnNextLevelButtonEvent -= StartNextGame;
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

        private LevelController InstantiateLevel(int index)
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel.gameObject);
            }

            if (index >= allLevels.Length)
            {
                index = index % allLevels.Length;
            }

            LevelController level = Instantiate(allLevels[index]);
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
            _currentLevel.OnItemFind -= OnItemFind;
            LevelIndex++;
            SaveData();
            OnWin?.Invoke();
        }

        private void OnItemFind(string id)
        {
            _gamePanel.OnItemFind(id);
        }

        public void StartNextGame()
        {
            CreateLevel();
            StartGame();
        }
    }
}