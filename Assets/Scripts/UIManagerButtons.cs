using UnityEngine;
using UnityEngine.UI;

//скрипт висит тоже на UI
namespace HOG
{
    public class UIManagerButtons : MonoBehaviour
    {
        // кнопки "Play" и "Next level" перетянули руками в поля
        [SerializeField] public Button btnPlay;
        [SerializeField] public Button btnNextLevel;

        // эта непонятная фраза нужна, чтобы обратиться к классу UI Conroller :/
        UIController uiController; 
        
        // ----------------------------------------------------

        // Start is called before the first frame update
        void Start()
        {
            // создаются слушалки кнопок
            btnPlay.onClick.AddListener(btn_PlayClicked);
            btnNextLevel.onClick.AddListener(btn_NextLevelClicked);
   
            uiController = FindObjectOfType<UIController>();
        }

        //----------------- события кнопок --------------------

        //---------- старт игры по нажатию Play
        public void btn_PlayClicked()
        {
            Debug.Log("btn_PlayClicked()");

            // скрыть панель меню "Play"
            uiController.HideMenutoUser();
            // отобразить панель с номером уровня
            uiController.ShowLeveltoUser();

            // начать игру
            GameManager gameManager; //! это чтобы запустить функцию StartGame - пустой
            gameManager = FindObjectOfType<GameManager>(); //пихает в него объект - вcё что в файле GameManager
            gameManager.StartGame();
        }

        //---------- старт игры по нажатию Next Level
        public void btn_NextLevelClicked()
        {
            Debug.Log("btn_NextLevelClicked()");

            // скрыть панель "следующий уровень"
            uiController.HideNextLeveltoUser();

            // начать следующий уровень игры
            GameManager gameManager;
            gameManager = FindObjectOfType<GameManager>();
            gameManager.StartNextGame();
        }
    }
}