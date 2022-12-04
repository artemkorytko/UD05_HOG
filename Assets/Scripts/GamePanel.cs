using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using HOG;

public class GamePanel : MonoBehaviour
{
    //в гейм панель должно быть отображение номера уровня
    [SerializeField] private TextMeshProUGUI _levelNumber;
    [SerializeField]  private GameManager _gameManager; //номер уровня есть в гейм менеджере

    private void Awake()
    {
        _levelNumber.text = "Level " + _gameManager.LevelIndex; /*обращаемся к свойству text объекта _levelNumber(т к он типа текстмешпроугуи, у данного класса есть прописанные св-ва(напр, цвет шрифтаб размер, и др свойства) в нашем случве обратились к свойству текст объекта из данного класса) , т е ссылка к полю text объекта _levelNUmber
     и присваиваем ему LevelIndex(номер уровня) из переменной _gameManager класса _gameManager*/
        
    }

    private void OnEnable()
    {
        _gameManager._LevelIndexAfterWining += OnLevelIndexAfterWining;
    }

    private void OnLevelIndexAfterWining(int index) // index ->LevelIndex из GameManager
    {
        _levelNumber.text = "Level " + index; 
        
    }

    
}
