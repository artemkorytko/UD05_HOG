using System;
using UnityEngine;

namespace HOG
{
    public class GameManage : MonoBehaviour
    {
        private const string SAVE_KEY = "level_index";
        
        [SerializeField] private Level[] allLevels;

        private Level _currentLevel;
        private int _cuarrentLevelIndex;

        public int LevelIndex => _cuarrentLevelIndex + 1;

        private void Start()
        {   LoadData();
            CreateLevel();
            StartGame();
            //InitializeUI();
        }

        private void SaveData()
        {
            PlayerPrefs.SetInt(SAVE_KEY, _cuarrentLevelIndex);
        }
        
        private void LoadData()
        {
            _cuarrentLevelIndex = PlayerPrefs.GetInt(SAVE_KEY, 0);
        }
        
        private void CreateLevel()
        {
            _currentLevel = InstatiateLevel(_cuarrentLevelIndex);
            _currentLevel.Initialize();
        }

        private Level InstatiateLevel(int index)
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

        public void StopGame()
        {
            _currentLevel.OnCompleted -= StopGame;
            _cuarrentLevelIndex++;
            SaveData();
            StartNextGame();
        }

        public void StartNextGame()
        {
            Debug.Log("Start next Level");
            CreateLevel();
            StartGame();
        }
    }
}