using System;
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

            Level level = Instantiate(allLevels[index]);
            return level;
        }

        private void StartGame()
        {
            _currentLevel.OnCompleted += StopGame;
        }

        private void StopGame()
        {
            _currentLevel.OnCompleted -= StopGame;
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