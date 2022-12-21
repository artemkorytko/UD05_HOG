using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HOG
{
    //весит на WinPanel
    public class WinPanel : BasePanelWIthButton
    {
        public event Action OnNextLevelButtonClick;
      
        protected override void OnButtonClick()
        {
            OnNextLevelButtonClick?.Invoke();
        }
    }
}