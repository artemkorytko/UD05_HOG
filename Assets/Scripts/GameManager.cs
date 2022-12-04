using System;
using UnityEngine;

namespace HOG
{
    public class GameManager : MonoBehaviour
    {
        private const string SAVE_KEY = "level_index";
        [SerializeField] private Level[] allLevels;

        private Level _currentLevel; //ссылка на созданный текущий уровень
        private int _currentLevelIndex;

        public int LevelIndex => _currentLevelIndex + 1;

        private UIcontroller _uiController = new UIcontroller();
        

        private void Start()
        {
            LoadData();
            CreateLevel();
            StartGame();
        }

     /*   private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CreateLevel();
            }
            
        } */

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
            _currentLevel.Initialize(); // вызов метода initialize
        }

        private Level InstantiateLevel(int index) //index - номер уровня который сейчас создать
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel.gameObject);
            }

            if (index >= allLevels.Length)
            {
                index = index % allLevels.Length;

            }

            Level level = Instantiate(allLevels[index]); // когда будет создан объект(Instantiate), он будет принадлежать transform'у
            return level;
        }

        public void StartGame()
           {
               _currentLevel.OnCompleted += StopGame;
           }

           public void StopGame()
           {
               _currentLevel.OnCompleted -= StopGame;
               _currentLevelIndex++;
               SaveData();
               StartNextGame();
           }

           public void StartNextGame()
           {
               Debug.Log("Next Level");
               CreateLevel();
               StartGame();
           }

        
    }
}