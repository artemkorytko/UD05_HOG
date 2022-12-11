using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace HOG
{


public class GamePanel : MonoBehaviour
{
    //в гейм панель должно быть отображение номера уровня
    private TextMeshProUGUI _levelNumber;
    [SerializeField] private GameManager _gameManager; //номер уровня есть в гейм менеджере

    [SerializeField] private UiItem prefab;



    [SerializeField] private Transform content; //ссылка куда будем создавать юай айтемы

    private Dictionary<string, UiItem> _uiItems = new Dictionary<string, UiItem>();

    private UiItem _uiItem;

    private void Awake()
    {
        _levelNumber = GetComponentInChildren<TextMeshProUGUI>();//на GamePanel висит скрипт, у GamePanel есть дети.получаем компонент который явл-ся ребенком объекта GamePanel, получаем комопнент - 
        
        
    }

    private void Start()
    {
        _gameManager._LevelIndexAfterWining += OnLevelIndexAfterWining; //подписка на OnLevelIndexAfterWining   
        _levelNumber.text = $"Level {_gameManager._currentLevelIndex}";//я в компонент текста объекта типа текст меш про _levelNumber присваиваю запись "Level" получили с _gameManager  о состоянии текущего уровня;
        // _levelNumber.text = "Level " + _gameManager.LevelIndex; /*обращаемся к свойству text объекта _levelNumber(т к он типа текстмешпроугуи, у данного класса есть прописанные св-ва(напр, цвет шрифтаб размер, и др свойства) в нашем случве обратились к свойству текст объекта из данного класса) , т е ссылка к полю text объекта _levelNUmber
        // и присваиваем ему LevelIndex(номер уровня) из переменной _gameManager класса _gameManager*/

    }

    private void OnEnable() //метод который вызывается когда объект становится активным
    {
       // _gameManager._LevelIndexAfterWining += OnLevelIndexAfterWining; //подписка на OnLevelIndexAfterWining   
    }
    

    private void OnDestroy()
    {
        _gameManager._LevelIndexAfterWining -= OnLevelIndexAfterWining; //отписка от OnLevelIndexAfterWining
    }

    private void OnLevelIndexAfterWining(int index) // index ->LevelIndex из GameManager
    {
        Debug.Log("the method was called");
        _levelNumber.text = $"Level {index}";//я в компонент текста объекта типа текст меш про _levelNumber присваиваю запись "Level" получили с _gameManager  о состоянии текущего уровня;
        //_levelNumber.text = "Level " + index;

    }

    public void GenerateList(Dictionary<string, GameItemData> dictionary)
    {
        _uiItems.Clear();
        foreach (string key in dictionary.Keys)
        {
            UiItem item = Instantiate(prefab, content);
            item.SetSprite(dictionary[key].Sprite);
            item.SetCounter(dictionary[key].Amount);
            _uiItems.Add(key, item);

            // тут допистаь очищение листа
        }
    }

    public void OnItemFind(string id)
    {
        if (_uiItems.ContainsKey(id))
        {
            _uiItems[id].Decrease();
        }

    }
}

}