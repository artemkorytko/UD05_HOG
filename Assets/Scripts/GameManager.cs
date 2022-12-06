using System;
using Unity.VisualScripting;
using UnityEngine;

namespace HOG
{
    public class GameManager : MonoBehaviour
    {
        // -------------------------------------------------------------------------------------------

        private const string SAVE_KEY = "game_level_index"; // для ключа сохранению

        [SerializeField] private Level[] allLevels; // массив для всех уровней

        private Level _currentLevel; // сюда записали результат
        private int _currentLevelIndex; // сохраняет индекс уровня

        public int LevelIndex => _currentLevelIndex + 1; // этот покажем пользователю

        UIController uiController; //создаем объект с уишками :/
        
        // -------------------------------------------------------------------------------------------

        private void Start()
        {
            LoadData(); // загрузили на каком уровне остановился
            CreateLevel(); // сделали уровень
            
            // StartGame(); - убрали чтобы игра не пошла до заставки

            // создать UIController
            uiController = FindObjectOfType<UIController>();
            // отобразить меню начала игры
            uiController.ShowMenutoUser();
            // обновить номер уровня (пока его не видно)
            uiController.UpdateLeveltoUser(_currentLevelIndex);
        }


        /* дебажное сотворение уровня по нажатию пробела
        private void Update()
        { if (Input.GetKeyDown(KeyCode.Space))
            {   CreateLevel();} }           */


        //--------- СОХРАНЕНИЕ и загрузка прогресса!!!! PlayerPrefs - это юнити стандартное --------
        private void SaveData()
        {
            PlayerPrefs.SetInt(SAVE_KEY, _currentLevelIndex); // set сохраняет дату по ключу, ключ в переменной выше
        }

        private void LoadData()
        {
            _currentLevelIndex = PlayerPrefs.GetInt(SAVE_KEY, 0); // , второй параметр - значение по умолчанию
        }
        //------------------------------------------------------------------------------------------


        // по кругу зациклиливает уровни
        private void CreateLevel()
        {
            _currentLevel = InstantiateLevel(_currentLevelIndex); // создать из префаба!!!! берем 1й в массиве
            _currentLevel.Initialize();
        }


        private Level InstantiateLevel(int index) // ссылка вернется как результат работы метода
        {
            // проверка 
            if (_currentLevel != null) // когда только зашли
            {
                // когда вызываем дестрой и передаем ссылку - то удаляется компонент геймобджекта
                Destroy(_currentLevel.gameObject);
            }

            // если номер превышает количество что есть в массиве то создаем с 0-го по кругу
            if (index >= allLevels.Length)
            {
                index = index % allLevels.Length; // остаток от деления 5//15 = 0   
                // (15 * 0) + 5 = 0 + 5 = 5
                // он всегда будет деожать нас в диапазоне от нуля до того на что делим
                // шоб уровень всегда был 0-15 даже если юзер играет 85й уровень по факту
            }

            //передаем индекс массива //allLevels[index], transform - параметрами можно указать ротейшен и или смещение относительно парента
            Level level = Instantiate(allLevels[index]);
            return level;
        }

        //-------------------------------------------------------------------------------------------
        public void StartGame()
        {
            Debug.Log("Start game");

            _currentLevel.OnCompleted += StopGame; // += подписались на метод - Вызываем ее что ли???
        }


        public void StopGame()
        {
            Debug.Log("Stop game");

            _currentLevel.OnCompleted -= StopGame; // -= отписывается !
            _currentLevelIndex++;
            SaveData();
            
            CreateLevel();

            // show menu Next Level
            uiController.UpdateLeveltoUser(_currentLevelIndex);
            uiController.ShowNextLeveltoUser();
            // StartNextGame();
        }

        public void StartNextGame()
        {
            Debug.Log("Start next level");

            // обновить номер уровня
            uiController.UpdateLeveltoUser(_currentLevelIndex);
            // отобразить номер уровня, если панель еще не видна
            uiController.ShowLeveltoUser();
            
            CreateLevel();
            StartGame();
        }
    }
}