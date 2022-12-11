using System;
using UnityEngine;

namespace HOG
{
    public class GameManager : MonoBehaviour
    {
        private const string SAVE_KEY = "level_index";
        [SerializeField] private Level[] allLevels;

        private Level _currentLevel; //ссылка на созданный текущий уровень
        public int _currentLevelIndex;

       private GamePanel _gamePanel;

       [SerializeField] private UIcontroller _uiController;

        public event Action _allLevelsDone;
        public event Action<int> _LevelIndexAfterWining; //передадим число(номер текущего уровня который мы прошли) в качестве события

        public int LevelIndex
        {
            get => _currentLevelIndex;
            set
            {
                _currentLevelIndex = value;
                _LevelIndexAfterWining?.Invoke( LevelIndex); //подписка
            }
        }

        private void Awake()
        {
            Debug.Log(LevelIndex);
            _uiController = FindObjectOfType<UIcontroller>();
            _gamePanel = _uiController.GetComponentInChildren<GamePanel>(true);
        }

        private void Start()
        {
            LoadData();
            _uiController.CreateLevel += StartNextGame; //подписываемся от события CreateLevel
            // CreateLevel();
            //StartGame();
        }

        public void OnDestroy()
        {
            _uiController.CreateLevel -= StartNextGame; //отписываемся от события CreateLevel
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
            _currentLevel.Initialize(); // вызов метода initialize
            _gamePanel.GenerateList(_currentLevel.GetItemDictionary());
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
               _currentLevel.OnItemFind += OnItemFind;
               
           }

        private void OnItemFind(string obj)
        {
          _gamePanel.OnItemFind(obj);
        }

        public void StopGame()
           {
               _allLevelsDone?.Invoke(); //соыбтие о том что уровень пройдем и которое будет вызывать панель победы
               Debug.Log("Stop game");
               _currentLevel.OnCompleted -= StopGame;
               _currentLevel.OnItemFind -= OnItemFind;
               LevelIndex++;
               SaveData();
               
               //Debug.Log(_currentLevelIndex);
               
              // _LevelIndexAfterWining?.Invoke(LevelIndex);//при стартеСледУровня вызывается событие о том что  уровень пройден и как слдествие вызывать WinPanel
              // _LevelIndexAfterWining?.Invoke(_currentLevelIndex); //вызывается событие передающее номер текущего уровня
               //StartNextGame();
           }

           public void StartNextGame()
           {
              
               Debug.Log(_currentLevelIndex);
               CreateLevel();
               StartGame();
             
           }
           
           
           
           

        
    }
}