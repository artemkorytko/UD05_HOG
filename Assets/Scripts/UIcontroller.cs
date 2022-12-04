using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using HOG;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
   [SerializeField] private MenuPanel _menuPanel; // cоздаем ссылки 
   [SerializeField] private GamePanel _gamePanel;
   [SerializeField] private WinPanel _winPanel;
   [SerializeField] private GameManager _gameManager;
  // [SerializeField] private CanvasGroup FadingMenu;
   // [SerializeField] private CanvasGroup FadingWin;

  private void Awake() //Awake вызывается в самом начале игры один раз, и вместе с ним активируется менюПанель, и не будут активны gamePanel и WinPanel
   {
      _menuPanel.gameObject.SetActive(true);
      _gamePanel.gameObject.SetActive(false);
      _winPanel.gameObject.SetActive(false);
   }

  private void OnEnable() //вызывается один раз при включении uicontroller(а включается он один раз)
  {
      _menuPanel._play += OnPLay; //подписались на событие _play из класса MenuPanel(где _menuPanel - экземпляр(для вызова в другом классе) класса MenuPanel и передали ему метод OnPLay. Т е  передаем ссылку на OnPlay в OnEnable, чтобы вызвать(активировать) его.  вызовется при включении игры (т к OnEnable включается сразу при включении игры)
      _winPanel._win += NewGame;
      _gameManager._allLevelsDone += WiningGame;

  }

  private void OnPLay()  //метод который включает GamePanel, Action - ивент(рация) на которую мы подписались, которая известит о нажатии кнопки "старт гейм" => и как следствие при нажатии кнопки "старт гейм" отключает МенюПанель и включет ГеймПанель
  { _menuPanel.gameObject.SetActive(false);
      _gamePanel.gameObject.SetActive(true);
      _winPanel.gameObject.SetActive(false);
      
  }

  private void NewGame() //аналогично OnPlay // включается при нажатии кнопки "о переходе на след уровень" на панелиПобеды , т е включает панель игры и отключает остальные панели 
  {
      _menuPanel.gameObject.SetActive(false);
      _gamePanel.gameObject.SetActive(true);
      _winPanel.gameObject.SetActive(false);
  }

  private void WiningGame() //метод который сработает после прохождения каждого уровня=> победе
  {
      _menuPanel.gameObject.SetActive(false);
      _gamePanel.gameObject.SetActive(false);
      _winPanel.gameObject.SetActive(true);
  }
  



  /* public void MenuPanel()
   {
   }

   public void GamePanel()
   {
   }

   public void WinPanel()
   {
   }
   

  
   */

  /* private void Update()
   {
      CurrentPanel Panel_now = new CurrentPanel();
      switch (Panel_now)
      {
         case (CurrentPanel.MenuPanel):
           // StartGame();
        
      }

   }
   */

}

public enum CurrentPanel
{
   MenuPanel,
   GamePanel,
   WinPanel
}

