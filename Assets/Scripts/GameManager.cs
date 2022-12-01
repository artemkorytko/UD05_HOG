using System;
using UnityEngine;

namespace HOG
{
    public class GameManager : MonoBehaviour
    {
        private const string SAVE_KEY = "level_index";
        
        [SerializeField] private LevelController[] allLevels;

        private LevelController _CurrentLevel;
        private int _currentLevelIndex;

        public int levelIndex => _currentLevelIndex + 1;

        private void Start()
        {
            CreateLevel();
            CreateLevel();
            StartGame();
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
            _CurrentLevel = InstatiatedLevel(0);
            _CurrentLevel.Initialize();
        }

        private LevelController InstatiatedLevel(int index)
        {
            if (_CurrentLevel!= null)
            {
                Destroy(_CurrentLevel.gameObject);
            }

            if (index >= allLevels.Length)
            {
                index = index % allLevels.Length;
            }
            
            LevelController level =Instantiate(allLevels[index], transform);
            return level;
        }

        public void StartGame()
        {
            _CurrentLevel.OnCompleted += StopGame;
        }

        private void StopGame()
        {
            _CurrentLevel.OnCompleted -= StopGame;
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