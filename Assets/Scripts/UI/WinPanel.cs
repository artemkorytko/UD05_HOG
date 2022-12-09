using System;
using DG.Tweening;
using UnityEngine;

namespace HOG
{
    public class WinPanel : BaseUiPanelWithButton
    {
        public event Action NextLevl;

        protected override void OnButtonClick()
        {
            NextLevl?.Invoke();
        }
        
    }
}