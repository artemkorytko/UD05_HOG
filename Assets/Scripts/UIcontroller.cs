using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HOG;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class UIcontroller : MonoBehaviour
{
    private MenuPanel _menuPanel; // cоздаем ссылки 
    private GamePanel _gamePanel;
    private WinPanel _winPanel;
    private GameManager _gameManager;

    public event Action CreateLevel;

    
    
    
    private void Awake() //Awake вызывается в самом начале игры один раз, и вместе с ним активируется менюПанель, и не будут активны gamePanel и WinPanel
    {
        _menuPanel = GetComponentInChildren<MenuPanel>(true);
        _gamePanel = GetComponentInChildren<GamePanel>(true);
        _winPanel = GetComponentInChildren<WinPanel>(true);
        _gameManager = FindObjectOfType<GameManager>();
        
    }
    

    private void OnEnable() //вызывается один раз при включении uicontroller(а включается он один раз)
    {
        _menuPanel._play +=
            OnPLay; //подписались на событие _play из класса MenuPanel(где _menuPanel - экземпляр(для вызова в другом классе) класса MenuPanel и передали ему метод OnPLay. Т е  передаем ссылку на OnPlay в OnEnable, чтобы вызвать(активировать) его.  вызовется при включении игры (т к OnEnable включается сразу при включении игры)
        _winPanel._win += NewGame;
       // _gameManager._allLevelsDone += WiningGame;
        _gameManager._WhenWin += WiningGame;

    }

    private void Start()
    {
        _menuPanel.gameObject.SetActive(true);
        _gamePanel.gameObject.SetActive(false);
        _winPanel.gameObject.SetActive(false);
    }
    
    private void OnPLay() //метод который включает GamePanel, Action - ивент(рация) на которую мы подписались, которая известит о нажатии кнопки "старт гейм" => и как следствие при нажатии кнопки "старт гейм" отключает МенюПанель и включет ГеймПанель
    {
        _menuPanel.gameObject.SetActive(false);
        _gamePanel.gameObject.SetActive(true);
        _gamePanel.Initialise();//вызов метода из гейм панела происходящий при активации метода OnPlay(еоторый следуюет после нажатия кнопки начала игры)
        _winPanel.gameObject.SetActive(false);
        CreateLevel?.Invoke();
    }

    private void NewGame() //аналогично OnPlay // включается при нажатии кнопки "о переходе на след уровень" на панелиПобеды , т е включает панель игры и отключает остальные панели 
    {
        _menuPanel.gameObject.SetActive(false);
        _gamePanel.gameObject.SetActive(true);
        _winPanel.gameObject.SetActive(false);
        CreateLevel?.Invoke();
    }

    private void WiningGame() //метод который сработает после прохождения каждого уровня=> победе
    {
        Debug.Log("win");
        _menuPanel.gameObject.SetActive(false);
        _gamePanel.gameObject.SetActive(false);
        _winPanel.gameObject.SetActive(true);

    }

    private void OnDisable() // отписываемся от всех ивентов
    {
        _menuPanel._play -= OnPLay; //подписались на событие _play из класса MenuPanel(где _menuPanel - экземпляр(для вызова в другом классе) класса MenuPanel и передали ему метод OnPLay. Т е  передаем ссылку на OnPlay в OnEnable, чтобы вызвать(активировать) его.  вызовется при включении игры (т к OnEnable включается сразу при включении игры)
        _winPanel._win -= NewGame;
       // _gameManager._allLevelsDone -= WiningGame;
        _gameManager._WhenWin -= WiningGame;
    }


    public enum CurrentPanel
    {
        MenuPanel,
        GamePanel,
        WinPanel
    }

}
