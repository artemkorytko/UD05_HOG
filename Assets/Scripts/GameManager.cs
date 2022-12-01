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

        public int LevelIndex => _currentLevelIndex + 1;

        private void Start()
        {
            LoadData();
            CreateLevel();
            StartGame();
            // InitializeUI();
        }

        private void SaveData()
        {
            PlayerPrefs.SetInt(SAVE_KEY, _currentLevelIndex);
        }

        private void LoadData()
        {
            _currentLevelIndex = PlayerPrefs.GetInt(SAVE_KEY, 0);
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

        public void StartGame()
        {
            _currentLevel.OnCompleted += StopGame;
        }

        private void StopGame()
        {
            _currentLevel.OnCompleted -= StopGame;
            _currentLevelIndex++;
            SaveData();
            StartNextGame();
        }

        public void StartNextGame()
        {
            Debug.Log("Start next level");
            CreateLevel();
            StartGame();
        }
    }
}