using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HOG
{
    public class MenuPanel : BasePanelWIthButton
    {
        private AudioManager _audioManager;
        public event Action OnMenuButtonClick;

        protected override void OnButtonClick()
        {
            OnMenuButtonClick?.Invoke();
            
        }
    }
}