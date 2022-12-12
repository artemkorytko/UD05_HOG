using System;
using DG.Tweening;
using UnityEngine;

namespace HOG
{
    public class PanelWithCanvasGroup : BasePanel
    { 
        private CanvasGroup _canvasGroup;

        protected void GetComponentCanvasGroup()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            //Debug.Log("canvasGroup +");
        }

        public override void Show()
        {
            SetAlphaPanel(true);
        }

        public override void Hide()
        {
            SetAlphaPanel(false);
        }
        
        private void SetAlphaPanel(bool isActivePanel)
        {
            _canvasGroup.blocksRaycasts = isActivePanel; 
            _canvasGroup.DOFade(isActivePanel ? 1:0,2);
            
             gameObject.SetActive(isActivePanel);  // выключаю объект, чтоб анимация кнопок отлк.
        }
    }
}