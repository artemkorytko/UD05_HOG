using System;
using DG.Tweening;
using UnityEngine;

namespace HOG
{
    public class MenuPanel : BaseUiPanelWithButton
    {
        public event Action Play;

        protected override void OnButtonClick()
        {
            Play?.Invoke();
        }
        
    }
    
}