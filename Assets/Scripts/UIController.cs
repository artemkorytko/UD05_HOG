using System;
using UnityEngine;
using TMPro;

//скрипт висит на UI
namespace HOG
{
    public class UIController : MonoBehaviour
    {
        //поля чтобы таскать сюда руками панели и текст
        [SerializeField] public GameObject menuPanel;
        [SerializeField] public GameObject winPanel;
        [SerializeField] public GameObject levelNumbPanel;

        [SerializeField] public TMP_Text textField4Level;

        // ----------------------------------------------

        private void Awake()
        {
            Debug.Log("Start in UIController...");
            // готовим панели к отображению
            // отобразим только меню, а остальное - скрыть

            // включение нужной панели на старте
            menuPanel.gameObject.SetActive(true);
            winPanel.gameObject.SetActive(false);
            levelNumbPanel.gameObject.SetActive(false);
        }

        private void Start()
        {
            // старт нужен, чтобы у скрипта в инспекторе появилась галочка
            Debug.Log("Start in UIController...");
        }

        // ----------------------------------------------

        // метод для отображения на экране номера уровня. В параметре задаем его номер
        public void ShowMenutoUser()
        {
            Debug.Log("Show menu...");
            menuPanel.gameObject.SetActive(true);
        }
        
        public void HideMenutoUser()
        {
            Debug.Log("Show menu...");
            
            //обращаемся точно к нужной к панели через переменную с сериалайзом
            menuPanel.gameObject.SetActive(false);
        }

        // ----------------------------------------------

        // LEVEL TEXT

        // метод для отображения на экране номера уровня. В параметре задаем его номер
        public void UpdateLeveltoUser(int LevelIndex)
        {
            Debug.Log("Level:" + LevelIndex);

            // отобразить номер уровня в тексте
            string showleveltext = "Level: " + LevelIndex.ToString();
            textField4Level.text = showleveltext;
        }

        // метод для отображения на экране номера уровня. В параметре задаем его номер
        public void ShowLeveltoUser()
        {
            Debug.Log("Show level text");
            levelNumbPanel.gameObject.SetActive(true);
        }

        // скрыть панель с номером уровня
        public void HideLevelfromUser()
        {
            Debug.Log("Hide level text");
            levelNumbPanel.gameObject.SetActive(false);
        }

        // ----------------------------------------------

        // отобразить панель для перехода на следующий уровень
        public void ShowNextLeveltoUser()
        {
            Debug.Log("Show next level panel");
            
            // скрыть текст номера уровня
            HideLevelfromUser();
            
            // отобразить меню для следующего уровня
            winPanel.gameObject.SetActive(true);
        }
        
        // скрыть меню "next level"
        public void HideNextLeveltoUser()
        {
            Debug.Log("Show next level panel");
            
            winPanel.gameObject.SetActive(false);
        }
    }
}