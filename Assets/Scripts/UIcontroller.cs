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
   [SerializeField] private MenuPanel _menuPanel;
   [SerializeField] private GamePanel _gamePanel;
   [SerializeField] private WinPanel _winPanel;
  // [SerializeField] private CanvasGroup FadingMenu;
   // [SerializeField] private CanvasGroup FadingWin;

 /*  private void Awake()
   {
      _menuPanel.gameObject.SetActive(true);
      _gamePanel.gameObject.SetActive(false);
      _winPanel.gameObject.SetActive(false);
   }
   */

  /* public void MenuPanel()
   {
   }

   public void GamePanel()
   {
   }

   public void WinPanel()
   {
   }
   

   public void Button_click()
   {
      FadingMenu.DOFade(0, 1);
      FadingWin.DOFade(0, 1);

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

