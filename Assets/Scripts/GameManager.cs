﻿using System;
using UnityEngine;

namespace HOG
{
    public class GameManager : MonoBehaviour
    {
        private const string SAVE_KEY = "level_index";
        
        [SerializeField] private Level[] _allLevels;
        [SerializeField] private UIController _uiController;
      

        private Level _currentLevel;
        private int _currentLevelIndex;
        
        public int LevelIndex => _currentLevelIndex + 1;
        public event Action Win;
        public event Action<int> NextLevelIndex;
        

        private void Start()
        {
            CreateLevel();
            LoadData();
            StartGame();
            _uiController.CreateLevel += CreateLevel;
        }

        private void SaveData()
        {
            PlayerPrefs.SetInt(SAVE_KEY, _currentLevelIndex); // система сохранения (установить)
        }

        private void LoadData()
        {
            _currentLevelIndex = PlayerPrefs.GetInt(SAVE_KEY, 0);// система сохранения (записать)
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

            if (index >= _allLevels.Length)
            {
                index = index % _allLevels.Length;
            }
            
            Level level = Instantiate(_allLevels[index]);
            return level;
        }

        public void StartGame()
        {
            _currentLevel.OnComplited += StopGame;
        }

        public void StopGame()
        {
            _currentLevel.OnComplited -= StopGame;
            _currentLevelIndex++;
            SaveData();
            StartNextGame();
        }

        public void StartNextGame()
        {
           // CreateLevel();
            StartGame();
            NextLevelIndex?.Invoke(LevelIndex);
            Win?.Invoke();
        }

    }
}